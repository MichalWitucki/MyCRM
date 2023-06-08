using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCRM
{
    public class Project
    {
        public int Id { get; set; }
        public string Voivodeship { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Status { get; set; }
        public string Rep { get; set; }

        //public string Contractor { get; set; }
        //public string IssuingAgency { get; set; }
        //public string EngineeringOffice { get; set; }
    }
}
