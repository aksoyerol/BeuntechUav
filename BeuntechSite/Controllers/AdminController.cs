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

        [Route("YonetimPaneli")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("YonetimPaneli/Giris")]
        public ActionResult Login()
        {
            return View();

        }


        [HttpPost]
        
        public ActionResult Login(Admin admin)
        {
            var login = db.Admin.SingleOrDefault(x => x.EPosta == admin.EPosta && x.Sifre == admin.Sifre);

            if (login != null)
            {

            
                if (login.EPosta == admin.EPosta && login.Sifre == admin.Sifre)
                {
                    Session["AdminID"] = login.AdminID;
                    Session["EPosta"] = login.EPosta;
                    return RedirectToAction("Index", "Admin");
                }
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