using BakkalımNet.Models.Entity;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using System.Web.Security;

namespace BakkalımNet.Controllers
{
    public class KullanicilarController : Controller
    {
        BakkalDbEntities db = new BakkalDbEntities();
        // GET: Kullanıcılar
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(kullanici k)
        {
            var user = db.kullanici.FirstOrDefault(x => x.k_kullaniciadi == k.k_kullaniciadi && x.k_parola == k.k_parola);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(k.k_kullaniciadi, false);
                return RedirectToAction("Index", "Kategoriler");
            }
            ViewBag.hata = "Kullanıcı adı veya şifre yanlış";
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResetPassword(kullanici k)
        {
            var model = db.kullanici.Where(x => x.k_eposta == k.k_eposta).FirstOrDefault();
            if (model != null)
            {
                Guid rasgele = Guid.NewGuid();
                model.k_parola = rasgele.ToString().Substring(0, 8);
                db.SaveChanges();
                SmtpClient s = new SmtpClient("smtp.yandex.ru",587);
                s.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("kubrakarabayirli1@yandex.com", "Şifre sıfırlama");
                mail.To.Add(model.k_eposta);
                mail.IsBodyHtml = true;
                mail.Subject = "Şifre Değiştirme İsteği";
                mail.Body += "Merhaba" + " " + model.k_adi + " " + model.k_soyadi + "<br/> Kullanıcı Adınız= "+" " + model.k_kullaniciadi + "<br/> Şifreniz= " + " " + model.k_parola;
                NetworkCredential net = new NetworkCredential("kubrakarabayirli1@yandex.com","15250068816");
                s.Credentials = net;
                s.Send(mail);
                return RedirectToAction("Login");
            }
            ViewBag.hata = "Böyle bir mail adresi bulunamadı";
            return View();

        }
        [HttpGet]
        public ActionResult Kaydol()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kaydol(kullanici k)
        {
            if (!ModelState.IsValid) return View();
            db.Entry(k).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Login");
        }
        [HttpGet]
            public ActionResult Guncelle()
            {
                if (User.Identity.IsAuthenticated)
                {
                    var kullaniciadi = User.Identity.Name;
                    var model = db.kullanici.FirstOrDefault(x=>x.k_kullaniciadi==kullaniciadi);
                    if (model!=null)
                    {
                        return View(model);
                    }
                    else
                    {
                        return View(new kullanici());
                    }
                }

                return HttpNotFound();
            }
            [HttpPost]
            public ActionResult Guncelle(kullanici k)
            {
                if (!ModelState.IsValid)
                {
                    var model = db.kullanici.Find(k.kullanici_id);
                    var u = new kullanici();
                    return View(u);
                }

                db.Entry(k).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                FormsAuthentication.SignOut();
                //FormsAuthentication.SetAuthCookie(k.k_kullaniciadi,false);
                return RedirectToAction("Login", "Kullanicilar");
            }
 
    }

}