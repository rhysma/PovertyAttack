using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovertyAttack.Core.Models
{

    public enum DaysOfWeek { Na = 0, Sunday = 1, Monday = 2, Tuesday = 3, Wednesday = 4, Thursday = 5, Friday = 6, Saturday = 7};

    public class ServiceTime
    {
        public DaysOfWeek Day { get; set; }
        public int OpenHour { get; set; }
        public int CloseHour { get; set; }
    }

    public class Location
    {
        public Address PhysicalLocation { get; set; }
        public List<ServiceTime> ServiceTimes {get;set;}
    }
}
