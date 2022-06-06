using ProjeIT.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjeIT.Controllers
{
    public class KullaniciLoginController : Controller
    {
        // GET: KullaniciLogin

        ProjeIT_DbEntities db = new ProjeIT_DbEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Calisan calisan)
        {
            var bilgiler = db.Calisan.FirstOrDefault(x => x.kullanici_adi == calisan.kullanici_adi && x.sifre == calisan.sifre);

            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullanici_adi, false);
                Session["id"] = bilgiler.id;
                Session["kullanici_adi"] = bilgiler.kullanici_adi;
                Session["ad"] = bilgiler.Adi + " " + bilgiler.Soyadi;
                return RedirectToAction("Index", "Kullanici");
            }
            else
            {
                return View();
            }
            
        }



        [HttpPost]
        public ActionResult Uye(Calisan calisan)
        {

            var bilgiler = db.Calisan.FirstOrDefault(x => x.kullanici_adi != calisan.kullanici_adi);

            if (bilgiler != null)
            {
                db.Calisan.Add(calisan);
                db.SaveChanges();
                return RedirectToAction("KullaniciLogin", "Index");
            }
            else
            {
                return RedirectToAction("KullaniciLogin", "Index");
            }


            
        }



        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "KullaniciLogin");
        }
    }
}