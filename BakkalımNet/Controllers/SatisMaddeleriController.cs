using BakkalımNet.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BakkalımNet.Controllers
{
    public class SatisMaddeleriController : Controller
    {
        // GET: SatisMaddeleri
        BakkalDbEntities db = new BakkalDbEntities();
        public ActionResult Index(decimal? Tutar)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var kullanici=db.kullanici.FirstOrDefault(x=>x.k_kullaniciadi==kullaniciadi);
                var model = db.satis_maddeleri.Where(x => x.satis.kullanici_id == kullanici.kullanici_id).ToList();
                var kid = db.satis_maddeleri.FirstOrDefault(x => x.satis.kullanici_id == kullanici.kullanici_id);
                if (model != null)
                {
                    if (kid==null)
                    {
                        ViewBag.Tutar = "her hangi bir satış işleminiz yok";
                    }
                    else if (kid!=null)
                    {
                        Tutar = (decimal?)db.satis_maddeleri.Where(x => x.satis.kullanici_id == kid.satis.kullanici_id).Sum(x => x.si_fiyat);
                        ViewBag.Tutar = "Toplam Tutar=" + Tutar + "TL";
                    }
                }     
                return View(model);
            }
            return HttpNotFound();
        }
        public ActionResult SatisEkle(int id)
        {
            if (User.Identity.IsAuthenticated)
            {

                var m = db.satis_maddeleri.Where(x => x.satis_id == x.satis.satis_id).FirstOrDefault();
                var kullaniciadi = User.Identity.Name;
                var model=db.kullanici.FirstOrDefault(x=>x.k_kullaniciadi==kullaniciadi);
                var u = db.urun.Find(id);
                var sepet = db.satis_maddeleri.FirstOrDefault(x => x.satis.kullanici_id == model.kullanici_id && x.urun_id ==id);
                if (model!= null)
                {
                    if (sepet!=null)
                    {
                        sepet.si_miktar++;
                        sepet.si_fiyat = u.u_fiyat * sepet.si_miktar;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    
                    var s = new satis_maddeleri
                    {
                        satis_id=1,
                        urun_id = u.urun_id,
                        si_miktar = 1,
                        si_fiyat = u.u_fiyat,
                  
                        
                    };
                    db.Entry(s).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    return RedirectToAction("Index");




                }
            }
            return HttpNotFound();
        }
        public ActionResult TotalCount(int? count)
        {
            if (User.Identity.IsAuthenticated)
            {
                var model = db.kullanici.FirstOrDefault(x => x.k_kullaniciadi == User.Identity.Name);
                count = db.satis_maddeleri.Where(x => x.satis.kullanici_id == model.kullanici_id).Count();
                ViewBag.Count = count;
                if (count==0)
                {
                    ViewBag.Count = "";
                }
                return PartialView();
            }
            return HttpNotFound();
        }
        public ActionResult Arttir(int id)
        {
            var model = db.satis_maddeleri.Find(id);
            model.si_miktar++;
            model.si_fiyat = model.urun.u_fiyat * model.si_miktar;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Azalt(int id)
        {
            var model = db.satis_maddeleri.Find(id);
            if (model.si_miktar==1)
            {
                db.satis_maddeleri.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            model.si_miktar--;
            model.si_fiyat = model.urun.u_fiyat * model.si_miktar;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var model = db.satis_maddeleri.Find(id);
            db.satis_maddeleri.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult HepsiniSil()
        {
            if (User.Identity.IsAuthenticated) 
            {
                var kullaniciadi = User.Identity.Name;
                var model = db.kullanici.FirstOrDefault(x => x.k_kullaniciadi.Equals(kullaniciadi));
                var sil = db.satis_maddeleri.Where(x => x.satis.kullanici_id.Equals(model.kullanici_id));
                db.satis_maddeleri.RemoveRange(sil);
                db.SaveChanges();
                return RedirectToAction("Index");
            
            }
            return HttpNotFound();
        }
    }
   
}