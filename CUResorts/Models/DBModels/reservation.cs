namespace CUResorts.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("reservation")]
    public partial class reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RID { get; set; }

        public int GID { get; set; }

        public int room { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateReserved { get; set; }

        [Column(TypeName = "date")]
        public DateTime reservStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime reservEnd { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CheckIN { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CheckOUT { get; set; }
    }
}
