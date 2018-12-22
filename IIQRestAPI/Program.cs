using RestClientLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IIQRestAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");

            RestClientHelper restClient = new RestClientHelper("rest/", "spadmin", "admin");

            var isLoggedin = restClient.Login();
            restClient.GetConfig();
            Console.WriteLine(isLoggedin);

            // Get identity info
            restClient.GetIdentity("1");
            // Get Identity links
            restClient.GetIdentityLinks("1");
            // Create Identity
            Identity identity = new Identity();
            identity.firstname = "adli";
            identity.lastname = "adli";
            identity.name = "adli adli";
            identity.displayName = "adli Khab";
            identity.email = "adli@la.de";

            restClient.CreateUpdateIdentity(identity, HttpVerb.POST);

            Console.ReadKey();
        }
    }
}
