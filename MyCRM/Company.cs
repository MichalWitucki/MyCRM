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
        private int _voivodeshipId;

        public int VoivodeshipId
        {
            get { return _voivodeshipId; }
            set
            {
                if (value > 0 && value < 17)
                {
                    _voivodeshipId = value;
                }
                else
                    Console.WriteLine("Błędne Id województwa. Województwo nie zostało zmienione.");
            }
        }

        public string City { get; set; }
        public string Street { get; set; }
        public string Name { get; set; }
        public List<Person> Staff { get; set; }

        public Company()
        {
            Staff = new List<Person>();
        }
    }
}
