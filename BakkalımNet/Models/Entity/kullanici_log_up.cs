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
    
    public partial class kullanici_log_up
    {
        public int klu_id { get; set; }
        public string eski_k_kullaniciadi { get; set; }
        public string yeni_k_kullaniciadi { get; set; }
        public string eski_k_parola { get; set; }
        public string yeni_k_parola { get; set; }
        public string eski_k_adi { get; set; }
        public string yeni_k_adi { get; set; }
        public string eski_k_soyadi { get; set; }
        public string yeni_k_soyadi { get; set; }
        public string eski_k_eposta { get; set; }
        public string yeni_k_eposta { get; set; }
        public string eski_k_telefon { get; set; }
        public string yeni_k_telefon { get; set; }
        public Nullable<bool> eski_k_durum { get; set; }
        public Nullable<bool> yeni_k_durum { get; set; }
        public Nullable<int> eski_rol_id { get; set; }
        public Nullable<int> yeni_rol_id { get; set; }
        public System.DateTime islem_tarihi { get; set; }
        public string islem_ip { get; set; }
    }
}
