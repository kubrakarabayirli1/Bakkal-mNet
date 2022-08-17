using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BakkalımNet.MyModel
{
    public class MyMarkalar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MyMarkalar()
        {
            this.urun = new HashSet<MyUrunler>();
        }

        public int marka_id { get; set; }
        [Display(Name = "Marka Adı")]
        public string m_adi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MyUrunler> urun { get; set; }
    }
}