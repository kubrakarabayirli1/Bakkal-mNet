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
    
    public partial class kullanici_log_ins_del
    {
        public int klid_ip { get; set; }
        public int kullanici_id { get; set; }
        public string k_kullaniciadi { get; set; }
        public string k_parola { get; set; }
        public string k_adi { get; set; }
        public string k_soyadi { get; set; }
        public string k_eposta { get; set; }
        public string k_telefon { get; set; }
        public Nullable<bool> k_durum { get; set; }
        public Nullable<int> rol_id { get; set; }
        public System.DateTime islem_tarihi { get; set; }
        public string islem_turu { get; set; }
        public string islem_ip { get; set; }
    }
}
