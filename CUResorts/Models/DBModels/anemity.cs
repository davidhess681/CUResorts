namespace CUResorts.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("anemity")]
    public partial class anemity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AID { get; set; }

        [Required]
        public string Description { get; set; }

        public decimal StandardCost { get; set; }

        public int StockCt { get; set; }
    }
}
