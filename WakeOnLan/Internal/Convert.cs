using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakeOnLan
{
    internal static class Convert
    {
        internal static bool MacAddressStringToByteArray(string MacAddress, out byte[] Mac, out string Result)
        {
            //Alle möglichen Trennzeichen zunächst entfernen
            MacAddress = MacAddress.Replace(":", "").Replace("-", "").Replace(" ", "");

            //Nun muss die Eingabe 12 Zeichen lang sein
            if (MacAddress.Length != 12)
            {
                Result = "Die von Ihnen eingegebene MAC-Adresse ist ungültig (Erwartet: AA:BB:CC:AA:BB:CC)";
                Mac = null;
                return false;
            }

            //MAC-Adresse in Byte-Array konvertieren
            Mac = new byte[6];
            Mac[0] = System.Convert.ToByte(MacAddress[0].ToString() + MacAddress[1].ToString(), 16);
            Mac[1] = System.Convert.ToByte(MacAddress[2].ToString() + MacAddress[3].ToString(), 16);
            Mac[2] = System.Convert.ToByte(MacAddress[4].ToString() + MacAddress[5].ToString(), 16);
            Mac[3] = System.Convert.ToByte(MacAddress[6].ToString() + MacAddress[7].ToString(), 16);
            Mac[4] = System.Convert.ToByte(MacAddress[8].ToString() + MacAddress[9].ToString(), 16);
            Mac[5] = System.Convert.ToByte(MacAddress[10].ToString() + MacAddress[11].ToString(), 16);

            //Alles OK
            Result = "Die MAC-Adresse ist korrekt";
            return true;
        }
    }
}
