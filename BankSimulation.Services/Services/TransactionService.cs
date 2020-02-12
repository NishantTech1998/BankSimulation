using System;
using System.Collections.Generic;
using BankSimulation.Model;
using BankSimulation.Data.DataServices;
using BankSimulation.Service.IServices;
using BankSimulation.Service.Helper;
using Validator;

namespace BankSimulation.Service.Services
{
    public class TransactionService:ITransactionService
    {
        TransactionDataService transactionDataService = new TransactionDataService();
        AccountDataService accountDataService = new AccountDataService();

        public List<Transaction> GetTransactions()
        {
            Account account = accountDataService.GetAccountByUserId(MasterBank.currentAccountHolder);
            return transactionDataService.GetTransactionByAccountNumber(account.AccountNumber);
        }

        public void SaveTransactionToDestination(Transaction transaction)
        {
            Bank DestinationBank = MasterBank.GetBankById(transaction.DestinationBankId);
            Account destinationAccount = accountDataService.GetAccountByAccountId(transaction.DestinationAccountId);
            destinationAccount.transactions.Add(transaction);
            MasterBank.bankList[MasterBank.bankList.FindIndex(bank => bank.BankId == transaction.DestinationBankId)] = DestinationBank;
            MasterBank.SaveCurrentState();
        }

        public void SaveTransactionToSource(Transaction transaction)
        {
            Account account = accountDataService.GetAccountByAccountId(transaction.SourceAccountId);
            account.transactions.Add(transaction);
            MasterBank.SaveCurrentState();
        }
        
       public void CreateNewTransaction(Account sender,string transactionType, TransactionOptions transactionOptions, double amount,Account reciever,Bank recieverBank,double transferCharge)
        {
            Transaction transaction = new Transaction();
            transaction.TransactionDate = (DateHelper.GetTodayDate(1) + " " + DateHelper.GetCurrentTime(1));
            transaction.SourceAccountId = (accountDataService.GetAccountByUserId(MasterBank.currentAccountHolder).AccountId);
            transaction.SourceBankId = (MasterBank.currentBank.BankId);
            transaction.TransactionType=transactionType;
            transaction.TransactionAmount=amount;
            transaction.DestinationAccountId=reciever.AccountId;
            transaction.DestinationBankId=recieverBank.BankId;
            transaction.TransactionTransferCharge=transferCharge;
            transaction.TransactionId=("TXN" + MasterBank.currentBank.BankId + sender.AccountId + DateHelper.GetCurrentTime(2) + transactionType.Substring(0,1));
            switch (transactionOptions)
            {
                case TransactionOptions.Deposit:SaveTransactionToSource(transaction);
                    break;
                case TransactionOptions.Withdraw:SaveTransactionToSource(transaction);
                    break;
                case TransactionOptions.Transfer:
                    SaveTransactionToSource(transaction);
                    SaveTransactionToDestination(transaction);
                    break;
            }
        }

        public enum TransactionOptions
        {
            Deposit, Withdraw, Transfer
        }
    }
}
