using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HiFi.Common.Helpers;
using HiFi.Dto;
using HiFi.Dto.Dtos;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace HiFi.Services.Services
{
    public class WebApiService<T> where T : class
    {
        static string url = "http://localhost:51075/api/";

        //Bütün tabloyu getirir.
        public List<T> Get(string method)
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
                httpClient1.BaseAddress = new Uri(url);
                httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient1.DefaultRequestHeaders.Add("Authorization", "Bearer " + SessionHelper.TokenInfo.access_token);
                HttpResponseMessage response = httpClient1.GetAsync(method).Result;
                return ConvertList(response);
            }
        }

        //parçalı veri getirir.
        public T Get(string method, int pageNumber, int pageSize)
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
                httpClient1.BaseAddress = new Uri(url);
                httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient1.DefaultRequestHeaders.Add("Authorization", "Bearer " + SessionHelper.TokenInfo.access_token);
                HttpResponseMessage response = httpClient1.GetAsync(method+"/?pageNumber="+pageNumber+"&pageSize="+pageSize).Result;            
                var message = response.Content.ReadAsStringAsync().Result;
                var newData = JsonConvert.DeserializeObject<T>(JsonConvert.DeserializeObject<string>(message));
                return newData;

            }
        }

        //Verilen id değerine sahip veriyi getirir.
        public T GetId(string method, int id)
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
                httpClient1.BaseAddress = new Uri(url);
                httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient1.DefaultRequestHeaders.Add("Authorization", "Bearer " + SessionHelper.TokenInfo.access_token);
                HttpResponseMessage response = httpClient1.GetAsync(method + "/" + id).Result;
                var message = response.Content.ReadAsStringAsync().Result;
                var newData = JsonConvert.DeserializeObject<T>(JsonConvert.DeserializeObject<string>(message));
                return newData;
            }
        }


        //Farklı methodlar ile verilen id değerine sahip verileri getirir.
        public List<T> GetSpecial(string method, int id)
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
                httpClient1.BaseAddress = new Uri(url);
                httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient1.DefaultRequestHeaders.Add("Authorization", "Bearer " + SessionHelper.TokenInfo.access_token);
                HttpResponseMessage response = httpClient1.GetAsync(method + "/" + id).Result;
                return ConvertList(response);
            }

        }

        //Gelen yeni veriyi veritabanına ekler.
        public void Post(string method, T value)
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
                httpClient1.BaseAddress = new Uri(url);
                httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient1.DefaultRequestHeaders.Add("Authorization", "Bearer " + SessionHelper.TokenInfo.access_token);
                StringContent httpContent = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient1.PostAsync(method, httpContent).Result;
            }

        }


        //Verilen mail adresini yollar.
        public string GetMailFeedback(string method, string mail)
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
                httpClient1.BaseAddress = new Uri(url);
                httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient1.DefaultRequestHeaders.Add("Authorization", "Bearer " + SessionHelper.TokenInfo.access_token);
                StringContent httpContent = new StringContent(JsonConvert.SerializeObject(mail), Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient1.PostAsync(method , httpContent).Result;
                var message = response.Content.ReadAsStringAsync().Result;
                var newData = JsonConvert.DeserializeObject<string>(JsonConvert.DeserializeObject<string>(message));
                return newData;
            }
        }

        //Verilen id değerine sahip veriyi günceller.
        public void Put(string method, int id, T value)
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
                httpClient1.BaseAddress = new Uri(url);
                httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient1.DefaultRequestHeaders.Add("Authorization", "Bearer " + SessionHelper.TokenInfo.access_token);
                StringContent httpContent = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient1.PutAsync(method + "/" + id, httpContent).Result;
            }
        }

        //Verilen id değerine sahip veriyi siler.
        public void Delete(string method, int id)
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
                httpClient1.BaseAddress = new Uri(url);
                httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient1.DefaultRequestHeaders.Add("Authorization", "Bearer " + SessionHelper.TokenInfo.access_token);
                HttpResponseMessage response = httpClient1.DeleteAsync(method + "/" + id).Result;
            }

        }

        //Webapiden gelen veriyi listeye çevirir
        public List<T> ConvertList(HttpResponseMessage response)
        {
            List<T> newData = new List<T>();
            var message = response.Content.ReadAsStringAsync().Result;
            newData = JsonConvert.DeserializeObject<List<T>>(JsonConvert.DeserializeObject<string>(message));
            return newData;
        }

        //Gönderilen veriler ile token alınmasını sağlar.
        public T GetToken(string userName, string password)
        {
            string baseAddress = "http://localhost:51075/";
            T token;
            using (var client = new HttpClient())
            {
                var form = new Dictionary<string, string>
                {
                    {"grant_type", "password"},
                    {"username", userName},
                    {"password", password},
                };
                var tokenResponse = client.PostAsync(baseAddress + "token", new FormUrlEncodedContent(form)).Result;
                var tok = tokenResponse.Content.ReadAsStringAsync().Result;
                token = JsonConvert.DeserializeObject<T>(tok);
            }
            return token;
        }

        //Verilen id'ye gelen dosyaları yükler.
        public void UploadFile(string method, int id, HttpPostedFileBase file)
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    MemoryStream target = new MemoryStream();
                    file.InputStream.CopyTo(target);
                    byte[] Bytes = target.ToArray();
                    file.InputStream.Read(Bytes, 0, Bytes.Length);
                    var fileContent = new ByteArrayContent(Bytes);
                    fileContent.Headers.ContentDisposition =
                        new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") { FileName = file.FileName };
                    content.Add(fileContent);
                    content.Add(new StringContent("123"), "FileId");

                    httpClient1.BaseAddress = new Uri(url);
                    httpClient1.DefaultRequestHeaders.Add("Authorization", "Bearer " + SessionHelper.TokenInfo.access_token);
                    HttpResponseMessage response = httpClient1.PostAsync(method + "/" + id, content).Result;
                }
            }
        }

        //Token üzerindeki kimlik bilgilerinin alınmasını sağlar.
        public T GetSingle(string method)
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
                httpClient1.BaseAddress = new Uri(url);
                httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient1.DefaultRequestHeaders.Add("Authorization", "Bearer " + SessionHelper.TokenInfo.access_token);
                HttpResponseMessage response = httpClient1.GetAsync(method).Result;
                var message = response.Content.ReadAsStringAsync().Result;
                var newData = JsonConvert.DeserializeObject<T>(JsonConvert.DeserializeObject<string>(message));
                return newData;
            }
        }
    }
}
