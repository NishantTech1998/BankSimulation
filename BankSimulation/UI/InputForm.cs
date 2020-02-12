using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Display;

namespace BankSimulation.UI
{
    class InputForm
    {
        public static void LoginInputField()
        {
            DisplayHelper.CreateInputFields("USER ID", "PASSWORD");
        }
        public static void AddEmployeeField()
        {
            DisplayHelper.CreateInputFields("FIRST NAME", "LAST NAME", "DATE OF BIRTH", "EMAIL ID", "PAN NUMBER", "CONTACT NUMBER", "ADDRESS LINE 1", "ADDRESS LINE 2", "CITY", "STATE", "PINCODE", "STAFF ROLE", "STAFF USER ID", "PASSWORD");
        }
        public static void AddAccountField()
        {
            DisplayHelper.CreateInputFields("FIRST NAME", "LAST NAME", "DATE OF BIRTH", "EMAIL ID", "PAN NUMBER", "CONTACT NUMBER", "ADDRESS LINE 1", "ADDRESS LINE 2", "CITY", "STATE", "PINCODE", "ACCOUNT USER ID", "PASSWORD");
        }
        public static void AddServiceChargeField()
        {
            DisplayHelper.CreateInputFields("ENTER SERVICE CHARGE FOR SAME BANK IMPS TRANSFER", "ENTER SERVICE CHARGE FOR SAME BANK RTGS TRANSFER", "ENTER SERVICE CHARGE FOR OTHER BANK IMPS TRANSFER", "ENTER SERVICE CHARGE FOR OTHER BANK RTGS TRANSFER");
        }
        public static void AddCurrencyExchangeRateField()
        {
            DisplayHelper.CreateInputFields("ENTER THE CURRENCY IN STANDARD ABBREVIATED FORM", "ENTER THE CURRENT EXCHANGE RATE WITH RESPECT TO INR");
        }
        public static void CreateNewBankField()
        {
            DisplayHelper.CreateInputFields("BANK NAME");

        }
        public static void AddAccountInformation()
        {
            DisplayHelper.CreateInputFields("ACCOUNT NUMBER", "BALANCE");
        }
        public static void DepositField()
        {
            DisplayHelper.CreateInputFields("AMOUNT TO DEPOSIT");
        }
        public static void WithdrawField()
        {
            DisplayHelper.CreateInputFields("AMOUNT TO WITHDRAW");
        }
        public static void ApplyLoanFields()
        {
            DisplayHelper.CreateInputFields("");
        }
        public static void SameTransferFundField()
        {
            DisplayHelper.CreateInputFields("AMOUNT TO TRANSFER", "ENTER DESTINATION ACCOUNT ID");
        }
        public static void OtherTransferFundField()
        {
            DisplayHelper.CreateInputFields("AMOUNT TO TRANSFER", "ENTER DESTINATION BANK ID", "ENTER DESTINATION ACCOUNT ID");
        }
    }
}
