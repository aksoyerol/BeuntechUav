using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using BeuntechSite.Models;
using BeuntechSite.Models.DataContext;

namespace BeuntechSite.Controllers
{
    public class TakimController : Controller
    {
        private BeuntechSiteContext db = new BeuntechSiteContext();

        // GET: Takim
        public ActionResult Index()
        {
            return View(db.Takim.ToList());
        }

        // GET: Takim/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Takim takim = db.Takim.Find(id);
            if (takim == null)
            {
                return HttpNotFound();
            }
            return View(takim);
        }

        // GET: Takim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Takim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "UyeID,AdSoyad,Bolum,Aciklama,UzmanlikAlani,Gorev,ResimURL,LinkedIN,Instagram,Telefon")] Takim takim,HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                if (ResimURL != null)
                {
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo fileInfo = new FileInfo(ResimURL.FileName);

                    string resimyol = ResimURL.FileName + fileInfo.Extension;

                    img.Save("~/Uploads/Takim/" + resimyol);
                    takim.ResimURL = "/Uploads/Takim/" + resimyol;

                }

                db.Takim.Add(takim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(takim);
        }

        // GET: Takim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Takim takim = db.Takim.Find(id);
            if (takim == null)
            {
                return HttpNotFound();
            }
            return View(takim);
        }

        // POST: Takim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "UyeID,AdSoyad,Bolum,Aciklama,UzmanlikAlani,Gorev,ResimURL,LinkedIN,Instagram,Telefon")] Takim takim,HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                if (ResimURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(takim.ResimURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(takim.ResimURL));
                    }


                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo fileInfo = new FileInfo(ResimURL.FileName);

                    var resimyol = ResimURL.FileName + fileInfo.Extension;

                    img.Save("~/Uploads/Takim/" + resimyol);
                    takim.ResimURL = "/Uploads/Takim/" + resimyol;

                }

                db.Entry(takim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(takim);
        }

        // GET: Takim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Takim takim = db.Takim.Find(id);
            if (takim == null)
            {
                return HttpNotFound();
            }
            return View(takim);
        }

        // POST: Takim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Takim takim = db.Takim.Find(id);
            db.Takim.Remove(takim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
