using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BakkalımNet.MyModel
{
    public class MyStok
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MyStok()
        {
            this.urun = new HashSet<MyUrunler>();
        }

        public int stok_id { get; set; }
        [Display(Name = "Stok Adedi")]
        public int s_adedi { get; set; }
        public System.DateTime s_giris_tarihi { get; set; }
        [Display(Name = "Stok Giriş Tarihi")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> s_bitis_tarihi { get; set; }
        [Display(Name = "Stok Bitiş Tarihi")]
        [DataType(DataType.Date)]

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MyUrunler> urun { get; set; }
    }
}