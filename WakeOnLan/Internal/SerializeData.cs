using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WakeOnLan
{
    internal class SerializeData
    {
        internal byte[] Serialize(object Data)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, Data);
                return ms.ToArray();
            }
        }

        internal object Deserialize(byte[] Data)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(Data, 0, Data.Length);
                ms.Seek(0, SeekOrigin.Begin);
                return new BinaryFormatter().Deserialize(ms);
            }
        }
    }
}
