using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovertyAttack.Core
{
    class ConnectedOrganization
    {   
        /// <summary>
        /// List of other organizations worked/coordinated with.
        /// </summary>
        public List<Organization> ConnectedOrganizations { get; set; }         
    }
}
