namespace CUResorts.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("roomtype")]
    public partial class roomtype
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public roomtype()
        {
            rooms = new HashSet<room>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int roomTypeID { get; set; }

        [Required]
        public string Style { get; set; }

        [Required]
        public string Smoking { get; set; }

        public double StandardCost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<room> rooms { get; set; }
    }
}
