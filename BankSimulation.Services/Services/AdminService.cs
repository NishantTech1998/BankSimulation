using System;
using System.Collections.Generic;
using System.Text;
using BankSimulation.Model;
using BankSimulation.Data.DataServices;
using BankSimulation.Service.IServices;


namespace BankSimulation.Service.Services
{
    public class AdminService:IAdminService
    {
        EmployeeDataService employeeDataService = new EmployeeDataService();

        public void AddNewAdmin(BankStaff admin)
        {
            employeeDataService.AddEmployee(admin);
        }

        public bool AdminLogin(string userId, string password)
        {
            BankStaff admin = employeeDataService.GetEmployeeById(userId);
            return (admin != null && admin.Password == password && admin.BankStaffRole == "Admin");
        }

        public bool IsDuplicateBankStaff(string id)
        {
            BankStaff bankStaff = employeeDataService.GetEmployeeById(id);
            if (bankStaff == null)
                return true;
            else
                return false;
        }
    }
}
