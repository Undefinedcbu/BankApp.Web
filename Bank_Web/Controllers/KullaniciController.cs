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

    public class KullaniciController : Controller
    {
    
        public ActionResult Index()
        {
            string url = "/Hesap/Liste?id=" + Globals.musteri.MusteriID;
            Globals.musteri.Hesaplar = (List<Hesap>)ApiHelper.Get<List<Hesap>>(url, token: Globals.token.access_token);
            ViewBag.Ad = Globals.musteri.Ad;
            decimal top_bakiye=0;
            foreach (var item in Globals.musteri.Hesaplar)
            {
                if (item.Durum == "Açık")
                {
                    top_bakiye += item.Bakiye;
                }
            }

            ViewBag.Bakiye = top_bakiye;
            return View();
        }
        public ActionResult HesapKapat(int id)
        {
            string url = "/Hesap/Kapat/?id=" + id;
            Hesap hesap = (Hesap)ApiHelper.Put<Hesap>(url, token: Globals.token.access_token);

            return View("Index");
        }
        public ActionResult Hesap()
        {
            ViewBag.Ad = Globals.musteri.Ad;
            
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
        public ActionResult Fatura(string AboneNo)
        {
            string url1 = "Odeme?AboneNo="+AboneNo;
            Globals.musteri.Fatura = (Odeme)ApiHelper.Get<Odeme>(url1, token: Globals.token.access_token);

            return View();
        }
        public ActionResult Kredi()
        {
            return View();
        }
    }
    
}