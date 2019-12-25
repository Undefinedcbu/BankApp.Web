using Bank_Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bank_Web.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {       
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        string Baseurl = "http://localhost:54117/";
        public async Task<ActionResult> GetUser(string TCKimlik, string parola)
        {
          //  Musteri musteri = new Musteri();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");


                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                string url = "/token";
                List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>
                 {
                    new KeyValuePair<string, string>( "grant_type", "password" ),
                    new KeyValuePair<string, string>( "username", TCKimlik ),
                    new KeyValuePair<string, string> ( "password", parola )
                 };
                HttpContent content = new FormUrlEncodedContent(pairs);
                HttpResponseMessage Res = await client.PostAsync(url, content);

                // Token'ı headerda api'ya gönderdim.


                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var TokenResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    Globals.token = JsonConvert.DeserializeObject<Token>(TokenResponse);

                    string url1 = "Musteri?TCKimlik=" + TCKimlik;
                    Globals.musteri = (Musteri)ApiHelper.Get<Musteri>(url1, token: Globals.token.access_token);

                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Globals.token.access_token);
                    //url = "/api/Musteri?TCKimlik=" + TCKimlik;
                    //HttpResponseMessage Response = await client.GetAsync(url);

                    //if (Response.IsSuccessStatusCode)
                    //{
                    //    var UserResponse = Response.Content.ReadAsStringAsync().Result;

                    //    Globals.musteri = JsonConvert.DeserializeObject<Musteri>(UserResponse);
                    //}
                }

                return RedirectToAction("Index", "Kullanici");
                //returning the employee list to view  

            }
        }


        //public ActionResult Giris()
        //{

        //    return RedirectToAction("Index", "Home");
        //}
        public ActionResult KayitOl()
        {
            return View();
        }
    }
}