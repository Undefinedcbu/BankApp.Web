using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank_Web
{
    public static class ApiHelper
    {
        static string BASEURL= "http://localhost:54117/api/";


        public static object Put(string resource, object model, string token = "")
        {
            var restClient = new RestClient(BASEURL);
            var request = new RestRequest(resource, Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            if (!String.IsNullOrEmpty(token))
            {
                request.AddHeader("Authorization", "bearer " + token);
            }
            request.AddJsonBody(model);
            IRestResponse response = restClient.Put(request);
            return response;
        }

        public static object Put<T>(string resource, object model = null, string token = "") where T : class
        {

            var client = new RestClient(BASEURL);
            var request = new RestRequest(resource, Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            if (model != null)
                request.AddJsonBody(model);
            if (!String.IsNullOrEmpty(token))
            {
                request.AddHeader("Authorization", "bearer " + token);
            }
            IRestResponse response = client.Put(request);
            var content = response.Content;
            var data = JsonConvert.DeserializeObject<T>(content);
            return data;
        }
        public static object Post(string resource, object model,string token = "")
        {
            var client = new RestClient(BASEURL); ;
            var request = new RestRequest(resource, Method.POST);
            request.AddHeader("Content-Type", "application/json");
            if (!String.IsNullOrEmpty(token))
            {
                request.AddHeader("Authorization", "bearer " + token);
            }
            request.AddJsonBody(model);
            IRestResponse response = client.Execute(request);

            return response;
        }
        public static object Post<T>(string resource, object model = null, string token = "") where T : class
        {

            var client = new RestClient(BASEURL);
            var request = new RestRequest(resource, Method.POST);
            request.AddHeader("Content-Type", "application/json");
            if (model != null)
                request.AddJsonBody(model);
            if (!String.IsNullOrEmpty(token))
            {
                request.AddHeader("Authorization", "bearer " + token);
            }
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            var data = JsonConvert.DeserializeObject<T>(content);
            return data;
        }
        
        public static object Get<T>(string resource, object model = null, string token = "") where T : class
        {

            var client = new RestClient(BASEURL);
            var request = new RestRequest(resource, Method.GET);
            request.AddHeader("Content-Type", "application/json");
            if (model != null)
                request.AddJsonBody(model);
            if (!String.IsNullOrEmpty(token))
            {
                request.AddHeader("Authorization", "bearer " + token);
            }
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            if (!response.Content.Contains("Unauthorized"))
            {
                var data = JsonConvert.DeserializeObject<T>(content);
                return data;
            }
                return null;
            
            
            
        }


    }
}