using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bank_Web.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Kullanici
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Hesap()
        {
            return View();
        }
        public ActionResult Virman()
        {
            return View();
        }
        public ActionResult Havale()
        {
            return View();
        }
        public ActionResult Fatura()
        {
            return View();
        }

    }
}