using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BankSimulation.Model;

namespace BankSimulation.Data.DataServices
{
    public class AccountDataService
    {
        public AccountHolder GetAccountHolderById(string accountHolderId)
        {
            if(MasterBank.currentBank.accountHolders==null)
            {
                MasterBank.currentBank.accountHolders = new List<AccountHolder>();
                return null;
            }
            else if (MasterBank.currentBank.accountHolders.Count > 0)
            {
                AccountHolder accountHolder = MasterBank.currentBank.accountHolders.FirstOrDefault(accHolder => accHolder.AccountHolderId == accountHolderId);
                return accountHolder;
              
            }
            else
                return null;
        }

        public Account GetAccountByUserId(string accountHolderId)
        {
            if (MasterBank.currentBank.accounts.Count > 0)
            {
                Account account = MasterBank.currentBank.accounts.FirstOrDefault(acc => acc.AccountHolderId == accountHolderId);
                return account;
            }
            else
                return null;
        }

        public Account GetAccountByAccountId(string accountId)
        {
            if (MasterBank.currentBank.accounts.Count > 0)
            {
                Account account = MasterBank.currentBank.accounts.FirstOrDefault(acc => acc.AccountId == accountId);
                return account;
            }
            else
                return null;
        }

        public Account GetAccountByNumber(string number)
        {
            if (MasterBank.currentBank.accounts.Count > 0)
            {
                Account account = MasterBank.currentBank.accounts.FirstOrDefault(acc => acc.AccountNumber == number);
                return account;
            }
            else
                return null;
        }

        public void AddAccount(AccountHolder accountHolder, Account account)
        {
            MasterBank.currentBank.accounts.Add(account);
            MasterBank.currentBank.accountHolders.Add(accountHolder);
            MasterBank.SaveCurrentState();
        }

        public void UpdateAccount(AccountHolder accountHolder)
        {
            int index = -1;
            foreach (AccountHolder accountData in MasterBank.currentBank.accountHolders)
            {
                if (accountData.AccountHolderId == accountHolder.AccountHolderId)
                    index = MasterBank.currentBank.accountHolders.IndexOf(accountData);
                else
                    throw new Exception("ID NOT FOUND");
            }
            MasterBank.currentBank.accountHolders.Insert(index, accountHolder);
            MasterBank.SaveCurrentState();
            MasterBank.currentBank.accountHolders.RemoveAt(index);
        }

        public bool DeleteAccount(string accountHolderId)
        {
            if (MasterBank.currentBank.accountHolders.Count > 0)
            {
                AccountHolder accountHolder = MasterBank.currentBank.accountHolders.FirstOrDefault(accHolder => accHolder.AccountHolderId == accountHolderId);
                Account account = MasterBank.currentBank.accounts.FirstOrDefault(acc => acc.AccountHolderId == accountHolderId);
                if (account != null)
                {
                    MasterBank.currentBank.accountHolders.Remove(accountHolder);
                    MasterBank.currentBank.accounts.Remove(account);
                    MasterBank.SaveCurrentState();
                    return true;
                }
                return false;
            }
            return false;
        }

        public List<Account> GetAccountList()
        {
            if (MasterBank.currentBank.accounts.Count > 0)
            {
                return MasterBank.currentBank.accounts;
            }
            else
                return null;
        }

        public void Credit(Account account, double amount)
        {
            account.Balance=account.Balance + amount;
        }

        public void Debit(Account account, double amount)
        {
            if (account.Balance < amount)
            {
                throw new Exception("LOW BALANCE");
            }
            else
            {
                account.Balance=account.Balance - amount;
            }
        }

        public void Deposit(Account currentActiveAccount, double amount)
        {
            Credit(currentActiveAccount, amount);

        }

        public void Withdraw(Account currentActiveAccount, double amount)
        {
            Debit(currentActiveAccount, amount);
        }

        public void SameBankTransfer(Account sender, Account receiver, double amount, string transferType)
        {
            double Finalamount;
            if (transferType == "RTGS")
            {
                Finalamount = amount + MasterBank.currentBank.SameTransferCharge.RtgsCharge*amount;
            }
            else
            {
                Finalamount = amount + MasterBank.currentBank.SameTransferCharge.ImpsCharge * amount;
            }
            Debit(sender, Finalamount);
            Credit(receiver, amount);
        }

        public void OtherBankTransfer(Account sender, Account receiver, Bank recieverBank, double amount, string transferType)
        {
            double Finalamount;
            if (transferType == "RTGS")
            {
                Finalamount = amount + MasterBank.currentBank.OtherTransferCharge.RtgsCharge * amount;
            }                                                                                                                            
            else                                                                                                                         
            {                                                                                                                            
                Finalamount = amount + MasterBank.currentBank.OtherTransferCharge.ImpsCharge * amount;
            }
            Debit(sender, Finalamount);
            Credit(receiver, amount);
        }

    }
}
