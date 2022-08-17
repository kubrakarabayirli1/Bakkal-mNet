using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakkalımNet.Models.Entity;
using BakkalımNet.MyModel;

namespace BakkalımNet.Controllers
{
    public class StokController : Controller
    {
        BakkalDbEntities db = new BakkalDbEntities();
        public ActionResult Index()
        {
            return View(db.stok.ToList());
        }
        [HttpGet]
        public ActionResult Ekle()
        {
      
            return View("Kaydet");
        }
        [HttpPost]
        public ActionResult Kaydet(stok p)
        {

            if (p.stok_id==0)
            {
                if (p.s_adedi == null || p.s_giris_tarihi == null)
                {
                    return View();
                }
                db.Entry(p).State = System.Data.Entity.EntityState.Added;
            }
            else if(p.stok_id>0)
            {
                if (p.s_adedi == null || p.s_giris_tarihi == null)
                {
                    return View();
                }
                db.Entry(p).State=System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();       
            return RedirectToAction("Index");
        }
        public ActionResult GuncelleBilgiGetir(int id)
        {
            var ara = db.stok.Find(id);
            MyStok s = new MyStok();
            s.stok_id = ara.stok_id;
            s.s_adedi=ara.s_adedi;
            s.s_giris_tarihi = ara.s_giris_tarihi;
            s.s_bitis_tarihi = ara.s_bitis_tarihi;
            return View(s);
        }
        public ActionResult Guncelle(stok p)
        {
            if (!ModelState.IsValid)
            {
                return View("GuncelleBilgiGetir");
            }
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SilBilgiGetir(int id)
         {
             var getir = db.stok.Find(id);
             return View(getir);
         }
         public ActionResult Sil(stok p)
         {
             db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
             db.SaveChanges();
             return RedirectToAction("Index");
         }

    }
}
