using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMSWeb.BusinessEntities;
using  LMSWeb.BLL;
using System.Net;
using Newtonsoft.Json;
using System.Configuration;

namespace LMSWeb
{
    public class WebAPIHelper
    {
        string baseURL = ConfigurationManager.AppSettings["serviceurl"].ToString();
        bool status = false;
        public bool SaveCustomer(CustomerBusinessEntity customer)
        {
            
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers["authenticationtoken"] = Guid.NewGuid().ToString();
            string serialisedData = JsonConvert.SerializeObject(customer);

            // build save url method
            string url = baseURL + "Customer/Save";
             var response= client.UploadString(url, serialisedData);
            status = JsonConvert.DeserializeObject<Boolean>(response);
            return status;
        }
    }
}