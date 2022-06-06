using ProjeIT.Models.Entity;
using ProjeIT.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeIT.Controllers
{
    [Authorize]
    public class KullaniciController : Controller
    {
        taskManager cm = new taskManager();
        ProjeIT_DbEntities db = new ProjeIT_DbEntities();


        // GET: Kullanici
        public ActionResult Index()
        {
            //var bilgiler = db.task.FirstOrDefault(x => x.Calisan1.id == t.calisan);

            var model = db.task.ToList();

            return View(model);
        }


        [HttpPost]
        public ActionResult Ekle(task t)
        {

            if (t.id == 0)
            {
                db.task.Add(t);
            }
            else
            {
                var guncellenecektask = db.task.Find(t.id);

                if (guncellenecektask == null)
                {
                    return HttpNotFound();
                }

                //guncellenecektask.baslik = t.baslik;
                //guncellenecektask.icerik = t.icerik;
                //guncellenecektask.aciliyet_durumu = t.aciliyet_durumu;
                //guncellenecektask.bitirilme_sure = t.bitirilme_sure;
                //guncellenecektask.calisan = t.calisan;
                guncellenecektask.durum = t.durum;
            }
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