using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BakkalımNet.MyModel
{
    public class MyKategoriler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MyKategoriler()
        {
            this.urun = new HashSet<MyUrunler>();
        }

        public int kategori_id { get; set; }
        [Display(Name = "Kategori Adı")]
        public string k_adi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MyUrunler> urun { get; set; }
    }
}