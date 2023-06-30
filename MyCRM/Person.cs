using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCRM
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Mail { get; set; }

        private int _userRoleId;

        public int UserRoleId
        {
            get { return _userRoleId; }
            set 
            {
                if (value > 0 && value <= Helpers.userRoles.Count)
                    _userRoleId = value;
                else
                    Console.WriteLine("Błędne Id roli.");
            }
        }

    }
}
