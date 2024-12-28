using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WakeOnLan
{
    internal class SerializeData
    {
        public byte[] Serialize(ClientToServer data)
        {
            using var ms = new MemoryStream();
            using (var writer = new BinaryWriter(ms))
            {
                writer.Write(data.ClientProgramName);
                writer.Write(data.MacAddress);
                writer.Write(data.UserName);
                writer.Write(data.UserDomainName);
            }
            return ms.ToArray();
        }

        public byte[] Serialize(ServerToClient data)
        {
            using var ms = new MemoryStream();
            using (var writer = new BinaryWriter(ms))
            {
                writer.Write(data.Result);
                writer.Write(data.WakeUpSuccess);
            }
            return ms.ToArray();
        }

        public ClientToServer DeserializeC(byte[] data)
        {
            var result = new ClientToServer();
            using (var ms = new MemoryStream(data))
            {
                using var reader = new BinaryReader(ms);
                result.ClientProgramName = reader.ReadString();
                result.MacAddress = reader.ReadBytes(6);
                result.UserName = reader.ReadString();
                result.UserDomainName = reader.ReadString();
            }
            return result;
        }

        public ServerToClient DeserializeS(byte[] data)
        {
            var result = new ServerToClient();
            using (var ms = new MemoryStream(data))
            {
                using var reader = new BinaryReader(ms);
                result.Result = reader.ReadString();
                result.WakeUpSuccess = reader.ReadBoolean();
            }
            return result;
        }
    }
}
