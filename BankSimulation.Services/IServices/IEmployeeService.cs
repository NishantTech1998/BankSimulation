using System;
using System.Collections.Generic;
using System.Text;
using BankSimulation.Model;

namespace BankSimulation.Service.IServices
{
   public interface IEmployeeService
    {
        bool EmployeeLogIn(string username, string password);
        bool IsDuplicateBankStaff(string id);
        void AddNewBankStaff(BankStaff employee);
        void UpdateBankStaff(BankStaff employee);
        bool DeleteBankStaff(string employeeId);
        List<BankStaff> GetAllStaffs();
        BankStaff GetBankStaffById(string id);
    }
}
