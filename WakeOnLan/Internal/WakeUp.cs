using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WakeOnLan
{
    internal class WakeUp
    {
        internal static async Task<ClientResult> SendMagicPacketAsync(byte[] Mac, int Port)
        {
            var result = new ClientResult();

            //MAC-Adresse NULL?
            if (Mac == null)
            {
                result.Result = "Es wurde keine MAC-Adresse angegeben";
                result.Success = false;
                return result;
            }

            //Länge der MAC-Adresse muss sechs Byte betragen
            if (Mac.Length != 6)
            {
                result.Result = "Die angegebene MAC-Adresse hat nicht die erforderliche Länge von 6 Byte";
                result.Success = false;
                return result;
            }

            try
            {
                //UDP-Client initialisieren und Port festlegen
                UdpClient client = new UdpClient();
                client.Connect(IPAddress.Broadcast, Port);

                //Feste Magic-Packet-Länge: 6 Byte Trailer und 16x die MAC-Adresse
                byte[] packet = new byte[6 + 16 * 6];

                //6 Byte langen Trailer beschreiben
                for (int i = 0; i < 6; i++)
                    packet[i] = 0xFF;

                //16x die MAC-Adresse beschreiben
                for (int i = 1; i <= 16; i++)
                    for (int j = 0; j < 6; j++)
                        packet[i * 6 + j] = Mac[j];

                //Magic-Packet versenden und Erfolg melden
                await client.SendAsync(packet, packet.Length);
                result.Result = "Der Befehl zum Aufwachen wurde an die MAC-Adresse '" + BitConverter.ToString(Mac) + "' gesendet";
                result.Success = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Result = ex.Message;
                result.Success = false;
                return result;
            }
        }
    }
}
