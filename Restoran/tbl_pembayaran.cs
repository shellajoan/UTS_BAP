//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restoran
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_pembayaran
    {
        public int id { get; set; }
        public Nullable<int> id_order { get; set; }
        public Nullable<decimal> subtotal { get; set; }
        public Nullable<int> persen_ppn { get; set; }
        public Nullable<decimal> ppn { get; set; }
        public Nullable<decimal> nominal_bayar { get; set; }
        public Nullable<decimal> kembali { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public string updated_by { get; set; }
        public Nullable<System.DateTime> updated_date { get; set; }
        public string deleted_by { get; set; }
        public Nullable<System.DateTime> deleted_date { get; set; }
        public Nullable<int> is_active { get; set; }
    }
}
