using System;
using System.IO;
using System.Linq;
using System.Threading;
using BankSimulation.UI;
using BankSimulation.Model;
using BankSimulation.UI.Enums;
using Display;
using BankSimulation.Service.Services;
using BankSimulation.Data.DataServices;

namespace BankSimulation
{
    class Program
    {
        AdminUI adminUI = new AdminUI(new AdminService());


        static void Main(string[] args)
        {
            Program program = new Program();
            program.ShowHomeMenuOptions();
            Console.ReadKey();
        }

        BankUI bankUI = new BankUI(new BankService());
        public void ShowHomeMenuOptions()
        {
            
            MasterBank.GetBanksFromFile();
            switch (EnumHelper.ConvertInEnum<BankUiOption>(bankUI.MainView()))
            {
                case BankUiOption.SetupNewBank:
                    bool Result = bankUI.CreateNewBankDisplay();
                    //
                    Thread.Sleep(1000);
                    if (Result == false)
                    { }
                    else
                    {
                        MasterBank.currentBankIndex = MasterBank.bankList.Count - 1;
                        adminUI.CreateDefaultAdminDisplay();
                    }
                    ShowHomeMenuOptions();
                    break;

                case BankUiOption.LoginInBank:
                    if (File.Exists("BankData.data"))
                    {
                        int choice = int.Parse(bankUI.SelectBankPortalMenu());
                        if (choice <= MasterBank.bankList.Count())
                        {
                            MasterBank.currentBankIndex = choice - 1;
                            MasterBank.currentBank = MasterBank.bankList[MasterBank.currentBankIndex];
                            BankLoginOptions();
                        }
                        else
                        {
                            DisplayHelper.PrintTextAtXY(60, 22, "WRONG CHOICE ENTERED");
                            Thread.Sleep(1000);
                            ShowHomeMenuOptions();
                        }
                    }
                    else
                    {
                        DisplayHelper.PrintTextAtXY(65, 20, "YOU MUST CREATE A BANK FIRST");
                        Thread.Sleep(1000);
                        ShowHomeMenuOptions();
                    }
                    break;

                case BankUiOption.ExitApplication:
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                    break;

                default:
                    DisplayHelper.PrintTextAtXY(60, 22, "WRONG CHOICE ENTERED");
                    Thread.Sleep(1000);
                    ShowHomeMenuOptions();
                    break;
            }
        }

        EmployeeUI employeeUI;
        AccountHolderUI holderUI;

        public void BankLoginOptions()
        {
            employeeUI = new EmployeeUI(new EmployeeService());
            holderUI = new AccountHolderUI(new AccountService());
            switch (EnumHelper.ConvertInEnum<LoginOption>(LoginUI.SelectLoginOption()))
            {
                case LoginOption.AdminLogin:
                    bool result = adminUI.AdminLoginDisplay();
                    if (result == true) { EmployeeRelatedOption(); }
                    else { BankLoginOptions(); }
                    break;

                case LoginOption.BankStaffLogin:

                    bool Result = employeeUI.EmployeeLoginDisplay();
                    if (Result == true) { AccountHolderRelatedOption(); }
                    else { BankLoginOptions(); }
                    break;

                case LoginOption.AccountHolderLogin:
                    if (MasterBank.currentBank.accounts.Count == 0)
                    {
                        DisplayHelper.PrintTextAtXY(65, 22, "THERE IS NO ACCOUNT HOLDER REGISTERED");
                        Thread.Sleep(1000);
                        BankLoginOptions();
                    }
                    else
                    {

                        Result = holderUI.AccountLoginDisplay();
                        if (Result == true) { TransactionRelatedOption(); }
                        else { BankLoginOptions(); }
                    }
                    break;

                case LoginOption.ExitApplication:
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                    break;

                default:
                    DisplayHelper.PrintTextAtXY(60, 22, "WRONG CHOICE ENTERED");
                    Thread.Sleep(1000);
                    BankLoginOptions();
                    break;
            }
        }


