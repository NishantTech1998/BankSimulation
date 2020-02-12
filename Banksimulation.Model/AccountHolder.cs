
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.Model
{
    [Serializable]
    public class AccountHolder:User
    {
        public string AccountHolderId { get; set; }
       
    }
}
