using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoveryAttack
{
    class CommunityResources
    {
        public bool Volunteers { get; set; }

        public bool FinancialDonations { get; set; }

        public bool PhsyicalDonations { get; set; }

        public bool GovFunding { get; set; }

        public bool Grants { get; set; }

        public int FullTimeCount { get; set; }

        public int PartTimeCount { get; set; }

        public int VolunteerCount { get; set; }

        public List<string> OrganizationNeeds { get; set; }
    }
}
