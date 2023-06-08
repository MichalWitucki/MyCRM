using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyCRM
{
    public class Company
    {
        public int Id { get; set; }
        public Voivodeship VoivodeshipId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Name { get; set; }
        public List<Person> Staff { get; set; }


    }
}
