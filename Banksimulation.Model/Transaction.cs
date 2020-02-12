using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.Model
{
    [Serializable]
    public class Transaction
    {
        public string TransactionId { get;  set; }
        public double TransactionAmount { get;  set; }
        public string TransactionType { get; set; }
        public string DestinationBankId { get;  set; }
        public string DestinationAccountId { get;  set; }
        public string SourceBankId { get;  set; }
        public string SourceAccountId { get;  set; }
        public double TransactionServiceCharge { get;  set; }
        public double TransactionTransferCharge { get;  set; }
        public string TransactionDate { get;  set; }

       
    }
}
