using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakeOnLan
{
    internal class Check
    {
        internal static bool CheckPortInUserPortRange(int Port, out string Result)
        {
            if (Port >= 1024 && Port <= 49151)
            {
                Result = string.Empty;
                return true;
            }
            else
            {
                Result = "Der Port muss zwischen 1024 und 49151 liegen";
                return false;
            }
        }
    }
}
