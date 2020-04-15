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
    public class BlogController : Controller
    {
        private BeuntechSiteContext db = new BeuntechSiteContext();

        // GET: Blog
        public ActionResult Index()
        {
            var blog = db.Blog.Include(b => b.Kategori);
            return View(blog.ToList());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blog.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            ViewBag.KategoriID = new SelectList(db.Kategori, "KategoriID", "KategoriAd");
            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "BlogID,Baslik,Icerik,ResimURL,KategoriID,tarih")] Blog blog,HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {

                if (ResimURL != null)
                {
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo fileInfo = new FileInfo(ResimURL.FileName);

                    string resimyol = ResimURL.FileName + fileInfo.Extension;

                    img.Save("~/Uploads/Blog/" + resimyol);
                    img.Resize(900, 715);
                    blog.ResimURL = "/Uploads/Blog/" + resimyol;

                }
                DateTime tarih = DateTime.Now;
                blog.tarih = tarih;
                db.Blog.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriID = new SelectList(db.Kategori, "KategoriID", "KategoriAd", blog.KategoriID);
            return View(blog);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blog.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriID = new SelectList(db.Kategori, "KategoriID", "KategoriAd", blog.KategoriID);
            return View(blog);
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "BlogID,Baslik,Icerik,ResimURL,KategoriID")] Blog blog,HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                if (ResimURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(blog.ResimURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(blog.ResimURL));
                    }


                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo fileInfo = new FileInfo(ResimURL.FileName);

                    var resimyol = ResimURL.FileName + fileInfo.Extension;

                    img.Save("~/Uploads/Blog/" + resimyol);
                    img.Resize(900, 715);
                    blog.ResimURL = "/Uploads/Blog/" + resimyol;

                }



                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriID = new SelectList(db.Kategori, "KategoriID", "KategoriAd", blog.KategoriID);
            return View(blog);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blog.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blog.Find(id);
            db.Blog.Remove(blog);
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
