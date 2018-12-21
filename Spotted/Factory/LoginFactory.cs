using System;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Spotted
{
    class LoginFactory
    {

        WebClient wc;
        string baseAPIUrl = "http://187.49.247.78:8080";
        public static List<string> InvalidJsonElements;


        public LoginFactory()
        {
            wc = new WebClient();
        }

        public string login(string login, string senha)
        {
            try
            {
                wc.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
                wc.Headers.Add(HttpRequestHeader.Accept, "application/json");
                wc.Headers.Add("X-Requested-With", "XMLHttpRequest");


                string dataString = @"{""user"": { ""login"": """ + login + @""", ""senha"": """ + senha + @""" } }";

                byte[] responseBytes = wc.UploadData(new Uri(this.baseAPIUrl + "/token"), "POST", Encoding.UTF8.GetBytes(dataString));

                var response = JObject.Parse(Encoding.UTF8.GetString(responseBytes));

                return response["data"]["token"].ToString();

            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}