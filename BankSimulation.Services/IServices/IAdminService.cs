using System;
using System.Collections.Generic;
using BankSimulation.Model;

namespace BankSimulation.Service.IServices
{
   public interface IAdminService
    {
        void AddNewAdmin(BankStaff admin);
        bool AdminLogin(string username, string password);
        bool IsDuplicateBankStaff(string id);
    }
}
