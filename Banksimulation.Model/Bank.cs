using System;
using System.Collections.Generic;
using System.Text;

namespace BankSimulation.Model
{
    [Serializable]
    public class Bank
    {
        public string BankId { get;  set; }
        public string Currency { get;  set; }
        public string Name { get;  set; }
        public List<CurrencyExchangeRate> CurrencyExchangeList;
        public TransferCharge SameTransferCharge;
        public TransferCharge OtherTransferCharge;
        public List<BankStaff> bankStaffList;
        public List<Account> accounts;
        public List<AccountHolder> accountHolders;

        public Bank()
        {
            bankStaffList = new List<BankStaff>();
            accounts = new List<Account>();
            CurrencyExchangeList = new List<CurrencyExchangeRate>();
            SameTransferCharge = new TransferCharge();
            OtherTransferCharge = new TransferCharge();
        }

    }
}
