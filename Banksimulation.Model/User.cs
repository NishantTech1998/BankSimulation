using System;
using System.Collections.Generic;
using System.Text;

namespace BankSimulation.Model
{
    [Serializable]
    abstract public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PanNumber { get; set; }
        public string Password { get; set; }
        public DateTime Dob { get; set; }
        public long ContactNumber { get; set; }
        public Address address = new Address();
        
    }
}