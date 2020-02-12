using System;
using System.Collections.Generic;
using System.Text;
using BankSimulation.Model;

namespace BankSimulation.Service.IServices
{
    public interface ITransactionService
    {
        List<Transaction> GetTransactions();
        
    }
}
