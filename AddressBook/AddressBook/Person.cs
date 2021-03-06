﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class Person
    {
        public string Name { get; set; } 
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string Notes { get; set; }

        private bool PrivateEcample { get; set; }

        public Person() //Constructor
        {
            Initialize();
        }

        ~Person() //Destructor
        {

        }


        public void Initialize()
        {
            PrivateEcample = false;

            Name = "New person";
            Birthday = DateTime.Today;
        }




    }
}
