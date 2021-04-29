using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Sea.Core.Util.Helper
{
    /// <summary>
    /// http请求帮助类
    /// </summary>
    public class HttpHelper
    {
        static JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            MaxDepth = 64,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };

        static JsonSerializerOptions jsonSerializerOptionsCreate = new JsonSerializerOptions
        {
            PropertyNamingPolicy =new LowerCaseNamingPolicy(),
            MaxDepth = 64,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            IgnoreNullValues=true,

        };



        public static string Get(string serviceAddress)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }
        public static async Task<string> GetAsync(string serviceAddress)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = await myStreamReader.ReadToEndAsync();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }


        public static async Task<T> GetAsync<T>(string serviceAddress)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //Stream myResponseStream = response.GetResponseStream();
            //StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            //string retString = await myStreamReader.ReadToEndAsync();
            //myStreamReader.Close();
            //myResponseStream.Close();
            //T t = JsonSerializer.Deserialize<T>(retString, jsonSerializerOptions);     
            //myStreamReader.Close();
            //myResponseStream.Close();

            T t = await JsonSerializer.DeserializeAsync<T>(response.GetResponseStream(), jsonSerializerOptions);
            return await Task.FromResult(t);
        }



        public static string Post(string serviceAddress, string strContent = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);
            request.Method = "POST";
            request.ContentType = "application/json";
            //判断有无POST内容
            if (!string.IsNullOrWhiteSpace(strContent))
            {
                using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
                {
                    dataStream.Write(strContent);
                    dataStream.Close();
                }
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码  
            }
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
            string retString = reader.ReadToEnd();
            return retString;
        }

        public static async Task<string> PostAsync(string serviceAddress, string strContent = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);
            request.Method = "POST";
            request.ContentType = "application/json";
            //判断有无POST内容
            if (!string.IsNullOrWhiteSpace(strContent))
            {
                using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
                {
                    dataStream.Write(strContent);
                    dataStream.Close();
                }
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码  
            }
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
            string retString = await reader.ReadToEndAsync();
            return retString;
        }

        public static async Task<T> PostAsync<T>(string serviceAddress, string strContent = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);
            request.Method = "POST";
            request.ContentType = "application/json";
            //判断有无POST内容
            if (!string.IsNullOrWhiteSpace(strContent))
            {
                using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
                {
                    dataStream.Write(strContent);
                    dataStream.Close();
                }
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码  
            }
            T t = await JsonSerializer.DeserializeAsync<T>(response.GetResponseStream(), jsonSerializerOptions);
            return await Task.FromResult(t);
        }


        /// <summary>
        /// post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="serviceAddress"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static async Task<T> PostAsync<T, K>(string serviceAddress, K k = null) where K : class
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);
            request.Method = "POST";
            request.ContentType = "application/json";

            if (k != null)
            {
                string strContent = JsonSerializer.Serialize(k, jsonSerializerOptions);
                //判断有无POST内容
                if (!string.IsNullOrWhiteSpace(strContent))
                {
                    using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream(), Encoding.UTF8))
                    {
                        dataStream.Write(strContent);
                        dataStream.Close();
                    }
                }
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            T t = await JsonSerializer.DeserializeAsync<T>(response.GetResponseStream(), jsonSerializerOptions);
            return await Task.FromResult(t);
        }





        /// <summary>
        /// get请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<T> GetHttpAsync<T>(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage result = await client.GetAsync(url);
            string resultStr = await result.Content.ReadAsStringAsync();
            T t =JsonSerializer.Deserialize<T>(resultStr, jsonSerializerOptions);
            return await Task.FromResult(t);
        }

        /// <summary>
        /// json格式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="url"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static async Task<T> PostHttpAsync<T, K>(string url, K k = null) where K : class
        {
            HttpClient client = new HttpClient();
            string content = string.Empty;
            if (k != null)
            {
                content = JsonSerializer.Serialize(k, jsonSerializerOptionsCreate);
            }
            HttpResponseMessage result = await client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));
            string resultStr = await result.Content.ReadAsStringAsync();
            T t = JsonSerializer.Deserialize<T>(resultStr, jsonSerializerOptions);
            return await Task.FromResult(t);
        }


    }


}
