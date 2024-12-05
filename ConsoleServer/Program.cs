// See https://aka.ms/new-console-template for more information
var server = new WakeOnLan.Server();
server.DebugMessage += (s, ea) => Console.WriteLine(ea.Message);
server.WakeUpSucces += (s, ea) => Console.WriteLine(ea.Message);
server.WakeUpSuccessMAC += (s, ea) => Console.WriteLine(ea.Message);
server.ExceptionRaised += (s, ea) => Console.WriteLine(ea.Message);
server.ListenChanged += (s, ea) => Console.WriteLine($"WOL aktiv: {ea.Value}");
server.RequestFromClient += (e, ea) => Console.WriteLine(ea.Message);
server.Start();

Console.ReadKey();
Console.WriteLine();
server.Stop();
