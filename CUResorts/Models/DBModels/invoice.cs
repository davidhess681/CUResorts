namespace CUResorts.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("invoice")]
    public partial class invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VID { get; set; }

        public int GID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DatePaid { get; set; }

        public int AmountPaid { get; set; }

        [Required]
        public string PaymentType { get; set; }

        [Required]
        public string Void { get; set; }
    }
}
