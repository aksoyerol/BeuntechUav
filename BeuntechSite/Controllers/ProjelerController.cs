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
    public class ProjelerController : Controller
    {
        private BeuntechSiteContext db = new BeuntechSiteContext();

        // GET: Projeler
        public ActionResult Index()
        {
            return View(db.Projeler.ToList());
        }

        // GET: Projeler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projeler projeler = db.Projeler.Find(id);
            if (projeler == null)
            {
                return HttpNotFound();
            }
            return View(projeler);
        }

        // GET: Projeler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projeler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Projeler projeler,HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                if (ResimURL != null)
                {
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo fileInfo = new FileInfo(ResimURL.FileName);

                    string resimyol = ResimURL.FileName + fileInfo.Extension;

                    img.Save("~/Uploads/Projeler/" + resimyol);
                    projeler.ResimURL = "/Uploads/Projeler/" + resimyol;

                }


                db.Projeler.Add(projeler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projeler);
        }

        // GET: Projeler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projeler projeler = db.Projeler.Find(id);
            if (projeler == null)
            {
                return HttpNotFound();
            }
            return View(projeler);
        }

        // POST: Projeler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ProjeID,Baslik,Aciklama,ResimURL")] Projeler projeler,HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {

                if (ResimURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(projeler.ResimURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(projeler.ResimURL));
                    }


                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo fileInfo = new FileInfo(ResimURL.FileName);

                    var resimyol = ResimURL.FileName + fileInfo.Extension;

                    img.Save("~/Uploads/Projeler/" + resimyol);
                    projeler.ResimURL = "/Uploads/Projeler/" + resimyol;

                }

                db.Entry(projeler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projeler);
        }

        // GET: Projeler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projeler projeler = db.Projeler.Find(id);
            if (projeler == null)
            {
                return HttpNotFound();
            }
            return View(projeler);
        }

        // POST: Projeler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projeler projeler = db.Projeler.Find(id);
            db.Projeler.Remove(projeler);
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
