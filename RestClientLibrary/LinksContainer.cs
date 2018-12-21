using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLibrary
{
    public class LinksContainer
    {
        public bool complete { get; set; }
        public int count { get; set; }
        public object errors { get; set; }
        public bool failure { get; set; }
        public object metaData { get; set; }
        public List<Link> objects { get; set; }
        public object requestID { get; set; }
        public bool retry { get; set; }
        public int retryWait { get; set; }
        public string status { get; set; }
        public bool success { get; set; }
        public object warnings { get; set; }

        public class Link
        {

            public string id { get; set; }
            public string nativeIdentity { get; set; }
            [JsonProperty("application-name")]
            public string applicationName { get; set; }
            [JsonProperty("application-type")]
            public string applicationType { get; set; }
            [JsonProperty("application-id")]
            public string applicationID { get; set; }
            [JsonProperty("application-featuresString")]
            public string applicationFeaturesString { get; set; }
            public string displayName { get; set; }

    }
    }


}
