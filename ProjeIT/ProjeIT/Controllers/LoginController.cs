using ProjeIT.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjeIT.Controllers
{
    public class LoginController : Controller
    {

        ProjeIT_DbEntities db = new ProjeIT_DbEntities();


        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(Yonetici yonetici)
        {

            var bilgiler = db.Yonetici.FirstOrDefault(x => x.kullanici_adi == yonetici.kullanici_adi && x.sifre == yonetici.sifre);

            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullanici_adi, false);
                Session["kullanici_adi"] = bilgiler.kullanici_adi;
                Session["ad"] = bilgiler.Adi+" "+bilgiler.Soyadi;
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }


        [HttpPost]
        public ActionResult Uye(Yonetici kayit)
        {

            var bilgiler = db.Yonetici.FirstOrDefault(x => x.kullanici_adi != kayit.kullanici_adi);

            if (bilgiler != null)
            {
                db.Yonetici.Add(kayit);
                db.SaveChanges();
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.mesaj = "Bu kullanıcı zaten mevcut. Lütfen farklı bir mail adresi giriniz!";
                return RedirectToAction("Index", "Login");

            }
            
        }


        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}