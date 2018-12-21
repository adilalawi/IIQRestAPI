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
            identity.firstname = "Aymanmlm";
            identity.lastname = "lll";
            identity.name = "Ayman lllm";
            identity.displayName = "Aymalmmnn Khab";
            identity.email = "email@la.de";

            restClient.CreateIdentity(identity);

            Console.ReadKey();
        }
    }
}
