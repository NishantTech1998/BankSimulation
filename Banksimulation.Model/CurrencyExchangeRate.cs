using System;
using System.Collections.Generic;
using System.Text;

namespace BankSimulation.Model
{
    [Serializable]
    public class CurrencyExchangeRate
    {
        public string Currency { get; set; }
        public double Rate { get; set; }
    }
}
