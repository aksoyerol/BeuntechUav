using BeuntechSite.Models;
using BeuntechSite.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeuntechSite.Controllers
{
    public class AdminController : Controller
    {
        BeuntechSiteContext db = new BeuntechSiteContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var login = db.Admin.Where(x => x.EPosta == admin.EPosta).SingleOrDefault();

            if (login.EPosta == admin.EPosta && login.Sifre == admin.Sifre)
            {
                Session["AdminID"] = login.AdminID;
                Session["EPosta"] = login.EPosta;
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.Uyari = "Kullanıcı adı veya şifre geçersiz !";
            return View(admin);
        }

        public ActionResult Logout()
        {
            Session["AdminID"] = null;
            Session["EPosta"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admin");


        }
    }
}