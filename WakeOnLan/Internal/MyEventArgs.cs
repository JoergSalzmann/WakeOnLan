using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakeOnLan
{
    public class BoolEventArgs : EventArgs
    {
        public bool Value { get; private set; }

        internal BoolEventArgs(bool Value)
        {
            this.Value = Value;
        }
    }

    public class StringEventArgs : EventArgs
    {
        public string Message { get; private set; }

        public StringEventArgs(string Message)
        {
            this.Message = Message;
        }
    }

    internal class ReceiveEventArgs : EventArgs
    {
        internal  ServerHelper Client { get; private set; }
        internal object Data { get; private set; }

        internal ReceiveEventArgs(ServerHelper Client,object Data)
        {
            this.Client = Client;
            this.Data = Data;
        }
    }
}
