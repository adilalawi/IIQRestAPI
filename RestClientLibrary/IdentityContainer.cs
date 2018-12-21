using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLibrary
{
    public class IdentityContainer
    {
        public ViewableIdentityAttributes viewableIdentityAttributes { get; set; }
        public List<AssignedRole> assignedRoles { get; set; }
        public List<string> listAttributes { get; set; }

        public class ViewableIdentityAttributes
        {
            public string Region { get; set; }
            public string Email { get; set; }
            public string Manager { get; set; }
            public string Department { get; set; }
            public string Nachname { get; set; }
            public string Vorname { get; set; }
}

public class AssignedRole
{
    public string id { get; set; }
    public string description { get; set; }
    public object assigner { get; set; }
    public object date { get; set; }
    public string displayName { get; set; }
}

    }
}
