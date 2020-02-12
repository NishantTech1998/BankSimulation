using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.UI.Enums
{
    class EnumHelper
    {
        public static int GetValidInteger(string value)
        {
            if (!int.TryParse(value, out int result))
            {
                return 0;
            }

            return result;
        }

        public static T ConvertInEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T),GetValidInteger(value).ToString());
        }
    }
}
