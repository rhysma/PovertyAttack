using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovertyAttack.Core.Models
{
    public class ServiceExemptions
    {

        public bool NoId { get; set; }
        public bool Unemployed { get; set; }
        public bool Uninsured { get; set; }
        public decimal AnnualIncomeAbove { get; set; }
        public bool InsuredOrMedicaid{ get; set; }
        public bool LGBT { get; set; }
        public bool PetOwners { get; set; }
        public bool UnderTheInfluence { get; set; }
        public bool SubstanceAbusers { get; set; }
        public bool SexOffenders { get; set; }
        public bool Felons { get; set; }
        public bool NonMembersOfOraginization { get; set; }
        public bool Other { get; set; }
        public bool OtherName { get; set; }
    }
}
