using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ClockIn.Client.Common;
using ClockIn.Client.IDAL;

namespace ClockIn.Client.DAL
{   
    public class WebDataBase : IWebDataBase
    {
        private readonly string domain = "http://localhost:5260/";

        public Task<string> PostDatas(string uri, Dictionary<string,HttpContent> contents)
        {
            using (HttpClient client = new HttpClient())
            {
                var resp = client.PostAsync($"{domain}{uri}", this.GetFormData(contents)).GetAwaiter().GetResult();
                return resp.Content.ReadAsStringAsync();
            }
        }


        public MultipartFormDataContent GetFormData(Dictionary<string, HttpContent> contents)
            {
            var postContent = new MultipartFormDataContent();
            string boundary = string.Format($"--{DateTime.Now.Ticks.ToString("x")}");

            postContent.Headers.Add("ContentType", $"multipart/form-data, boundary={boundary}");

            foreach (var item in contents)
            {
                postContent.Add(item.Value, item.Key);
            }

            return postContent;
        }

        // Get方式进行请求

        public Task<string> GetDatas(string uri)
        {
            using (var client = new HttpClient())
            {
                var resp = client.GetAsync($"{domain}{uri}").GetAwaiter().GetResult();
                return resp.Content.ReadAsStringAsync();
            }
        }
    }
}
