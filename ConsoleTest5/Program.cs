using System;
using System.Collections.Generic;
using WakeOnLan;

namespace ConsoleTest5
{
    class Program
    {
        static int magicPacketPort = 30123;
        static int serverPort = 30456;

        static void Main(string[] args)
        {
            int count = 0;
            var monitor = new Monitor();
            monitor.ExceptionRaised += (s, ea) => Console.WriteLine(ea.Message);
            //monitor.ListenChanged += (s, ea) => Console.WriteLine(ea.Value);
            monitor.WakeUpReceived += (s, ea) => Console.WriteLine(++count);
            monitor.Start(magicPacketPort);

            var server = new Server();
            //server.DebugMessage += (s, ea) => Console.WriteLine(ea.Message);
            //server.ExceptionRaised += (s, ea) => Console.WriteLine(ea.Message);
            //server.ListenChanged += (s, ea) => Console.WriteLine(ea.Value);
            //server.RequestFromClient += (s, ea) => Console.WriteLine(ea.Message);
            //server.WakeUpSucces += (s, ea) => Console.WriteLine(ea.Message);
            //server.WakeUpSuccessMAC += (s, ea) => Console.WriteLine(ea.Message);
            server.Start(serverPort, magicPacketPort);

            var client = new Client();
            //client.WakeUpLocal("AA-AA-AA-AA-AA-AA", magicPacketPort, out string Result);
            //Console.WriteLine(Result);
            //Task.Run(async delegate
            //{
            //    var clientResult = await client.WakeUpLocalAsync("AA-AA-AA-AA-AA-AA", magicPacketPort);
            //    Console.WriteLine(clientResult.Success + " - " + clientResult.Result);
            //}).Wait();
            //for(int i=0;i<50;i++)
            //client.WakeUpByServer("127.0.0.1", "AA-AA-AA-AA-AA-AA", "Test", serverPort, out string Result);
            //Console.WriteLine(Result);
            //Task.Run(async delegate
            //{
            //    var clientResult = await client.WakeUpByServerAsync("127.0.0.1", "AA-AA-AA-AA-AA-AA", "Test", serverPort);
            //    Console.WriteLine(clientResult.Success + " - " + clientResult.Result);
            //}).Wait();

            List<System.Threading.Thread> threads = new List<System.Threading.Thread>();
            for (int i = 0; i < 50; i++)
            {
                //threads.Add(new System.Threading.Thread(new System.Threading.ThreadStart(delegate
                //{
                //    client.WakeUpByServer("127.0.0.1", "AA-AA-AA-AA-AA-AA", "Test " + i, serverPort, out string Result);
                //})));

                System.Threading.Thread th = new System.Threading.Thread(new System.Threading.ThreadStart(delegate
                {
                    bool success = client.WakeUpByServer("127.0.0.1", "AA-AA-AA-AA-AA-AA", "Test " + i, serverPort, out string Result);
                    Console.WriteLine(success + " - " + Result);
                }));
                th.Start();
                //System.Threading.Thread.Sleep(1000);
            }
            //foreach (System.Threading.Thread th in threads)
            //    th.Start();

            Console.ReadKey();
            Console.WriteLine();
            monitor.Stop();
            server.Stop();
            System.Threading.Thread.Sleep(1000);
        }
    }
}
