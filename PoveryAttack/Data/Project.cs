using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoveryAttack
{
    public class Project
    {

        public string ProjectName { get; set; }
        public string ContactName { get; set; }
        /// <summary>
        /// NOTE(TREVOR):
        /// In order to simpify this on the front end, this would just be 
        /// preferred contact method, this way they can just enter whatever 
        /// works for them without having to work the UI around some weird 
        /// object.
        /// </summary>
        public string ContactInfo { get; set; }

    }
}
