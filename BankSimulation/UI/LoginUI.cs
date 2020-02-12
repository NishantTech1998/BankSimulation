using System;
using Validator;

namespace BankSimulation.UI
{
    public class LoginUI
    {

        public static string SelectLoginOption()
        {
            Console.Clear();
            Menu.LoginMenu();
            string selectLoginResponse = ValidatorHelper.StringValidator(100, 40);
            return selectLoginResponse;
        }
    }
}
