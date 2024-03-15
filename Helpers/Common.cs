using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using UserManagement.Pages;
using static System.Net.Mime.MediaTypeNames;

namespace UserManagement.Helpers
{
    public static class Common
    {
        private static readonly log4net.ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static readonly string BaseAPI = Constants.BaseAPI;
        public static string DoPostWebRequest(string Url, string body)
        {
            string jsonresponse = "";
            try
            {
                Url = BaseAPI + Url;
                Logger.Info("Request API : " + Url);
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(Url);
                Encoding encoding = new UTF8Encoding();

                byte[] data = encoding.GetBytes(body);

                httpWReq.ProtocolVersion = HttpVersion.Version11;
                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/json";

                httpWReq.ContentLength = data.Length;


                Stream stream = httpWReq.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();

                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                string s = response.ToString();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string temp = null;
                while ((temp = reader.ReadLine()) != null)
                {
                    jsonresponse += temp;
                }
                Logger.Info("Request Response : " + jsonresponse);
                return jsonresponse;
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    //Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        jsonresponse = reader.ReadToEnd();
                        Logger.Error(jsonresponse);
                    }
                }
                return jsonresponse;
            }
        }

        public static string DoGetWebRequest(string Url)
        {
            try
            {
                Url = BaseAPI + Url;
                Logger.Info("Request API : " + Url);
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(Url);
                Encoding encoding = new UTF8Encoding();

                httpWReq.ProtocolVersion = HttpVersion.Version11;
                httpWReq.Method = "GET";

                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                string s = response.ToString();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                String jsonresponse = "";
                String temp = null;
                while ((temp = reader.ReadLine()) != null)
                {
                    jsonresponse += temp;
                }
                Logger.Info("Request Response : " + jsonresponse);
                return jsonresponse;
            }
            catch (WebException e)
            {

                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    //Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        string text = reader.ReadToEnd();
                        Logger.Error(text);
                    }
                }
                return null;
            }
        }
    }
}