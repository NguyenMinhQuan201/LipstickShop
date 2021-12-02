using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.Framework;
using Models.User;

namespace IUseLipstickShop.Controllers
{
    public class CartsController : Controller
    {
        private const string CartSession = "CartSession";
        private LipstickDbContext db = new LipstickDbContext();

        // GET: Carts
        public ActionResult Index()
        {
            var name = User.Identity.Name;
            if (name == "")
            {
                return RedirectToAction("Index", "UserLogin");
            }
            var result = new CartModels().GetCart(name);
            return View(result);
        }
        [HttpPost]
        
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = await db.Carts.FindAsync(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cart cart = await db.Carts.FindAsync(id);
            db.Carts.Remove(cart);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public JsonResult ChangePrice(int Prime, int Quanity)
        {
            var result = new CartModels().ChangePrice(Prime, Quanity);
            return Json(new { QuanityPice = result });
        }
        public JsonResult Checkout(string cartUser)
        {
            var result = new CartModels().Checkout(cartUser);
            return Json(new { totalCheck = result });
        }

        public JsonResult Remove(int prime)
        {
            var result = new CartModels().Remove(prime);
            return Json(new { status = result });
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
