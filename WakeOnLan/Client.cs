using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakeOnLan
{
    public class Client
    {
        public async Task<ClientResult> WakeUpLocalAsync(string MacAddress)
        {
            return await WakeUpLocalAsync(MacAddress, Ports.WakeUp);
        }

        public async Task<ClientResult> WakeUpLocalAsync(string MacAddress, int WakeUpPort)
        {
            //Mac-Adresse in Byte-Array konvertieren - Fehler -> Abbruch
            if (!Convert.MacAddressStringToByteArray(MacAddress, out byte[] mac, out string Result))
                return new ClientResult() { Result = Result, Success = false };

            //Port prüfen
            if (!Check.CheckPortInUserPortRange(WakeUpPort, out Result))
                return new ClientResult() { Result = Result, Success = false };

            //MagicPacket versenden
            return await WakeUp.SendMagicPacketAsync(mac, WakeUpPort);
        }

        public async Task<ClientResult> WakeUpByServerAsync(string ServerIpAddress, string MacAddress, string ClientProgrammName)
        {
            return await WakeUpByServerAsync(ServerIpAddress, MacAddress, ClientProgrammName, Ports.Server);
        }

        public async Task<ClientResult> WakeUpByServerAsync(string ServerIpAddress, string MacAddress, string ClientProgrammName, int ServerPort)
        {
            //Mac-Adresse in Byte-Array konvertieren - Fehler -> Abbruch
            if (!Convert.MacAddressStringToByteArray(MacAddress, out byte[] mac, out string Result))
                return new ClientResult() { Result = Result, Success = false };

            //Port prüfen
            if (!Check.CheckPortInUserPortRange(ServerPort, out Result))
                return new ClientResult() { Result = Result, Success = false };

            try
            {
                //MAC-Adresse zum Aufwecken an den Server senden
                ClientHelper client = new ClientHelper(ServerIpAddress, ServerPort);
                await client.SendAsync(new ClientToServer
                {
                    MacAddress = mac,
                    UserDomainName = Environment.UserDomainName,
                    UserName = Environment.UserName,
                    ClientProgramName = ClientProgrammName,
                });

                //Auf Antwort des Server warten
                ServerToClient answer = (ServerToClient) await client.ReceiveAsync();
                client.Close();

                //Antwort ausgeben
                return new ClientResult() { Result = answer.Result, Success = answer.WakeUpSuccess };
            }
            catch (Exception ex)
            {
                return new ClientResult() { Result = ex.Message, Success = false };
            }
        }
    }

    public class ClientResult
    {
        public bool Success { get; internal set; }
        public string Result { get; internal set; }
    }
}
