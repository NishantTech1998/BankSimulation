using System;
using System.Collections.Generic;
using BankSimulation.Model;

namespace BankSimulation.Data.DataServices
{
    public class BankDataService
    {
        public void AddNewBank(Bank bank)
        {
            MasterBank.bankList.Add(bank);
            MasterBank.SaveBanksInFile();
        }

        public void AddServiceCharge()
        {
            MasterBank.SaveCurrentState();
        }

        public void AddCurrencyExchangeRate(string currency, double rate)
        {
            CurrencyExchangeRate currencyExchangeRate = new CurrencyExchangeRate { Currency = currency, Rate = rate };
            if (MasterBank.currentBank.CurrencyExchangeList.Contains(currencyExchangeRate))
            { }
            else
            {
                MasterBank.currentBank.CurrencyExchangeList.Add(currencyExchangeRate);
            }
            MasterBank.SaveCurrentState();
        }
    }
}
