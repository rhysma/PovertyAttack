using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoveryAttack
{
    class MedicalServices
    {
        public bool GeneralHealthcare { get; set; }

        public bool Medicaid { get; set; }

        public bool WIC { get; set; }

        public bool PrescriptionDrugs { get; set; }

        public bool Dental { get; set; }

        public bool WomensHealth { get; set; }

        public string CounselingType { get; set; }

        public bool RespiteCare { get; set; }

        public bool MentalHealthInpatient { get; set; }

        public bool MentalHealthOutpatient { get; set; }

        public bool AlcoholAbuseInpatient { get; set; }

        public bool AlcoholAbuseOutpatient { get; set; }

        public bool DrugAbuseInpatient { get; set; }

        public bool DrugAbuseOutpatient { get; set; }

        public bool TreatmentFree { get; set; }

        public bool TreatmentSlidingScale { get; set; }

        public bool TreatmentInsCoPay { get; set; }
    }
}
