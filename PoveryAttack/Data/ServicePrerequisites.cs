using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoveryAttack
{
    public class ServicePrerequisites
    {

        public bool PhysicalAddress { get; set; }
        public bool IdRequired { get; set; }
        /// <summary>
        /// Use this if the IdRequired is true
        /// </summary>
        public string IdType { get; set; }
        public bool OneDoorAssessment { get; set; }
        /// <summary>
        /// Services Priority Decision Assistance Tool
        /// </summary>
        public bool SPDAT { get; set; }
        public bool MedicalInsurace { get; set; }
        public bool BreathalyzerTest { get; set; }
        public bool DrugTest { get; set; }
        public bool PregnancyTest { get; set; }
        public decimal AnnualIncomeBelow { get; set; }
        public int CurrentlyEmployedMinHours { get; set; }
        public bool MembershipWithOrganization { get; set; }
        public string OtherMembership { get; set; }
        public bool ServiceProgramAttendance { get; set; }
        public bool Other { get; set; }
        /// <summary>
        /// Use if Other is selected
        /// </summary>
        public string OtherName { get; set; }

    }
}
