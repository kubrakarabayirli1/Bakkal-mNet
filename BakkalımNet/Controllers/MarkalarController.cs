using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakkalımNet.Models.Entity;
using BakkalımNet.MyModel;

namespace BakkalımNet.Controllers
{
    public class MarkalarController : Controller
    {
        BakkalDbEntities db=new BakkalDbEntities();
        public ActionResult Index()
        {
            var model = db.marka.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            var model = new marka();
            return View();  
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Ekle(marka m)
        {
         
            db.Entry(m).State=System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GuncelleBilgiGetir(int id)
        {
            MyMarkalar model = new MyMarkalar();
            var ara = db.marka.Find(id);
            model.marka_id = ara.marka_id;
            model.m_adi = ara.m_adi;
            return View(model);
        }
        public ActionResult Guncelle(marka p)
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
            var getir = db.marka.Find(id);
            return View(getir);
        }
        public ActionResult Sil(marka p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}