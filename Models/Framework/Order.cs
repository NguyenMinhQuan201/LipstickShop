namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int OrderID { get; set; }

        public decimal? Price { get; set; }

        public int? Id { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }
    }
}
