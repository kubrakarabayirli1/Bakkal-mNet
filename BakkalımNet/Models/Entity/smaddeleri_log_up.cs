//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BakkalımNet.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class smaddeleri_log_up
    {
        public int smlu_id { get; set; }
        public Nullable<double> eski_si_miktar { get; set; }
        public Nullable<double> yeni_si_miktar { get; set; }
        public Nullable<double> eski_si_fiyat { get; set; }
        public Nullable<double> yeni_si_fiyat { get; set; }
        public Nullable<double> eski_si_iskonto { get; set; }
        public Nullable<double> yeni_si_iskonto { get; set; }
        public Nullable<int> eski_satis_id { get; set; }
        public int yeni_satis_id { get; set; }
        public Nullable<int> eski_urun_id { get; set; }
        public Nullable<int> yeni_urun_id { get; set; }
        public System.DateTime islem_tarihi { get; set; }
        public string islem_ip { get; set; }
    }
}
