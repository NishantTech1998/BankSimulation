using System;
using System.Collections.Generic;
using System.Text;
using BankSimulation.Model;

namespace BankSimulation.Service.IServices
{
    public interface IBankService
    {
        void CreateNewBank(Bank bank);
        void AddServiceCharge();
        void AddCurrencyExchangeRate(string currency, double rate);
    }
}
