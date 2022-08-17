using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakkalımNet.Models.Entity;
using BakkalımNet.MyModel;

namespace BakkalımNet.Controllers
{
    public class UrunlerController : Controller
    {
        BakkalDbEntities db = new BakkalDbEntities();

        public ActionResult Index()
        {
            var model = db.urun.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            var model = new MyUrunler();
            Yenile(model);
            return View(model);
        }
        private void Yenile(MyUrunler model)
        {
            List<kategori> kategorilist = db.kategori.OrderBy(x => x.k_adi).ToList();
            model.KategoriListesi = (from x in kategorilist
                                     select new SelectListItem
                                     {
                                         Text = x.k_adi,
                                         Value = x.kategori_id.ToString()
                                     }
                ).ToList();
            List<marka> markalist = db.marka.OrderBy(x => x.m_adi).ToList();
            model.MarkaListesi = (from x in markalist
                                  select new SelectListItem
                                  {
                                      Text = x.m_adi,
                                      Value = x.marka_id.ToString()
                                  }
                ).ToList();
        }
  

           [HttpPost, ValidateAntiForgeryToken]
            public ActionResult Ekle(urun p)
            {
                if (!ModelState.IsValid)
                {
                    var model = new MyUrunler();
                    Yenile(model);
                return View(model);
                }
                db.Entry(p).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            return RedirectToAction("Index");
            }
        [HttpGet]


        public ActionResult GuncelleBilgiGetir(int id)
          {
              var model = db.urun.Find(id);
              var u = new MyUrunler();
              u.urun_id = model.urun_id;
              u.u_adi = model.u_adi;
            u.u_barkodu = model.u_barkodu;
            u.u_uretim_tarihi = model.u_uretim_tarihi;
            u.u_tuketim_tarihi = model.u_tuketim_tarihi;
            u.u_fiyat = model.u_fiyat;
            u.u_agirlik=model.u_agirlik;
            u.u_rengi = model.u_rengi;
            u.marka_id = model.marka_id ;
            u.kategori_id=model.kategori_id;
            u.stok_id = model.stok_id;
              Yenile(u);
              return View(u);
          }
        [HttpPost]
        public ActionResult Guncelle(urun p)
          {

              if (!ModelState.IsValid)
              {
                var model = db.urun.Find(p.urun_id);
                var u = new MyUrunler();
                Yenile(u);
                return View(u); 
              }

               db.SaveChanges();
              return RedirectToAction("Index");
          }

        public ActionResult SilBilgiGetir(int id)
        {
            var getir = db.urun.Find(id);
            return View(getir);
        }
        public ActionResult Sil(urun p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}