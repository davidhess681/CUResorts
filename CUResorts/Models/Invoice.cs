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
    
    public partial class Invoice
    {
        public int VID { get; set; }
        public int GID { get; set; }
        public System.DateTime DatePaid { get; set; }
        public int AmountPaid { get; set; }
        public string PaymentType { get; set; }
        public string Void { get; set; }
    
        public virtual Person Person { get; set; }
    }
}
