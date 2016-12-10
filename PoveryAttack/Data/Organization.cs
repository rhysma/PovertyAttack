using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoveryAttack
{

    public enum ContactPref {  Call = 0, Email = 1, InPersonWalkIn = 2, WebsiteSocial = 3 };
    public enum OrganizationType { NonProfit = 0, ForProfit = 1, NotForProfit = 2, GovernmentAgency = 3 };

    public class Organization
    {
        public string OrganizationName { get; set; }
        public string ProgramName { get; set; }
        public string Director { get; set; }
        public string Email { get; set; }
        public string WebsiteUrl { get; set; }
        public ContactPref ContactPreference { get; set; }
        public OrganizationType Type { get; set; }

    }
}
