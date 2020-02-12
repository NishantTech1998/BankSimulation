using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.Model
{
    [Serializable]
    public class BankStaff:User
    {
        public string BankStaffId { get; set; }
        public string BankStaffRole { get; set; }
        
    }
}
