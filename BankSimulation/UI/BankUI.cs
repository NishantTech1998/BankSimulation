using System;
using BankSimulation.Model;
using Validator;
using Display;
using BankSimulation.Service.Helper;
using BankSimulation.Data.DataServices;
using BankSimulation.Service.IServices;

namespace BankSimulation.UI
{
    class BankUI
    {
        private readonly IBankService bankService;

        public BankUI(IBankService bankService)
        {
            this.bankService = bankService;
        }

        public string MainView()
        {
            
            Console.Clear();
            Menu.HomeMenu();
            string response = ValidatorHelper.MenuChoiceValidator(100, 40);
            return response;
        }

        public bool CreateNewBankDisplay()
        {
            Bank bank = new Bank();
            Console.Clear();
            InputForm.CreateNewBankField();
            bank.Name=ValidatorHelper.NameValidator(40, 10);
            bank.Currency = "INR";
            bank.BankId=bank.Name.Substring(0, 3) + DateHelper.GetTodayDate(1);
            bank.SameTransferCharge.ImpsCharge = 0.05;
            bank.SameTransferCharge.RtgsCharge = 0.0;
            bank.OtherTransferCharge.ImpsCharge = 0.06;
            bank.OtherTransferCharge.RtgsCharge = 0.02;
            try
            {
                bankService.CreateNewBank(bank);
            }
            catch (Exception)
            {
                DisplayHelper.PrintTextAtXY(80, 40, "BANK ALREADY EXIST WITH THE SAME NAME");
                return false;
           }          
            DisplayHelper.PrintTextAtXY(80, 40, "BANK CREATED SUCCESSFULLY");
            return true;
        }

        public string SelectBankPortalMenu()
        {
            Console.Clear();
            Menu.BankSelectionMenu();
            string currentActiveBank = ValidatorHelper.MenuChoiceValidator(100, 40);
            return currentActiveBank;
        }

        public void AddServiceChargeDisplay()
        {

            Console.Clear();
            InputForm.AddServiceChargeField();
            MasterBank.currentBank.SameTransferCharge.ImpsCharge = ValidatorHelper.DoubleValidator(40, 10);
            MasterBank.currentBank.SameTransferCharge.RtgsCharge = ValidatorHelper.DoubleValidator(40, 12);
            MasterBank.currentBank.OtherTransferCharge.ImpsCharge = ValidatorHelper.DoubleValidator(40, 14);
            MasterBank.currentBank.OtherTransferCharge.RtgsCharge = ValidatorHelper.DoubleValidator(40, 16);
            bankService.AddServiceCharge();
        }

        public void AddCurrencyExchangeRateDisplay()
        {
            Console.Clear();
            InputForm.AddCurrencyExchangeRateField();
            string currency = ValidatorHelper.StringValidator(40, 10);
            double rate = ValidatorHelper.DoubleValidator(40, 12);
            bankService.AddCurrencyExchangeRate(currency, rate);
        }

    }
}
