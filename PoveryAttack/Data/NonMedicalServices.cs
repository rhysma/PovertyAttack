using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoveryAttack
{
    class NonMedicalServices
    {
        internal class ShelterServices
        {
            public bool Temporary { get; set; }

            public bool LongTerm { get; set; }

            public int Capacity { get; set; }

            public string MaxDuration { get; set; }

            public  DateTime Curfew { get; set; }

            public bool NoCost { get; set; }

            public double ShelterCost { get; set; }

            public string Details { get; set; }
        }

        public List<ShelterServices> ShelterServiceList { get; set; }

        public bool DropInFacility { get; set; }

        public bool HousingAssistance { get; set; }

        public bool ReHomingServices { get; set; }

        public bool TransportationAssistance { get; set; }

        public bool EmploymentServices { get; set; }

        public bool AdvocateSupport { get; set; }

        public bool Clothing { get; set; }

        public bool PersonalHygiene { get; set; }

        public bool PhoneAccess { get; set; }

        public bool InternetAccess { get; set; }

        public bool UtilitiesAssistance { get; set; }

        public bool CanUseMailAddress { get; set; }

        public bool ChildcareAssistance { get; set; }

        public List<string> FreeStoreItems { get; set; }

        public bool LaundryFree { get; set; }

        public double LaundryCost { get; set; }

        public bool ShowerFree { get; set; }

        public double ShowerCost { get; set; }

        public List<ServiceTime> MealsServed { get; set; }

        public List<ServiceTime> FoodPantry { get; set; }

        public string CrisisHotline { get; set; }

        public string FinancialAssistanceDetails { get; set; }

        public bool PetFood { get; set; }

        public bool PetShelter { get; set; }

        public bool VetServices { get; set; }
    }
}
