using System;
using BankSimulation.Model;
using System.Collections.Generic;
using BankSimulation.Data.DataServices;
using BankSimulation.Service.IServices;


namespace BankSimulation.Service.Services
{
     public class EmployeeService:IEmployeeService
    {
        EmployeeDataService employeeDataService = new EmployeeDataService();

        public bool EmployeeLogIn(string username, string password)
        {
            BankStaff employee = employeeDataService.GetEmployeeById(username);
            return (employee != null && employee.Password == password && employee.BankStaffRole != "Admin");
        }

        public bool IsDuplicateBankStaff(string id)
        {
            BankStaff bankStaff = employeeDataService.GetEmployeeById(id);
            return bankStaff==null;
        }

        public void AddNewBankStaff(BankStaff employee)
        {
            employeeDataService.AddEmployee(employee);
        }

        public BankStaff GetBankStaffById(string id)
        {
            return employeeDataService.GetEmployeeById(id);
        }

        public void UpdateBankStaff(BankStaff employee)
        {
            employeeDataService.UpdateEmployee(employee);
        }

        public bool DeleteBankStaff(string employeeId)
        {
            BankStaff bankStaff = employeeDataService.GetEmployeeById(employeeId);
            if (bankStaff == null)
            {
                return false;
            }
            else
            {
                employeeDataService.DeleteEmployee(employeeId);
                return true;
            }

        }

        public List<BankStaff> GetAllStaffs()
        {
            return employeeDataService.GetEmployeeList();
        }

       

    }
}
