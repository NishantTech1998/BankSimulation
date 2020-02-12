using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankSimulation.Model;

namespace BankSimulation.Data.DataServices
{
   public class EmployeeDataService
    {
        public void AddEmployee(BankStaff bankStaff)
        {
            MasterBank.currentBank.bankStaffList.Add(bankStaff);
            MasterBank.SaveCurrentState(); 
        }

        public BankStaff GetEmployeeById(string employeeId)
        {
            if (MasterBank.currentBank.bankStaffList.Count > 0)
            {
                BankStaff bankStaff = MasterBank.currentBank.bankStaffList.FirstOrDefault(staff => staff.BankStaffId == employeeId);
                if (bankStaff != null)
                    return bankStaff;
                else
                    return null;

            }
            else
                return null;
        }

        public void UpdateEmployee(BankStaff bankStaff)
        {
            int index = -1;
            foreach (BankStaff employee in MasterBank.currentBank.bankStaffList)
            {
                if (employee.BankStaffId == bankStaff.BankStaffId)
                    index = MasterBank.currentBank.bankStaffList.IndexOf(employee);
                else
                { }
            }
            if (index != -1)
            {
                MasterBank.currentBank.bankStaffList.RemoveAt(index);
                MasterBank.currentBank.bankStaffList.Insert(index, bankStaff);
                MasterBank.SaveCurrentState();
            }
        }

        public void DeleteEmployee(string idToDelete)
        {
            if (MasterBank.currentBank.bankStaffList.Count > 0)
            {
                BankStaff bankStaffToDelete = MasterBank.currentBank.bankStaffList.FirstOrDefault(staff => staff.BankStaffId == idToDelete);               
                if (bankStaffToDelete != null)
                    MasterBank.currentBank.bankStaffList.Remove(bankStaffToDelete);
            }
            MasterBank.SaveCurrentState();
        }

        public List<BankStaff> GetEmployeeList()
        {
            if (MasterBank.currentBank.bankStaffList.Count > 0)
            {
                return MasterBank.currentBank.bankStaffList;
            }
            else
                return null;
        }

        


    }
}
