using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakkalımNet.Models.Entity;
using BakkalımNet.MyModel;

namespace BakkalımNet.Controllers
{
    public class KategorilerController : Controller
    {
        BakkalDbEntities db = new BakkalDbEntities();
        public ActionResult Index()
        {
            return View(db.kategori.ToList());
        }
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Ekle2(kategori p)
        {
            if (!ModelState.IsValid) return View("Ekle");
            db.kategori.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GuncelleBilgiGetir(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var model=db.kategori.Find(id);
            MyKategoriler k=new MyKategoriler();
            k.kategori_id = model.kategori_id;
            k.k_adi = model.k_adi;

            if (model == null) return HttpNotFound(); 
            
            return View(k);
        }
        public ActionResult Guncelle(kategori p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SilBilgiGetir(int id)
        {
            var model = db.kategori.Find(id);
            if (model == null) return HttpNotFound();
            return View(model);
        }
        public ActionResult Sil(kategori p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}