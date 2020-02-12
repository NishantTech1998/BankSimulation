using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.Model
{
    [Serializable]
    public class TransferCharge
    {
        public double ImpsCharge { get;  set; }
        public double RtgsCharge { get;  set; }
        
    }
}
