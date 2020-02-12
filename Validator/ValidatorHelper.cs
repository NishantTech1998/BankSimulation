using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;
using Display;


namespace Validator
{
        public static class ValidatorHelper
        {

        public static string StringValidator(int x, int y)
        {
            string result;

            do
            {
                DisplayHelper.PrintTextAtXY(x, y, "\t\t\t\t\t\t\t");
                Console.SetCursorPosition(x, y);
                result = Console.ReadLine();
                if (string.IsNullOrEmpty(result) || result.Contains("  "))
                { DisplayHelper.PrintTextAtXY(x, y, "You Cannot Leave This Field Blank"); Thread.Sleep(800); }
            } while (string.IsNullOrEmpty(result) || result.Contains("  "));

            return result;
        }

        public static string EmailValidator(int x, int y)
        {

            string email;

            do
            {
                email = StringValidator(x, y);
                if (!(email.Contains("@") && !(email.StartsWith("@") && !(email.StartsWith("."))) && !(email.EndsWith(".com") || email.EndsWith(".org")
                || email.EndsWith(".net") || email.EndsWith(".ac.in") || email.EndsWith(".edu")
                || email.EndsWith(".gov") || email.EndsWith(".in"))))
                { DisplayHelper.PrintTextAtXY(x, y, "email Id is Invalid"); Thread.Sleep(800); }
                else { break; }

            } while (true);

            return email.ToLower();
        }

        public static string PanValidator(int x, int y)
        {
            string panNumber;
            string strRegex = @"(^[A-Z]{5}[0-9]{4}[A-Z]$)";
            Regex re = new Regex(strRegex);
            do
            {
                panNumber = StringValidator(x, y);
                if (re.IsMatch(panNumber))
                {
                    break;
                }
                else { DisplayHelper.PrintTextAtXY(x, y, "Pan Number Is Invalid"); Thread.Sleep(800); }
            } while (true);

            return panNumber;
        }

        public static long PhoneValidator(int x, int y)
        {
            string phoneNumber;

            string strRegex = @"(^[0-9]{10}$)";
            Regex re = new Regex(strRegex);

            do
            {
                phoneNumber = StringValidator(x, y);
                if (re.IsMatch(phoneNumber))
                {
                    break;
                }
                else { DisplayHelper.PrintTextAtXY(x, y, "Phone Number Is Invalid"); Thread.Sleep(800); }
            } while (true);

            return long.Parse(phoneNumber);
        }

        public static DateTime DateValidator(int x, int y)
        {
            string date;

            string strRegex = @"(^[0-3][0-9]/[0-1][0-9]/19[5-9][0-9]$)|(^[0-3][0-9]/[0-1][0-9]/200[0-2]$)";
            Regex re = new Regex(strRegex);

            do
            {
                date = StringValidator(x, y);
                if (re.IsMatch(date))
                    break;
                else
                {
                    DisplayHelper.PrintTextAtXY(x, y, "Entered Date is Invalid");
                    Thread.Sleep(800);
                }
            } while (true);

            return DateTime.Parse(date);
        }

        public static double DoubleValidator(int x, int y)
        {
            string result;

            string strRegex = @"(^[0-9]+?\.[0-9]+?$)|(^[0-9]+?$)|(^\.[0-9]+?)";
            Regex re = new Regex(strRegex);

            do
            {
                result = StringValidator(x, y);
                if (re.IsMatch(result))
                {
                    break;
                }
                else { DisplayHelper.PrintTextAtXY(x, y, "Entered Value is not Decimal Value"); Thread.Sleep(800); }
            } while (true);

            return double.Parse(result);
        }

        public static string NameValidator(int x, int y)
        {
            string name;

            do
            {
                name = StringValidator(x, y);
                if (name.Length < 3)
                { DisplayHelper.PrintTextAtXY(x, y, "name Should Not Be Less than 3 Characters"); Thread.Sleep(800); }
            } while (name.Length < 3);

            return name.ToUpper();
        }

        public static string MenuChoiceValidator(int x, int y)
        {
            string result;

            string strRegex = @"(^[1-9]$)";
            Regex re = new Regex(strRegex);

            do
            {
                result = StringValidator(x, y);
                if (re.IsMatch(result))
                {
                    break;
                }
                else { DisplayHelper.PrintTextAtXY(x, y, "Incorrect Choice"); Thread.Sleep(800); }
            } while (true);

            return result;
        }

    }
}

