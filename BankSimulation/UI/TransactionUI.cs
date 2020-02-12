using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSimulation.Model;
using BankSimulation.Service.Services;
using BankSimulation.Data.DataServices;
using BankSimulation.Service.IServices;
using Display;
using Validator;

namespace BankSimulation.UI
{
    public class TransactionUI
    {
        private readonly ITransactionService transactionService;

        public TransactionUI(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        public string TransactionRelatedMenu()
        {
            
            Console.Clear();
            Menu.TransactionMenu();
            string response = ValidatorHelper.StringValidator(100, 40);
            return response;
        }

        public void ViewTransactions()
        {
            Console.Clear();
            DisplayHelper.Title();
            if (transactionService.GetTransactions() != null)
            {
                foreach (Transaction transactionHistory in transactionService.GetTransactions())
                {
                    if (transactionHistory.TransactionType != "DEPOSIT" && transactionHistory.TransactionType != "WITHDRAW" && transactionHistory.TransactionType != "FAILED WITHDRAW")
                    {
                        Console.WriteLine($"Transaction ID         :{transactionHistory.TransactionId}");
                        Console.WriteLine($"Source Bank            :{transactionHistory.SourceBankId}");
                        Console.WriteLine($"Source Account NO      :{transactionHistory.SourceAccountId}");
                        Console.WriteLine($"Destination Bank       :{transactionHistory.DestinationBankId}");
                        Console.WriteLine($"Destination Account NO :{transactionHistory.DestinationAccountId}");
                        Console.WriteLine($"Amount                 :{transactionHistory.TransactionAmount}");
                        Console.WriteLine($"Type                   :{transactionHistory.TransactionType}");
                        Console.WriteLine($"Transfer Charge        :{transactionHistory.TransactionTransferCharge}\n\n");
                    }
                    else
                    {
                        Console.WriteLine($"Transaction ID         :{transactionHistory.TransactionId}");
                        Console.WriteLine($"Amount                 :{transactionHistory.TransactionAmount}");
                        Console.WriteLine($"Type                   :{transactionHistory.TransactionType}");
                        Console.WriteLine($"Transfer Charge        :{transactionHistory.TransactionTransferCharge}\n\n");
                    }
                }
            }
        }
    }
    
}
