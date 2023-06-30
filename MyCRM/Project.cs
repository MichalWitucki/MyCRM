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

        private int _voivodeshipId;

        public int VoivodeshipId
        {
            get { return _voivodeshipId; }
            set
            {
                if (value > 0 && value < 17)
                    _voivodeshipId = value;
                else
                    Console.WriteLine("Błędne Id województwa. Województwo nie zostało zmienione.");
            }
        }
        public string City { get; set; }
        public string Street { get; set; }
        public int StatusId { get; set; }
        public int RepId { get; set; }
        public int ContractorId { get; set; }
        public int IssuingAgencyId { get; set; }
        public int EngineeringOfficeId { get; set; }
    }
}
