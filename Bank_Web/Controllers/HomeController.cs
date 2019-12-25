using Bank_Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bank_Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            string url = "/Hesap";
            Globals.testModel.Hesaplar = (List<Hesap>)ApiHelper.Get<List<Hesap>>(url, token: Globals.token.access_token);
            return RedirectToAction("Index","Login");
        }

       
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult asd()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}