namespace CUResorts.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("employee")]
    public partial class employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmpID { get; set; }

        public int GID { get; set; }

        [Required]
        [StringLength(5)]
        public string EmpRoleID { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public virtual person person { get; set; }
    }
}
