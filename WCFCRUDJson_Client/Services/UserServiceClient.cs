using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCFCRUDJson_Client.Models;
using System.Net;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace WCFCRUDJson_Client.Services
{
    public class UserServiceClient
    {
        private readonly string BASE_URI = "http://localhost:64171/CRUDJson.svc/";

        public List<User> FindAll()
        {
            try
            {
                WebClient webClient = new WebClient();
                string json = webClient.DownloadString(BASE_URI + "findall");
                var jsJson = new JavaScriptSerializer();
                return jsJson.Deserialize<List<User>>(json);
            }
            catch
            {
                return null;
            }
        }

        public User Find(string id)
        {
            try
            {
                string url = string.Format(BASE_URI + "Find/{0}", id);
                WebClient webClient = new WebClient();
                string json = webClient.DownloadString(url);
                var jsJson = new JavaScriptSerializer();
                return jsJson.Deserialize<User>(json);
            }
            catch
            {
                return null;
            }
        }

        private bool _generalSend(User usr, string serviceMethod, string httpMethod)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(User));
                MemoryStream memoryStream = new MemoryStream();
                ser.WriteObject(memoryStream, usr);
                string data = Encoding.UTF8.GetString(memoryStream.ToArray(), 0, (int)memoryStream.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadString(BASE_URI + serviceMethod, httpMethod.ToUpper(), data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(User usr)
        {
            return _generalSend(usr, "create", "POST");
        }

        public bool Edit(User usr)
        {
            return _generalSend(usr, "edit", "PUT");
        }

        public bool Delete(User usr)
        {
            return _generalSend(usr, "delete", "DELETE");
        }
    }
}