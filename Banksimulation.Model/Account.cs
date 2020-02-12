using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.Model
{
    [Serializable]
    public class Account
    {
        public string AccountId { get;  set; }
        public string AccountNumber { get;  set; }
        public string OpeningDate { get;  set; }
        public double Balance { get;  set; }
        public string AccountType { get;  set; }
        public string AccountHolderId { get; set; }
        public List<Transaction> transactions = new List<Transaction>();

    }
}
