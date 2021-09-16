using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace PixlParkTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly string PublicKey = "38cd79b5f2b2486d86f562e3c43034f8";
        private readonly string PrivateKey = "8e49ff607b1f46e1a5e8f6ad5d312a80";
      
        private string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
        private string GetRequestToken()
        {
            string RequestToken = "";
            WebRequest request = WebRequest.Create("http://api.pixlpark.com/oauth/requesttoken");
            WebResponse response = request.GetResponse();

            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                string line;
                if ((line = stream.ReadLine()) != null)
                {
                    var translation = JsonConvert.DeserializeObject<MyRequestToken>(line);
                    RequestToken = translation.RequestToken;
                }
            }
            return RequestToken;
        }
        private string GetAccessToken()
        {
            string RequestToken = GetRequestToken();
            string AccessToken = "";
            string Password = Hash(RequestToken + PrivateKey);
            WebRequest request = WebRequest.Create("http://api.pixlpark.com/oauth/accesstoken?oauth_token="
                + RequestToken + "&grant_type=api&username=" + PublicKey
                + "&password=" + Password);

            WebResponse response = request.GetResponse();

            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                string line;
                if ((line = stream.ReadLine()) != null)
                {
                    var translation = JsonConvert.DeserializeObject<MyAccessToken>(line);
                    AccessToken = translation.AccessToken;
                }
            }
            return AccessToken;
        }

        [HttpGet]
        public Orders GetOrderList()
        {
            //get order list
            string AccessToken = GetAccessToken();
            WebRequest request = WebRequest.Create("http://api.pixlpark.com/orders?oauth_token=" + AccessToken);
            WebResponse response = request.GetResponse();

            Orders Orders = null;
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                string line;
                if ((line = stream.ReadLine()) != null)
                {
                    var translation = JsonConvert.DeserializeObject<Orders>(line);
                    Orders = translation;
                }
            }
            return Orders;
        }
    }
}