        public void EmployeeRelatedOption()
        {
            switch (EnumHelper.ConvertInEnum<EmployeeRelated>(employeeUI.EmployeeMenu()))
            {
                case EmployeeRelated.CreateEmployee:
                    employeeUI.CreateEmployeeDisplay();
                    Thread.Sleep(1000);
                    EmployeeRelatedOption();
                    break;

                case EmployeeRelated.UpdateEmployee:
                    employeeUI.UpdateEmployeeDisplay();
                    Thread.Sleep(1000);
                    EmployeeRelatedOption();
                    break;

                case EmployeeRelated.DeleteEmployee:
                    employeeUI.DeleteEmployeeDisplay();
                    Thread.Sleep(1000);
                    EmployeeRelatedOption();
                    break;

                case EmployeeRelated.ViewEmployee:
                    employeeUI.ViewEmployee();
                    Thread.Sleep(1000);
                    Console.ReadKey();
                    EmployeeRelatedOption();
                    break;

                case EmployeeRelated.LogOut:
                    BankLoginOptions();
                    break;

                default:
                    DisplayHelper.PrintTextAtXY(60, 22, "WRONG CHOICE ENTERED");
                    Thread.Sleep(1000);
                    EmployeeRelatedOption();
                    break;
            }
        }


        public void AccountHolderRelatedOption()
        {
            switch (EnumHelper.ConvertInEnum<AccountHolderRelated>(AccountHolderUI.DisplayAccountMenu()))
            {
                case AccountHolderRelated.CreateAccountHolder:
                    holderUI.CreateAccountDisplay();
                    Thread.Sleep(1000);
                    AccountHolderRelatedOption();
                    break;

                case AccountHolderRelated.UpdateAccountHolder:
                    holderUI.UpdateAccountDisplay();
                    Thread.Sleep(1000);
                    AccountHolderRelatedOption();
                    break;

                case AccountHolderRelated.DeleteAccountHolder:
                    holderUI.DeleteAccountDisplay();
                    Thread.Sleep(1000);
                    AccountHolderRelatedOption();
                    break;

                case AccountHolderRelated.ViewAccountHolder:
                    holderUI.ViewAllAccounts();
                    Thread.Sleep(1000);
                    Console.ReadKey();
                    AccountHolderRelatedOption();
                    break;

                case AccountHolderRelated.AddServiceCharge:
                    bankUI.AddServiceChargeDisplay();
                    Thread.Sleep(1000);
                    AccountHolderRelatedOption();
                    break;

                case AccountHolderRelated.AddCurrencyExchange:
                    bankUI.AddCurrencyExchangeRateDisplay();
                    Thread.Sleep(1000);
                    AccountHolderRelatedOption();
                    break;

                case AccountHolderRelated.LogOut:
                    BankLoginOptions();
                    break;

                default:
                    DisplayHelper.PrintTextAtXY(60, 22, "WRONG CHOICE ENTERED");
                    Thread.Sleep(1000);
                    AccountHolderRelatedOption();
                    break;
            }
        }


        public void TransactionRelatedOption()
        {
            TransactionUI transactionUI;
            transactionUI = new TransactionUI(new TransactionService());
            switch (EnumHelper.ConvertInEnum<TransactionRelated>(transactionUI.TransactionRelatedMenu()))
            {
                case TransactionRelated.Deposit:
                    holderUI.DepositDisplay();
                    Thread.Sleep(1000);
                    TransactionRelatedOption();
                    break;

                case TransactionRelated.Withdraw:
                    try
                    { holderUI.WithdrawDisplay(); }
                    catch (Exception e) { Console.WriteLine("Something Went Wrong"); Console.ReadKey(); TransactionRelatedOption(); }
                    Thread.Sleep(1000);
                    TransactionRelatedOption();
                    break;

                case TransactionRelated.TransferFund:
                    string Type = AccountHolderUI.TransferFundDisplay();
                    try
                    {
                        if (Type == "1") { holderUI.SameBankTransferDisplay("RTGS"); }
                        else if (Type == "2") { holderUI.SameBankTransferDisplay("IMPS"); }
                        else if (Type == "3") { holderUI.OtherBankTransferDisplay("RTGS"); }
                        else if (Type == "4") { holderUI.OtherBankTransferDisplay("IMPS"); }
                        else { }
                    }
                    catch (Exception e) { Console.WriteLine("Something Went Wrong");Console.ReadKey(); TransactionRelatedOption(); }
                    Thread.Sleep(1000);
                    TransactionRelatedOption();
                    break;

                case TransactionRelated.ViewAccountdetail:
                    holderUI.ViewAccount();
                    Console.ReadKey();
                    TransactionRelatedOption();
                    break;

                case TransactionRelated.ViewTransactions:
                    transactionUI.ViewTransactions();
                    Thread.Sleep(1000);
                    Console.ReadKey();
                    TransactionRelatedOption();
                    break;

                case TransactionRelated.LogOut:
                    BankLoginOptions();
                    break;

                default:
                    DisplayHelper.PrintTextAtXY(60, 22, "WRONG CHOICE ENTERED");
                    Thread.Sleep(1000);
                    TransactionRelatedOption();
                    break;
            }
        }





    }
}
