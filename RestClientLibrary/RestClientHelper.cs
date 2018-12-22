using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace RestClientLibrary
{
    public class RestClientHelper
    {
        private readonly JsonDeserializer deserializer;

        private readonly string baseUrl;
        private readonly string username;
        private readonly string passowrd;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl">jira baseurl without the path for rest actions</param>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        public RestClientHelper(string endPoint, string username, string password)
        {
            this.baseUrl = (new Uri(Data.BASE_URL) + endPoint).ToString();
            this.username = username;
            this.passowrd = password;

            deserializer = new JsonDeserializer();
        }



        /// <summary> create a standard request </summary>
        /// <param name="path">path to identify the intended uri</param>
        /// <param name="method">request methods</param>

        public RestRequest Request(string path, Method method)
        {
            var request = new RestRequest { Method = method, Resource = path, RequestFormat = DataFormat.Json };
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(

                String.Format("{0}:{1}", username, passowrd)
                )));
            return request;
        }

        /// <summary> server response </summary>
        /// <param name="request"> passing the returning request</param>
        public IRestResponse Response(RestRequest request)
        {
            var client = new RestClient(baseUrl);
            var response = client.Execute(request);
            if (response.ErrorException != null)
            {
                string message = "the server response is returned an error";
                var exception = new ApplicationException(message, response.ErrorException);
                throw exception;
            }

            return response;
        }

        // Log to iiq
        public HttpStatusCode Login()
        {
            string path = string.Format("ping");
            var request = Request(path, Method.GET);
            request.AddHeader("ContentType", "application/json");

            var response = Response(request);
            return response.StatusCode;
        }

        // Get the iiq configuration
        public void GetConfig()
        {
            string path = string.Format("configuration?attributeName=certificationEmailTemplate");
            var request = Request(path, Method.GET);
            request.AddHeader("ContentType", "application/json");

            var response = Response(request);
            var content = response.Content;
        }

        // Get the identity info
        public void GetIdentity(String identityID)
        {
            string path = string.Format("identities/{0}", identityID);
            var request = Request(path, Method.GET);
            request.AddHeader("ContentType", "application/json");

            var response = Response(request);
            var content = response.Content;
            var des = deserializer.Deserialize<IdentityContainer>(response);
        }

        // Get the assigned account to a specified identity
        public void GetIdentityLinks(string identityID)
        {
            string path = string.Format("identities/{0}/links/?includeLinkState=true", identityID);
            var request = Request(path, Method.GET);
            request.AddHeader("ContentType", "application/json");

            var response = Response(request);
            var content = response.Content;
            var des = deserializer.Deserialize<LinksContainer>(response);


        }

        // Create a new identity
        public void CreateIdentity(Identity identity)
        {
            string path = string.Format("identities");
            var request = Request(path, Method.POST);
            request.AddHeader("ContentType", "application/json");

            var newIdentity = new Dictionary<string, object>();

            if (identity.firstname != null)
            {
                newIdentity.Add("firstname", identity.firstname);
            }
            if (identity.lastname != null)
            {
                newIdentity.Add("lastname", identity.lastname);
            }
            if (identity.name != null)
            {
                newIdentity.Add("name", identity.name);
            }
            if (identity.displayName != null)
            {
                newIdentity.Add("displayName", identity.displayName);
            }
            if (identity.email != null)
            {
                newIdentity.Add("email", identity.email);
            }

            request.AddBody(new { newIdentity });
            var response = Response(request);
            var des = deserializer.Deserialize<Identity>(response);

        }
    }
}

