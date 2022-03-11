namespace PruebaBG1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Producto")]
    public partial class Producto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public decimal price { get; set; }

        public decimal mrp { get; set; }

        public int stock { get; set; }

        [Required]
        [StringLength(5)]
        public string isPublished { get; set; }
    }
}
