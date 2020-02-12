using System;
using System.Collections.Generic;
using System.Text;
using BankSimulation.Model;

namespace BankSimulation.Service.IServices
{
    public interface IAccountService
    {
        bool LogIn(string username, string password);
        bool IsDuplicateAccountHolder(string id);
        bool IsDuplicateAccountNumber(string number);
        void AddNewAccount(AccountHolder accountHolder, Account account);
        AccountHolder GetAccountHolderById(string accountHolderId);
        void UpdateAccountHolder(AccountHolder accountHolder);
        bool DeleteAccount(string accountHolderId);
        Account GetAccountByUserId(string accountHolderId);
        List<Account> GetAllAccounts();
        Account GetAccountData();
        void Deposit(double amount);
        void Withdraw(double amount);
        void SameBankTransfer(double amount, string destinationAccountId, string type);
        void OtherBankTransfer(double amount, string destinationAccountId, Bank destinationBank, string type);
    }
}
