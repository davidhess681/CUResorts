namespace CUResorts.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class employee_roles
    {
        [Key]
        [StringLength(5)]
        public string EmpRoleID { get; set; }

        [Required]
        public string Permissions { get; set; }
    }
}
