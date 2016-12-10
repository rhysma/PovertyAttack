using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovertyAttack.Core.Models
{

    public class TargetAudience
    {
        public bool UnshelteredHomeless { get; set; }
        public bool ShelteredHomeless { get; set; }
        public bool HomelessnessPrevention { get; set; }
        public bool JobSeekers { get; set; }
        public bool FoodInsecure { get; set; }
        public bool AbuseVictims { get; set; }
        public bool WomenSpecific { get; set; }
        public bool MenSpecific { get; set; }
        public bool FamilySpecific { get; set; }
        public bool YouthSpecific { get; set; }
        public bool PetOwners { get; set; }
        public bool AlcoholAbuseTreatmentCounseling { get; set; }
        public bool DrugAbuseTreatmentCounseling { get; set; }
        public bool MentalHealthTreatmentCounseling { get; set; }
        public bool LGBT { get; set; }
        public bool Veterans { get; set; }
        public bool DisabledPersons { get; set; }
        public bool UninsuredPersons { get; set; }
        public bool Other { get; set; }
        /// <summary>
        /// Use if other is selected
        /// </summary>
        public string OtherName { get; set; }
    }

}
