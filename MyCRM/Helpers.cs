﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCRM
{
    public static class Helpers
    {
        public static Dictionary<int, string> voivodeships = new Dictionary<int, string>
        {
            {0, "Brak" },
            {1, "Dolnośląskie" },
            {2, "Kujawsko-Pomorskie" },
            {3, "Lubelskie"},
            {4, "Lubuskie" },
            {5, "Łódzkie"},
            {6, "Małopolskie"},
            {7 , "Mazowieckie"},
            {8 , "Opolskie"},
            {9 , "Podkarpackie"},
            {10 , "Podlaskie"},
            {11 , "Pomorskie"},
            {12 , "Śląskie"},
            {13 , "Świętokrzyskie"},
            {14 , "Warmińsko-Mazurskie"},
            {15 , "Wielkopolskie"},
            {16 , "Zachodniopomorskie" }
        };

        public static Dictionary<int, string> userRoles = new Dictionary<int, string>
        {
            {0, "Administrator" },
            {1, "SalesRep" },
            {2, "User" },

        };

        public static Dictionary<int, string> statuses = new Dictionary<int, string>
        {
            {0, "Nowy" },
            {1, "W opracowaniu" },
            {2, "Planowany" },
            {3, "Zgłoszony" },
            {4, "Zrealizowamnu" },
            {5, "Nie dotyczy" },
            {6, "Utracony" },
        };


        public static int getId()
        {
            var chosenId = Console.ReadLine();
            if (int.TryParse(chosenId, out int id))
                return id;
            else
                return 0;
        }

    }
}
