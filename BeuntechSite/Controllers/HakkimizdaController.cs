using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeuntechSite.Models;
using BeuntechSite.Models.DataContext;

namespace BeuntechSite.Controllers
{
    public class HakkimizdaController : Controller
    {
        private BeuntechSiteContext db = new BeuntechSiteContext();

        // GET: Hakkimizda
        public ActionResult Index()
        {
            return View(db.Hakkimizda.ToList());
        }

        

        // GET: Hakkimizda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hakkimizda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "HakkimizdaID,Baslik,Aciklama")] Hakkimizda hakkimizda)
        {
            if (ModelState.IsValid)
            {
                db.Hakkimizda.Add(hakkimizda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hakkimizda);
        }

        // GET: Hakkimizda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hakkimizda hakkimizda = db.Hakkimizda.Find(id);
            if (hakkimizda == null)
            {
                return HttpNotFound();
            }
            return View(hakkimizda);
        }

        // POST: Hakkimizda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id,[Bind(Include = "HakkimizdaID,Baslik,Aciklama")] Hakkimizda hakkimizda, HttpPostedFileBase ResimUrl)
        {
            var sorgu = db.Hakkimizda.Find(id);
            if (ModelState.IsValid)
            {
               

                if (ResimUrl!=null && ResimUrl.ContentLength>0)
                {
                    if (System.IO.File.Exists(Server.MapPath(sorgu.ResimUrl)))
                    {
                        System.IO.File.Delete(sorgu.ResimUrl);
                    }

                    string fileName = $"hakkimizda_{hakkimizda.HakkimizdaID}_{Guid.NewGuid()}.{ResimUrl.ContentType.Split('/')[1]}";
                    ResimUrl.SaveAs(Server.MapPath($"~/Uploads/Hakkimizda/{fileName}"));
                    
                    sorgu.ResimUrl = fileName;
                }



                sorgu.Aciklama = hakkimizda.Aciklama;
                sorgu.Baslik = hakkimizda.Baslik;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hakkimizda);
        }

        // GET: Hakkimizda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hakkimizda hakkimizda = db.Hakkimizda.Find(id);
            if (hakkimizda == null)
            {
                return HttpNotFound();
            }
            return View(hakkimizda);
        }

        // POST: Hakkimizda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hakkimizda hakkimizda = db.Hakkimizda.Find(id);
            db.Hakkimizda.Remove(hakkimizda);
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
