using System;
using System.Collections.Generic;
using System.Linq;
using BankSimulation.Model;

namespace BankSimulation.Data.DataServices
{
   public class TransactionDataService
    {
        public Account GetAccountByNumber(string accountNumber)
        {

            if (MasterBank.currentBank.accounts.Count > 0)
            {
                Account account = MasterBank.currentBank.accounts.FirstOrDefault(acc => acc.AccountNumber == accountNumber);
                if (account != null)
                    return account;
                else
                    return null;
            }
            else
                return null;
        }

        public List<Transaction> GetTransactionByAccountNumber(string accountNumber)
        {
            return GetAccountByNumber(accountNumber).transactions;
        }

    }
}
