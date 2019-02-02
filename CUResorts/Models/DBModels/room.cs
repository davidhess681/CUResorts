namespace CUResorts.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("room")]
    public partial class room
    {
        [Key]
        [Column("room")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int room1 { get; set; }

        public int roomTypeID { get; set; }

        public int RoomStatus { get; set; }

        public virtual roomtype roomtype { get; set; }
    }
}
