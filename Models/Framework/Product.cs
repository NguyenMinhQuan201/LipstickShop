namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Alias { get; set; }

        public int? CategoryId { get; set; }

        [StringLength(50)]
        public string Images { get; set; }

        public DateTime? Createdate { get; set; }

        public decimal? Price { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public bool? Status { get; set; }

        [StringLength(10)]
        public string Size { get; set; }

        [StringLength(50)]
        public string Colour { get; set; }
    }
}
