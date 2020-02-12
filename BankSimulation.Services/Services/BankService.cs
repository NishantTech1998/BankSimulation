using System;
using BankSimulation.Model;
using BankSimulation.Data.DataServices;
using BankSimulation.Service.IServices;

namespace BankSimulation.Service.Services
{
    public class BankService:IBankService
    {
        BankDataService bankDataService;
        public void CreateNewBank(Bank bank)
        {
            bankDataService = new BankDataService();
            MasterBank.currentBank = null;

            if (MasterBank.bankList != null)
            {
                foreach (Bank bankInFile in MasterBank.bankList)
                {
                    if (bank.Name == bankInFile.Name)
                        throw new Exception("BANK ALREADY PRESENT");
                }
            }

            bankDataService.AddNewBank(bank);

        }

        public void AddServiceCharge()
        {
            bankDataService.AddServiceCharge();
        }

        public void AddCurrencyExchangeRate(string currency, double rate)
        {
            bankDataService.AddCurrencyExchangeRate(currency, rate);
        }
    }
}
