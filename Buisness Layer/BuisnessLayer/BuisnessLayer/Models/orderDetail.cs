//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BuisnessLayer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class orderDetail
    {
        public int orderItemId { get; set; }
        public Nullable<int> userId { get; set; }
        public Nullable<int> productId { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<decimal> totalAmount { get; set; }
    
        public virtual product product { get; set; }
        public virtual user user { get; set; }
    }
}
