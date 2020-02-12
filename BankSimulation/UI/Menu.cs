using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSimulation.Data.DataServices;
using Display;

namespace BankSimulation.UI
{
    class Menu
    {
        public static void HomeMenu()
        {
            DisplayHelper.CreateMenu("SETUP A NEW BANK", "LOGIN TO YOUR BANK", "EXIT THE APPLICATION");
        }

        public static void LoginMenu()
        {
            DisplayHelper.CreateMenu("LOGIN FOR ADMINS","LOGIN FOR BANK STAFFS", "LOGIN FOR ACCOUNT HOLDERS", "EXIT THE APPLICATION");
        }

        public static void AdminMenu()
        {
            DisplayHelper.CreateMenu("CREATE EMPLOYEE", "UPDATE EMPLOYEE", "DELETE EMPLOYEE", "VIEW EMPLOYEE", "LOG OUT");
        }

        public static void AccountHolderRelatedMenu()
        {
            DisplayHelper.CreateMenu("CREATE AN ACCOUNT", "UPDATE AN ACCOUNT", "DELETE AN ACCOUNT", "VIEW ACCOUNT", "ADD SERVICE CHARGE", "ADD CURRENCY EXCHANGE RATE", "LOG OUT");
        }

        public static void TransactionMenu()
        {
            DisplayHelper.CreateMenu("DEPOSIT AMOUNT", "WITHDRAW AMOUNT", "TRANSFER FUND", "VIEW ACCOUNT DETAIL", "VIEW TRANSACTIONS", "LOG OUT");
        }

        public static void TransferFundMenu()
        {
            DisplayHelper.CreateMenu("TRANSFER FUNDS TO SAME BANK ACCOUNT USING RTGS", "TRANSFER FUNDS TO SAME BANK USING IMPS", "TRANSFER FUNDS TO OTHER BANK ACCOUNT USING RTGS", "TRANSFER FUNDS TO OTHER BANK USING IMPS");
        }

        public static void BankSelectionMenu()
        {
            int NoOfBanks = MasterBank.bankList.Count;
            string[] BankName = new string[NoOfBanks];
            for (int i = 0; i < NoOfBanks; i++)
                BankName[i] = $"Enter into {MasterBank.bankList[i].Name} Portal";
            DisplayHelper.CreateMenu(BankName);
        }
        public static void AccountTypeMenu()
        {
            DisplayHelper.CreateMenu("SAVINGS ACCOUNT", "CURRENT ACCOUNT");
        }
      
        public static void BankTransferMethodMenu()
        {
            DisplayHelper.CreateMenu("RTGS", "IMPS");
        }
    }
}
