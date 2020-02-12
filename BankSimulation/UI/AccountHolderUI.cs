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
using BankSimulation.Service.Helper;
using Validator;

namespace BankSimulation.UI
{
    public class AccountHolderUI
    {
        private readonly IAccountService accountService;

        public AccountHolderUI(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public bool AccountLoginDisplay()
        {
            Console.Clear();
            InputForm.LoginInputField();

            /* ValidatorHelper has methods which takes input from user and validate it.
               If input matches regex then it returns the input else ask again.
               The parameters in those methods tells the x and y coordinate where 
               cursor will start taking input */

            string accountHolderId = ValidatorHelper.StringValidator(40, 10);
            string password = ValidatorHelper.StringValidator(40, 12);
            bool isValid = accountService.LogIn(accountHolderId, password);
            if (isValid == true)
            { MasterBank.currentAccountHolder = accountHolderId; return true; }
            else
            { Console.WriteLine("WRONG ID PASSWORD"); return false; }
        }

        public static string DisplayAccountMenu()
        {
            Console.Clear();
            Menu.AccountHolderRelatedMenu();
            string response = ValidatorHelper.StringValidator(100, 40);
            return response;
        }

        public void CreateAccountDisplay()
        {
            Console.Clear();
            string accountHolderId, accountNumber;
            InputForm.AddAccountField();
            Account account = new Account();
            AccountHolder accountHolder = new AccountHolder();
            accountHolder.FirstName = ValidatorHelper.StringValidator(40, 10);
            accountHolder.LastName = ValidatorHelper.StringValidator(40, 12);
            accountHolder.Dob = ValidatorHelper.DateValidator(40, 14);
            accountHolder.Email = ValidatorHelper.EmailValidator(40, 16);
            accountHolder.PanNumber = ValidatorHelper.PanValidator(40, 18);
            accountHolder.ContactNumber = ValidatorHelper.PhoneValidator(40, 20);
            accountHolder.address.addressLine1 = ValidatorHelper.StringValidator(40, 22);
            accountHolder.address.addressLine2 = ValidatorHelper.StringValidator(40, 24);
            accountHolder.address.city = ValidatorHelper.StringValidator(40, 26);
            accountHolder.address.state = ValidatorHelper.StringValidator(40, 28);
            accountHolder.address.pincode = ValidatorHelper.StringValidator(40, 30);
            do
            {
                accountHolderId = ValidatorHelper.StringValidator(40, 32);
                MasterBank.checkFor = 1;
                if (accountService.IsDuplicateAccountHolder(accountHolderId))
                    break;
            } while (true);
            accountHolder.AccountHolderId=(accountHolderId);
            accountHolder.Password=ValidatorHelper.StringValidator(40, 34);
            account.AccountHolderId = accountHolderId;
            Console.Clear();
            InputForm.AddAccountInformation();
            do
            {
                MasterBank.checkFor = 2;
                accountNumber = ValidatorHelper.StringValidator(40, 10);
                if (accountService.IsDuplicateAccountNumber(accountNumber))
                    break;
            } while (true);
            account.AccountNumber=accountNumber;
            account.Balance=ValidatorHelper.DoubleValidator(40, 12);
            account.AccountId=accountHolder.FirstName.Substring(0, 3) + DateHelper.GetTodayDate(2) + account.AccountNumber.Substring(0, 3);
            account.OpeningDate=DateHelper.GetTodayDate(2);
            accountService.AddNewAccount(accountHolder, account);
        }

        public void UpdateAccountDisplay()
        {
            Console.Clear();
            ViewAllAccounts();
            Console.WriteLine("\t\t\tEnter AccountHolderID to update\n\t\t\tEnter B to go back");
            string UpdateResponse = ValidatorHelper.StringValidator(120, 13);
            if (UpdateResponse != "B")
            {
                Console.Clear();
                InputForm.AddAccountField();
                AccountHolder accountHolder = accountService.GetAccountHolderById(UpdateResponse);
                if (accountHolder != null)
                {
                    DisplayHelper.PrintTextAtXY(40, 10, accountHolder.FirstName);
                    DisplayHelper.PrintTextAtXY(40, 12, accountHolder.LastName);
                    DisplayHelper.PrintTextAtXY(40, 14, accountHolder.Dob.ToString());
                    DisplayHelper.PrintTextAtXY(40, 16, accountHolder.Email);
                    DisplayHelper.PrintTextAtXY(40, 18, accountHolder.PanNumber);
                    DisplayHelper.PrintTextAtXY(40, 20, accountHolder.ContactNumber.ToString());
                    DisplayHelper.PrintTextAtXY(40, 22, accountHolder.address.addressLine1);
                    DisplayHelper.PrintTextAtXY(40, 24, accountHolder.address.addressLine2);
                    DisplayHelper.PrintTextAtXY(40, 26, accountHolder.address.city);
                    DisplayHelper.PrintTextAtXY(40, 28, accountHolder.address.state);
                    DisplayHelper.PrintTextAtXY(40, 30, accountHolder.address.pincode);
                    DisplayHelper.PrintTextAtXY(40, 34, accountHolder.AccountHolderId);
                    DisplayHelper.PrintTextAtXY(40, 36, "**********");
                    string FieldToUpdate;
                    do
                    {
                        DisplayHelper.PrintTextAtXY(40, 40, "Enter The Field No To Update or Q to go back");
                        FieldToUpdate = ValidatorHelper.StringValidator(40, 42);
                        if (FieldToUpdate == "1") { accountHolder.FirstName = ValidatorHelper.StringValidator(40, 10); }
                        else if (FieldToUpdate == "2") { accountHolder.LastName = ValidatorHelper.StringValidator(40, 12); }
                        else if (FieldToUpdate == "3") { accountHolder.Dob = ValidatorHelper.DateValidator(40, 14); }
                        else if (FieldToUpdate == "4") { accountHolder.Email = ValidatorHelper.EmailValidator(40, 16); }
                        else if (FieldToUpdate == "5") { accountHolder.PanNumber = ValidatorHelper.PanValidator(40, 18); }
                        else if (FieldToUpdate == "6") { accountHolder.ContactNumber = ValidatorHelper.PhoneValidator(40, 20); }
                        else if (FieldToUpdate == "7") { accountHolder.address.addressLine1 = ValidatorHelper.StringValidator(40, 22); }
                        else if (FieldToUpdate == "8") { accountHolder.address.addressLine2 = ValidatorHelper.StringValidator(40, 24); }
                        else if (FieldToUpdate == "9") { accountHolder.address.city = ValidatorHelper.StringValidator(40, 26); }
                        else if (FieldToUpdate == "10") { accountHolder.address.state = ValidatorHelper.StringValidator(40, 28); }
                        else if (FieldToUpdate == "11") { accountHolder.address.pincode = ValidatorHelper.StringValidator(40, 30); }
                        else if (FieldToUpdate == "12") { DisplayHelper.PrintTextAtXY(40, 42, "CANNOT CHANGE THIS FIELD"); }
                        else if (FieldToUpdate == "13") { DisplayHelper.PrintTextAtXY(40, 42, "CANNOT CHANGE THIS FIELD"); }
                        else if (FieldToUpdate == "Q") { break; }
                        else { DisplayHelper.PrintTextAtXY(40, 42, "INVALID FIELD SELECTED"); }
                    } while (FieldToUpdate != "Q");
                }
                accountService.UpdateAccountHolder(accountHolder);
            }
        }


        public void DeleteAccountDisplay()
        {
            Console.Clear();
            ViewAllAccounts();
            DisplayHelper.PrintTextAtXY(100, 60, "Enter AccountHolder ID to delete or Enter B to go back");
            string DeleteResponse = ValidatorHelper.StringValidator(120, 13);
            if (DeleteResponse != "B")
            {
                bool success = accountService.DeleteAccount(DeleteResponse);
                if (success == true)
                {
                    DisplayHelper.PrintTextAtXY(80, 40, "EMPLOYEE DELETED SUCCESSFULLY");
                }
                else
                {
                    DisplayHelper.PrintTextAtXY(80, 40, "NO SUCH EMPLOYEE EXISTS");
                }
            }
        }

        public void ViewAllAccounts()
        {
            Console.Clear();
            DisplayHelper.Title();
            int width = Console.WindowWidth;
            DisplayHelper.CreateBoxAtXY(100, 2, 40, 4, '*', '*');
            DisplayHelper.PrintTextAtXY(42, 5, "Account Holder Id |");
            DisplayHelper.PrintTextAtXY(58, 5, "First Name |");
            DisplayHelper.PrintTextAtXY(71, 5, "Last Name |");
            DisplayHelper.PrintTextAtXY(83, 5, "Account Number           |");
            int printingGap = 0;
            if (MasterBank.currentBank.accounts.Count != 0)
            {
                foreach (Account account in accountService.GetAllAccounts())
                {
                    AccountHolder accountHolder = accountService.GetAccountHolderById(account.AccountHolderId);
                    DisplayHelper.PrintTextAtXY(42, 8 + printingGap, accountHolder.AccountHolderId);
                    DisplayHelper.PrintTextAtXY(58, 8 + printingGap, accountHolder.FirstName);
                    DisplayHelper.PrintTextAtXY(71, 8 + printingGap, accountHolder.LastName);
                    DisplayHelper.PrintTextAtXY(83, 8 + printingGap, account.AccountNumber);
                    printingGap = printingGap + 1;
                }
            }
        }

        public void DepositDisplay()
        {
            Console.Clear();
            InputForm.DepositField();
            double amount = Validator.ValidatorHelper.DoubleValidator(40,10);
            accountService.Deposit(amount);
        }

        public void WithdrawDisplay()
        {
            Console.Clear();
            InputForm.DepositField();
            double amount = Validator.ValidatorHelper.DoubleValidator(40, 10);
   
            accountService.Withdraw(amount);
         
        }

        public void SameBankTransferDisplay(string type)
        {
            Console.Clear();
            InputForm.SameTransferFundField();
            double amount = Validator.ValidatorHelper.DoubleValidator(40, 10);
            string destinationAccountId = Validator.ValidatorHelper.StringValidator(40,12);
            accountService.SameBankTransfer(amount, destinationAccountId,type);
        }

        public void OtherBankTransferDisplay(string type)
        {
            Console.Clear();
            InputForm.OtherTransferFundField();
            double amount = Validator.ValidatorHelper.DoubleValidator(40, 10);
            string destinationBankId = Validator.ValidatorHelper.StringValidator(40, 12);
            string destinationAccountId = Validator.ValidatorHelper.StringValidator(40, 14);
            accountService.OtherBankTransfer(amount,destinationAccountId,MasterBank.GetBankById(destinationBankId),type);
        }

        public void ViewAccount()
        {
            Console.Clear();
            Console.WriteLine("ACCOUNT NUMBER :");
            Console.WriteLine("ACCOUNT ID  :");
            Console.WriteLine("BANK ID  :");
            Console.WriteLine("AVAILABLE BALANCE  :");
            Account activeAccount=accountService.GetAccountData();
            DisplayHelper.PrintTextAtXY(20, 2, activeAccount.AccountNumber);
            DisplayHelper.PrintTextAtXY(20, 4, activeAccount.AccountId);
            DisplayHelper.PrintTextAtXY(20, 6, MasterBank.currentBank.BankId);
            DisplayHelper.PrintTextAtXY(20, 8, activeAccount.Balance.ToString());
        }

        public static string TransferFundDisplay()
        {
            Console.Clear();
            Menu.TransferFundMenu();
            string response = ValidatorHelper.StringValidator(100, 40);
            return response;
        }

    }
}
