using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakeOnLan
{
    internal class ClientServerProperties
    {
        internal const int BufferSize = 10240;
        internal const int MaxClients = 100;
        internal const int SleepTimeClient = 50;
        internal const int SleepTimeServer = 200;
        internal const int TimeOut = 10 * 1000;
    }

    [Serializable]
    internal class ClientToServer
    {
        internal byte[] MacAddress;
        internal string UserDomainName;
        internal string UserName;
        internal string ClientProgramName;
    }

    [Serializable]
    internal class ServerToClient
    {
        internal bool WakeUpSuccess;
        internal string Result;
    }
}
