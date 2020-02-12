using System;
using System.Collections.Generic;
using System.Text;
using BankSimulation.Model;
using BankSimulation.Data.DataServices;
using Display;
using BankSimulation.Service.IServices;

namespace BankSimulation.Service.Services
{
   public class AccountService:TransactionService,IAccountService
    {
        AccountDataService accountDataService = new AccountDataService();

        public bool LogIn(string username, string password)
        {
            AccountHolder accountHolder = accountDataService.GetAccountHolderById(username);
            return (accountHolder != null && accountHolder.Password == password);
        }

        public bool IsDuplicateAccountHolder(string id)
        {
            AccountHolder accountHolder = accountDataService.GetAccountHolderById(id);
            return (accountHolder == null);
        }

        public bool IsDuplicateAccountNumber(string number)
        {
            Account account = accountDataService.GetAccountByNumber(number);
            return (account == null);
        }

        public void AddNewAccount(AccountHolder accountHolder, Account account)
        {
            accountDataService.AddAccount(accountHolder, account);
        }

        public AccountHolder GetAccountHolderById(string accountHolderId)
        {
            return accountDataService.GetAccountHolderById(accountHolderId);
        }

        public void UpdateAccountHolder(AccountHolder accountHolder)
        {
            accountDataService.UpdateAccount(accountHolder);
        }

        public bool DeleteAccount(string accountHolderId)
        {
            bool isDeleted = accountDataService.DeleteAccount(accountHolderId);
            return isDeleted;
        }

        public Account GetAccountByUserId(string accountHolderId)
        {
            return accountDataService.GetAccountByUserId(accountHolderId);
        }

        public List<Account> GetAllAccounts()
        {
            return accountDataService.GetAccountList();
        }

        Account activeAccount;
        public Account GetAccountData()
        {
            return GetAccountByUserId(MasterBank.currentAccountHolder);
            
        }

        public void Deposit(double amount)
        {
            activeAccount = GetAccountByUserId(MasterBank.currentAccountHolder);
            accountDataService.Deposit(activeAccount, amount);
            CreateNewTransaction(activeAccount, "Deposit", TransactionOptions.Deposit, amount, null, null, 0.0);
        }

        public void Withdraw(double amount)
        {
            activeAccount = GetAccountByUserId(MasterBank.currentAccountHolder);
            CreateNewTransaction(activeAccount, "Withdraw", TransactionOptions.Deposit, amount, null, null, 0.0);
        }

        public void SameBankTransfer(double amount,string destinationAccountId,string type)
        {
            activeAccount = GetAccountByUserId(MasterBank.currentAccountHolder);
            accountDataService.SameBankTransfer(activeAccount, GetAccountByUserId(destinationAccountId), amount, type);
            double transferCharge;
            if (type == "IMPS")
                transferCharge = MasterBank.currentBank.SameTransferCharge.ImpsCharge * amount;
            else
                transferCharge = MasterBank.currentBank.SameTransferCharge.RtgsCharge * amount;
            CreateNewTransaction(activeAccount, $"Same{type}", TransactionOptions.Deposit, amount,GetAccountByUserId(destinationAccountId), MasterBank.currentBank,transferCharge);
        }

        public void OtherBankTransfer(double amount, string destinationAccountId,Bank destinationBank,string type)
        {
            activeAccount = GetAccountByUserId(MasterBank.currentAccountHolder);
            accountDataService.OtherBankTransfer(activeAccount, GetAccountByUserId(destinationAccountId),destinationBank,amount, type);
            double transferCharge;
            if (type == "IMPS")
                transferCharge = MasterBank.currentBank.SameTransferCharge.ImpsCharge * amount;
            else
                transferCharge = MasterBank.currentBank.SameTransferCharge.RtgsCharge * amount;
            CreateNewTransaction(activeAccount, $"Other{type}", TransactionOptions.Deposit, amount, GetAccountByUserId(destinationAccountId), MasterBank.currentBank, transferCharge);
        }

    }
}
