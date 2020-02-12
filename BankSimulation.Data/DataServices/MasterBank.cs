using System;
using System.Collections.Generic;
using System.Text;
using BankSimulation.Model;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BankSimulation.Data.DataServices
{
    public class MasterBank
    {
        const string fileName = "BankData.data";
        public static Bank currentBank;
        public static List<Bank> bankList;
        public static int checkFor;
        public static string currentAccountHolder;
        public static int currentBankIndex;

        public static void GetBanksFromFile()
        {
            if (File.Exists(fileName))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    bankList = (List<Bank>)formatter.Deserialize(stream);
                }
            }
            else
            {
                bankList = new List<Bank>();
            }
        }

        public static void SaveBanksInFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                formatter.Serialize(stream, bankList);
            }
        }

        public static void SaveCurrentState()
        {
            bankList[bankList.FindIndex(bank => bank.BankId == currentBank.BankId)] = currentBank;
            SaveBanksInFile();
        }

        public static Bank GetBankById(string Id)
        {
            return bankList[bankList.FindIndex(bank => bank.BankId == Id)];
        }
    }
}
