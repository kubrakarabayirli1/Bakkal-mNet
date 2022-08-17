using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BakkalımNet.MyModel
{
    public class MyUrunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MyUrunler()
        {
           // this.satis_maddeleri = new HashSet<satis_maddeleri>();
        }

        public int urun_id { get; set; }
        [Display(Name = "Ürün Adı")]
        public string u_adi { get; set; }
        [Display(Name = "Barkodu")]
        public string u_barkodu { get; set; }
        [Display(Name = "Üretim Tarihi")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> u_uretim_tarihi { get; set; }
        [Display(Name = "Tüketim Tarihi")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> u_tuketim_tarihi { get; set; }
        [Display(Name = "Fiyatı")]
        public double u_fiyat { get; set; }
        [Display(Name = "Ağırlık")]
        public Nullable<double> u_agirlik { get; set; }
        [Display(Name = "Renk")]
        public string u_rengi { get; set; }
        [Display(Name = "Marka Adı")]
        public int marka_id { get; set; }
        [Display(Name = "Kategori Adı")]
        public int kategori_id { get; set; }
        [Display(Name = "Stok Adedi")]
        public int stok_id { get; set; }


        public virtual MyKategoriler kategori { get; set; }

        public virtual MyMarkalar marka { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
       //public virtual ICollection<satis_maddeleri> satis_maddeleri { get; set; }

        public virtual MyStok stok { get; set; }

        public List<SelectListItem> KategoriListesi { get; set; }

        public List<SelectListItem> MarkaListesi { get; set; }
    }
}