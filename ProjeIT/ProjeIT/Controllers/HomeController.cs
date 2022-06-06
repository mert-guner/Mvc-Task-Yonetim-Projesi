using ProjeIT.Models.Entity;
using ProjeIT.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ProjeIT.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        taskManager cm = new taskManager();
        ProjeIT_DbEntities db = new ProjeIT_DbEntities();

        public ActionResult Index()
        {
            var bilgiler = cm.GetAll();
            return View(bilgiler);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            List<SelectListItem> degerler = (from i in db.Calisan.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Adi + " " + i.Soyadi,
                                                 Value = i.id.ToString()
                                             }).ToList();

            List<SelectListItem> degerler2 = (from i in db.aciliyetDurum.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.aciliyet_durum,
                                                  Value = i.id.ToString()
                                              }).ToList();


            ViewBag.dgr = degerler;
            ViewBag.dgr2 = degerler2;
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(task t)
        {

            if (t.id == 0)
            {
                cm.TaskAdd(t);
            }
            else
            {
                var guncellenecektask = db.task.Find(t.id);

                if (guncellenecektask == null)
                {
                    return HttpNotFound();
                }

                guncellenecektask.baslik = t.baslik;
                guncellenecektask.icerik = t.icerik;
                guncellenecektask.aciliyet_durumu = t.aciliyet_durumu;
                guncellenecektask.bitirilme_sure = t.bitirilme_sure;
                guncellenecektask.calisan = t.calisan;
            }



            

            //MailMessage mail = new MailMessage();
            //mail.To.Add(t.Calisan1.kullanici_adi);
            //mail.From = new MailAddress(t.Yonetici1.kullanici_adi);
            //mail.Subject = t.baslik;
            //mail.Body = t.icerik;
            //mail.IsBodyHtml = true;

            //SmtpClient smtp = new SmtpClient();
            //smtp.Credentials = new NetworkCredential(t.Yonetici1.kullanici_adi,t.Yonetici1.sifre);
            //smtp.Port = 587;
            //smtp.Host = "smtp.gmail.com";
            //smtp.EnableSsl = true;

            //smtp.Send(mail);


            return RedirectToAction("Index");
        }



        public ActionResult Sil(int id)
        {
            var silinicekdepartman = db.task.Find(id);

            if (silinicekdepartman == null)
            {
                return HttpNotFound();
            }

            db.task.Remove(silinicekdepartman);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Guncelle(int id)
        {
            var model = db.task.Find(id);

            if (model == null)
            {
                return HttpNotFound();

            }

            return View("Ekle", model);
        }
    }
}