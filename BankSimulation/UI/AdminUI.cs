using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSimulation.Model;
using BankSimulation.Service.Services;
using BankSimulation.Data.DataServices;
using BankSimulation.Service.IServices;
using Validator;

namespace BankSimulation.UI
{
    public class AdminUI
    {
        private readonly IAdminService adminService;

        public AdminUI(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        public void CreateDefaultAdminDisplay()
        {
            MasterBank.currentBank = MasterBank.bankList[MasterBank.bankList.Count - 1];
            Console.Clear();
            string bankStaffId;
            InputForm.AddEmployeeField();
            BankStaff admin = new BankStaff();
            admin.FirstName = ValidatorHelper.StringValidator(40, 10);
            admin.LastName = ValidatorHelper.StringValidator(40, 12);
            admin.Dob = ValidatorHelper.DateValidator(40, 14);
            admin.Email = ValidatorHelper.EmailValidator(40, 16);
            admin.PanNumber = ValidatorHelper.PanValidator(40, 18);
            admin.ContactNumber = ValidatorHelper.PhoneValidator(40, 20);
            admin.address.addressLine1 = ValidatorHelper.StringValidator(40, 22);
            admin.address.addressLine2 = ValidatorHelper.StringValidator(40, 24);
            admin.address.city = ValidatorHelper.StringValidator(40, 26);
            admin.address.state = ValidatorHelper.StringValidator(40, 28);
            admin.address.pincode = ValidatorHelper.StringValidator(40, 30);
            admin.BankStaffRole = "Admin";
            do
            {
                bankStaffId = ValidatorHelper.StringValidator(40, 34);
                if (adminService.IsDuplicateBankStaff(bankStaffId))
                    break;
            } while (true);
            admin.BankStaffId=(bankStaffId);
            admin.Password=(ValidatorHelper.StringValidator(40, 36));
            adminService.AddNewAdmin(admin);
        }

        public bool AdminLoginDisplay()
        {

            Console.Clear();
            InputForm.LoginInputField();
            string adminId = ValidatorHelper.StringValidator(40, 10);
            string password = ValidatorHelper.StringValidator(40, 12);
            bool isValid = adminService.AdminLogin(adminId, password);
            if (isValid == true)
                return true;
            else
                return false;

        }

        public static string AdminMenu()
        {
            Console.Clear();
            Menu.AdminMenu();
            string response = ValidatorHelper.StringValidator(100, 40);
            return response;
        }


    }
}
