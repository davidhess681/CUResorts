namespace CUResorts.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class charge
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CID { get; set; }

        public int RID { get; set; }

        public int AID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateCharged { get; set; }

        [Required]
        public string Void { get; set; }
    }
}
