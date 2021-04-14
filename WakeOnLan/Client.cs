using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakeOnLan
{
    public class Client
    {
        public bool WakeUpLocal(string MacAddress, out string Result)
        {
            return WakeUpLocal(MacAddress, Ports.WakeUp, out Result);
        }

        public bool WakeUpLocal(string MacAddress, int WakeUpPort, out string Result)
        {
            //Mac-Adresse in Byte-Array konvertieren - Fehler -> Abbruch
            if (!Convert.MacAddressStringToByteArray(MacAddress, out byte[] mac, out Result))
                return false;

            //Port prüfen
            if (!Check.CheckPortInUserPortRange(WakeUpPort, out Result))
                return false;

            //MagicPacket versenden
            return WakeUp.SendMagicPacket(mac, WakeUpPort, out Result);
        }

        public async Task<ClientResult> WakeUpLocalAsync(string MacAddress)
        {
            return await WakeUpLocalAsync(MacAddress, Ports.WakeUp);
        }

        public async Task<ClientResult> WakeUpLocalAsync(string MacAddress, int WakeUpPort)
        {
            var clientResult = new ClientResult();

            await Task.Run(delegate
            {
                clientResult.Success = WakeUpLocal(MacAddress, WakeUpPort, out string Result);
                clientResult.Result = Result;
            });

            return clientResult;
        }

        public bool WakeUpByServer(string ServerIpAddress, string MacAddress, string ClientProgrammName, out string Result)
        {
            return WakeUpByServer(ServerIpAddress, MacAddress, ClientProgrammName, Ports.Server, out Result);
        }

        public bool WakeUpByServer(string ServerIpAddress, string MacAddress, string ClientProgrammName, int ServerPort, out string Result)
        {
            //Mac-Adresse in Byte-Array konvertieren - Fehler -> Abbruch
            if (!Convert.MacAddressStringToByteArray(MacAddress, out byte[] mac, out Result))
                return false;

            //Port prüfen
            if (!Check.CheckPortInUserPortRange(ServerPort, out Result))
                return false;

            try
            {
                //MAC-Adresse zum Aufwecken an den Server senden
                ClientHelper client = new ClientHelper(ServerIpAddress, ServerPort);
                client.Send(new ClientToServer
                {
                    MacAddress = mac,
                    UserDomainName = Environment.UserDomainName,
                    UserName = Environment.UserName,
                    ClientProgramName = ClientProgrammName,
                });

                //Auf Antwort des Server warten
                ServerToClient answer = (ServerToClient)client.Receive();
                client.Close();

                //Antwort ausgeben
                if (answer != null)
                {
                    Result = answer.Result;
                    return answer.WakeUpSuccess;
                }
                else
                {
                    Result = "Die Anfrage zum Aufwecken wurde an den Server gesendet, es wurde jedoch keine Antwort empfangen";
                    return false;
                }
            }
            catch (Exception ex)
            {
                Result = ex.Message;
                return false;
            }
        }

        public async Task<ClientResult> WakeUpByServerAsync(string ServerIpAddress, string MacAddress, string ClientProgrammName)
        {
            return await WakeUpByServerAsync(ServerIpAddress, MacAddress, ClientProgrammName, Ports.Server);
        }

        public async Task<ClientResult> WakeUpByServerAsync(string ServerIpAddress, string MacAddress, string ClientProgrammName, int ServerPort)
        {
            var clientResult = new ClientResult();

            await Task.Run(delegate
            {
                clientResult.Success = WakeUpByServer(ServerIpAddress, MacAddress, ClientProgrammName, ServerPort, out string Result);
                clientResult.Result = Result;
            });

            return clientResult;
        }
    }

    public class ClientResult
    {
        public bool Success { get; internal set; }
        public string Result { get; internal set; }
    }
}
