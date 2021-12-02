namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Images { get; set; }

        public decimal? Price { get; set; }

        [StringLength(10)]
        public string Size { get; set; }

        [StringLength(50)]
        public string Colour { get; set; }

        public virtual Order Order { get; set; }
    }
}
