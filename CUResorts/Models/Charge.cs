//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CUResorts.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Charge
    {
        public int CID { get; set; }
        public int RID { get; set; }
        public int AID { get; set; }
        public System.DateTime DateCharged { get; set; }
        public string Void { get; set; }
    
        public virtual Anemity Anemity { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}