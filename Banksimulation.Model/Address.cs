using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.Model
{
    [Serializable]
    public class Address
    {
        public string addressLine1;
        public string addressLine2;
        public string city;
        public string state;
        public string pincode;
    }
}
