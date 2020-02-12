using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSimulation.Model;
using BankSimulation.Service.Services;

using BankSimulation.Service.IServices;
using Display;
using Validator;

namespace BankSimulation.UI
{
    public class EmployeeUI
    {
        private readonly IEmployeeService employeeService;

        public EmployeeUI(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public bool EmployeeLoginDisplay()
        {
            Console.Clear();
            InputForm.LoginInputField();
            string employeeId = ValidatorHelper.StringValidator(40, 10);
            string password = ValidatorHelper.StringValidator(40, 12);
            bool isValid = employeeService.EmployeeLogIn(employeeId, password);
            if (isValid == true)
                return true;
            else
                return false;
        }

        public string EmployeeMenu()
        {
            Console.Clear();
            Menu.AdminMenu();
            string response = ValidatorHelper.MenuChoiceValidator(100, 40);
            return response;
        }

        public void CreateEmployeeDisplay()
        {
            Console.Clear();
            string bankStaffId;
            InputForm.AddEmployeeField();
            BankStaff employee = new BankStaff();
            employee.FirstName = ValidatorHelper.StringValidator(40, 10);
            employee.LastName = ValidatorHelper.StringValidator(40, 12);
            employee.Dob = ValidatorHelper.DateValidator(40, 14);
            employee.Email = ValidatorHelper.EmailValidator(40, 16);
            employee.PanNumber = ValidatorHelper.PanValidator(40, 18);
            employee.ContactNumber = ValidatorHelper.PhoneValidator(40, 20);
            employee.address.addressLine1 = ValidatorHelper.StringValidator(40, 22);
            employee.address.addressLine2 = ValidatorHelper.StringValidator(40, 24);
            employee.address.city = ValidatorHelper.StringValidator(40, 26);
            employee.address.state = ValidatorHelper.StringValidator(40, 28);
            employee.address.pincode = ValidatorHelper.StringValidator(40, 30);
            employee.BankStaffRole = ValidatorHelper.StringValidator(40, 32); ;
            do
            {
                bankStaffId = ValidatorHelper.StringValidator(40, 34);
                if (employeeService.IsDuplicateBankStaff(bankStaffId))
                    break;
            } while (true);
            employee.BankStaffId=(bankStaffId);
            employee.Password=(ValidatorHelper.StringValidator(40, 36));
            employeeService.AddNewBankStaff(employee);
        }

        public void UpdateEmployeeDisplay()
        {
            Console.Clear();
            ViewEmployee();
            Console.WriteLine("\t\t\tEnter Id to update\n\t\t\tEnter B to go back");
            string UpdateResponse = ValidatorHelper.StringValidator(120, 13);
            if (UpdateResponse != "B")
            {
                Console.Clear();
                InputForm.AddEmployeeField();
                BankStaff employee = employeeService.GetBankStaffById(UpdateResponse);
                if (employee != null)
                {
                    DisplayHelper.PrintTextAtXY(40, 10, employee.FirstName);
                    DisplayHelper.PrintTextAtXY(40, 12, employee.LastName);
                    DisplayHelper.PrintTextAtXY(40, 14, employee.Dob.ToString());
                    DisplayHelper.PrintTextAtXY(40, 16, employee.Email);
                    DisplayHelper.PrintTextAtXY(40, 18, employee.PanNumber);
                    DisplayHelper.PrintTextAtXY(40, 20, employee.ContactNumber.ToString());
                    DisplayHelper.PrintTextAtXY(40, 22, employee.address.addressLine1);
                    DisplayHelper.PrintTextAtXY(40, 24, employee.address.addressLine2);
                    DisplayHelper.PrintTextAtXY(40, 26, employee.address.city);
                    DisplayHelper.PrintTextAtXY(40, 28, employee.address.state);
                    DisplayHelper.PrintTextAtXY(40, 30, employee.address.pincode);
                    DisplayHelper.PrintTextAtXY(40, 32, employee.BankStaffRole);
                    DisplayHelper.PrintTextAtXY(40, 34, employee.BankStaffId);
                    DisplayHelper.PrintTextAtXY(40, 36, "**********");
                    string FieldToUpdate;
                    do
                    {
                        DisplayHelper.PrintTextAtXY(40, 40, "Enter The Field No To Update or Q to go back");
                        FieldToUpdate = ValidatorHelper.StringValidator(40, 42);
                        if (FieldToUpdate == "1") { employee.FirstName = ValidatorHelper.StringValidator(40, 10); }
                        else if (FieldToUpdate == "2") { employee.LastName = ValidatorHelper.StringValidator(40, 12); }
                        else if (FieldToUpdate == "3") { employee.Dob = ValidatorHelper.DateValidator(40, 14); }
                        else if (FieldToUpdate == "4") { employee.Email = ValidatorHelper.EmailValidator(40, 16); }
                        else if (FieldToUpdate == "5") { employee.PanNumber = ValidatorHelper.PanValidator(40, 18); }
                        else if (FieldToUpdate == "6") { employee.ContactNumber = ValidatorHelper.PhoneValidator(40, 20); }
                        else if (FieldToUpdate == "7") { employee.address.addressLine1 = ValidatorHelper.StringValidator(40, 22); }
                        else if (FieldToUpdate == "8") { employee.address.addressLine2 = ValidatorHelper.StringValidator(40, 24); }
                        else if (FieldToUpdate == "9") { employee.address.city = ValidatorHelper.StringValidator(40, 26); }
                        else if (FieldToUpdate == "10") { employee.address.state = ValidatorHelper.StringValidator(40, 28); }
                        else if (FieldToUpdate == "11") { employee.address.pincode = ValidatorHelper.StringValidator(40, 30); }
                        else if (FieldToUpdate == "12") { employee.BankStaffRole = ValidatorHelper.StringValidator(40, 32); }
                        else if (FieldToUpdate == "13") { DisplayHelper.PrintTextAtXY(40, 42, "CANNOT CHANGE THIS FIELD"); }
                        else if (FieldToUpdate == "14") { DisplayHelper.PrintTextAtXY(40, 42, "CANNOT CHANGE THIS FIELD"); }
                        else { DisplayHelper.PrintTextAtXY(40, 42, "INVALID FIELD SELECTED"); }
                    } while (FieldToUpdate != "Q");
                }
                employeeService.UpdateBankStaff(employee);
            }
        }

        public void DeleteEmployeeDisplay()
        {
            Console.Clear();
            ViewEmployee();
            DisplayHelper.PrintTextAtXY(100, 60, "Enter Id to delete or Enter B to go back");
            string DeleteResponse = ValidatorHelper.StringValidator(120, 13);
            if (DeleteResponse != "B")
            {
                employeeService.DeleteBankStaff(DeleteResponse);
            }
        }

        public void ViewEmployee()
        {
            Console.Clear();
            DisplayHelper.Title();
            int width = Console.WindowWidth;
            DisplayHelper.CreateBoxAtXY(100, 2, 40, 4, '*', '*');
            DisplayHelper.PrintTextAtXY(42, 5, "Bank Staff Id |");
            DisplayHelper.PrintTextAtXY(58, 5, "First Name |");
            DisplayHelper.PrintTextAtXY(71, 5, "Last Name |");
            DisplayHelper.PrintTextAtXY(83, 5, "Email Id                   |");
            DisplayHelper.PrintTextAtXY(120, 5, "Designation");
            int printingGap = 0;

            foreach (BankStaff bankStaff in employeeService.GetAllStaffs())
            {
                DisplayHelper.PrintTextAtXY(42, 8 + printingGap, bankStaff.BankStaffId);
                DisplayHelper.PrintTextAtXY(58, 8 + printingGap, bankStaff.FirstName);
                DisplayHelper.PrintTextAtXY(71, 8 + printingGap, bankStaff.LastName);
                DisplayHelper.PrintTextAtXY(83, 8 + printingGap, bankStaff.Email);
                DisplayHelper.PrintTextAtXY(120, 8 + printingGap, bankStaff.BankStaffRole);
                printingGap = printingGap + 1;
            }
        }

       


    }
}
