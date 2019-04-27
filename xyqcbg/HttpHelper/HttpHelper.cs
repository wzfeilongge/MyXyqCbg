using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace xyqcbg.HttpHelper
{
    public class HttpHelper
    {
        public static TResponse PostAsync<TRequest, TResponse>(string url, TRequest request)
        {
            var list = new List<KeyValuePair<string, string>>();
            foreach (System.Reflection.PropertyInfo p in request.GetType().GetProperties())
            {
                if (p.GetValue(request) != null)
                {
                    list.Add(new KeyValuePair<string, string>(p.Name, p.GetValue(request).ToString()));
                }
            }

            var content = new FormUrlEncodedContent(list);//new Dictionary<string,string>(){{"",json}};

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
            //var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            var client = new HttpClient();//传递参数handler

            var resp = client.PostAsync(url, content).Result;
            var body = resp.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<TResponse>(body);

            return result;
        }

        public static TResponse PutAsync<TRequest, TResponse>(string url, TRequest request)
        {
            var list = new List<KeyValuePair<string, string>>();
            foreach (System.Reflection.PropertyInfo p in request.GetType().GetProperties())
            {
                if (p.GetValue(request) != null)
                {
                    list.Add(new KeyValuePair<string, string>(p.Name, p.GetValue(request).ToString()));
                }
            }

            var content = new FormUrlEncodedContent(list);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
            var client = new HttpClient();

            var resp = client.PutAsync(url, content).Result;
            var body = resp.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<TResponse>(body);

            return result;
        }

        public static TResponse DeleteAsync<TResponse>(string url)
        {
            var client = new HttpClient();
            var resp = client.DeleteAsync(url).Result;
            var body = resp.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<TResponse>(body);

            return result;
        }

        public static TResponse GetAsync<TRequest, TResponse>(string url, TRequest request)
        {
            var list = new List<KeyValuePair<string, string>>();
            StringBuilder urlSb = new StringBuilder();
            urlSb.Append("?");
            foreach (System.Reflection.PropertyInfo p in request.GetType().GetProperties())
            {
                if (p.GetValue(request) != null&&p.GetValue(request).ToString()!="0")
                {
                    urlSb.Append(p.Name).Append("=").Append(p.GetValue(request).ToString()).Append("&");
                }
                //else
                //{
                //    urlSb.Append(p.Name).Append("=").Append("&");
                //}
            }

            url = (url + urlSb.ToString()).TrimEnd('&');
            var client = new HttpClient();
            var resp = client.GetAsync(url).Result;
            var body = resp.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<TResponse>(body);

            return result;
        }

        public static TResponse GetAsync<TResponse>(string url)
        {
            var list = new List<KeyValuePair<string, string>>();
            var client = new HttpClient();

            var resp = client.GetAsync(url).Result;
            var body = resp.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<TResponse>(body);

            return result;
        }
    }
}
