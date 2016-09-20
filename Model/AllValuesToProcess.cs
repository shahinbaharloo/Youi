using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youi.Model
{
    class AllValuesToProcess
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetName { get; set; }



        public AllValuesToProcess(string firstName, string lastName, string address, string phoneNumber, string streetName)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            StreetName = streetName;
        }
    }
}
