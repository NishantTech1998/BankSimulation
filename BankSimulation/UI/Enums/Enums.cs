using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.UI.Enums
{
    public enum BankUiOption
    {
        None, SetupNewBank, LoginInBank, ExitApplication
    };

    public enum LoginOption
    {
        None, AdminLogin, BankStaffLogin, AccountHolderLogin, ExitApplication
    };

    public enum EmployeeRelated
    {
        None, CreateEmployee, UpdateEmployee, DeleteEmployee, ViewEmployee, LogOut
    };

    public enum AccountHolderRelated
    {
        None, CreateAccountHolder, UpdateAccountHolder, DeleteAccountHolder, ViewAccountHolder, AddServiceCharge, AddCurrencyExchange, LogOut
    };

    public enum TransactionRelated
    {
        None, Deposit, Withdraw, TransferFund, ViewAccountdetail, ViewTransactions, LogOut
    };
}
