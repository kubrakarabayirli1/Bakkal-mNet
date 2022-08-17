using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakkalımNet.Models.Entity;

namespace BakkalımNet.Controllers
{
    public class SatislarController : Controller
    {
        // GET: Satislar
        BakkalDbEntities db=new BakkalDbEntities(); 
        public ActionResult Index()
        {
            var model=db.satis.ToList();
            return View(model);
        }
        public ActionResult SatinAl(int id)
        {
            var model = db.satis_maddeleri.FirstOrDefault(x => x.sm_id == id);
            
            return View(model);
        }
        [HttpPost]
        public ActionResult SatinAl2(satis_maddeleri p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = db.satis_maddeleri.FirstOrDefault(x => x.sm_id == p.sm_id);      
             
                    var s = new satis
                    {
                    satis_id=model.satis_id,
                    s_tarih=DateTime.Now,
                    s_durum=model.satis.s_durum,
                    kullanici_id=model.satis.kullanici_id
                };
                    db.satis_maddeleri.Remove(model);
                    db.satis.Add(s);
                    ViewBag.islem = "Satın alma işlemi başarılı bir şekilde gerçekleşmiştir.";
                }
            }
            catch (Exception)
            {
                ViewBag.islem = "Satın alma işlemi başarısız.!";
            }
     
            
                return View("islem");
      
         
        }
    }
}