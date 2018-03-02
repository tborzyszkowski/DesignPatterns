using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DesignPatternsProject.Decorator;
using DesignPatternsProject.Extension;
using DesignPatternsProject.Interfaces;
using DesignPatternsProject.Strategy;

namespace DesignPatternsProject.Communication
{
    public sealed class MultiCommunication : IBaseCommunication, ICommunication
    {
        private static MultiCommunication instance = null;
        private static readonly object padlock = new object();
        private bool CloseExistingConnectionOnCall = false;

        private static StreamWriter writer;

        public MultiCommunication()
        {
        }

        public static MultiCommunication Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new MultiCommunication();
                        }
                    }
                }
                return instance;
            }
        }

        public void CloseServer()
        {
            CloseExistingConnectionOnCall = true;
            SingleCommunication.listener.Server.Close();
            SingleCommunication.listener.Stop();
            connectedClients = new Dictionary<int, ConnectedClientDecarated>();
            ClientConcreteComponent.NumberOfConnectedClient = 0;
        }

        public void CreatServer()
        {
            CloseExistingConnectionOnCall = false;

            try
            {
                SingleCommunication.listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
                SingleCommunication.listener.Start();
                Console.WriteLine("MultiThreadedEchoServer started...");
                while (true)
                {
                    Console.WriteLine("Waiting for incoming client connections...");
                    TcpClient client = SingleCommunication.listener.AcceptTcpClient();
                    Console.WriteLine("Accepted new client connection...");
                    Thread t = new Thread(ProcessClientRequests);
                    t.Start(client);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (SingleCommunication.listener != null)
                {
                    SingleCommunication.listener.Server.Close();
                    SingleCommunication.listener.Stop();
                }
            }
        }

        private List<TcpClient> ClientList = new List<TcpClient>();

        public void SeverSendMessage(string message = null)
        {
                foreach (var client in connectedClients)
                {
                    client.Value.GetClientStreamWriter().WriteLine($"From {message}");
                    client.Value.GetClientStreamWriter().Flush();
                }
        }

        private void ChangeClientName(int key, string newName)
        {
            var clientObject = connectedClients[key];
            clientObject.SetClientName(newName);
        }


        private static Dictionary<int,ConnectedClientDecarated> connectedClients = new Dictionary<int, ConnectedClientDecarated>();

        public void ProcessClientRequests(object argument)
        {
            string clientName = $"Client {ClientConcreteComponent.NumberOfConnectedClient}";
            connectedClients.Add(ClientConcreteComponent.NumberOfConnectedClient, new ConnectedClientDecarated(new ClientConcreteComponent(((TcpClient)argument), clientName)));

            int clientDictrionaryKey = ClientConcreteComponent.NumberOfConnectedClient;
            TcpClient client = (TcpClient)argument;
            bool playGame = false;
            Random random = new Random();
            int number = random.Next(1, 100);

            try
            {
                StreamReader reader = new StreamReader(client.GetStream());
                writer = new StreamWriter(client.GetStream());

                ClientList.Add(client);

                //Thread thread;
                //thread = new Thread(() => SeverSendMessage($"Connected. {clientName} "));
                //thread.Start();

                SeverSendMessage($"Connected. {clientName} ");

                var s = String.Empty;
                while (!(s = reader.ReadLine()).Equals("Exit") || (s == null))
                {
                    clientName = connectedClients[clientDictrionaryKey - 1].GetClientName();
                    s = s.Trim();

                    if (s == "im exit")
                    {
                        connectedClients.Remove(clientDictrionaryKey-1);
                        break;
                    }
                    if (CloseExistingConnectionOnCall)
                    {
                        break;
                    }

                    if (playGame && !s.Equals(null))
                    {
                        try
                        {
                            string response = ExtensionsMethods.Game(number, Int32.Parse(s));

                            SeverSendMessage($"{clientName} {response}");
                            //thread = new Thread(() => SeverSendMessage($"{clientName} {response}"));
                            //thread.Start();
                        }
                        catch (Exception e) { }
                    }
                    if (s.Contains("command change name"))
                    {
                        ChangeClientName(clientDictrionaryKey - 1, "new client name");
                        Console.WriteLine("From client -> " + s);

                        SeverSendMessage($"{clientName}:  {s}");
                        //thread = new Thread(() => SeverSendMessage($"{clientName}:  {s}"));
                        //thread.Start();
                    }
                    if (s.Contains("show info"))
                    {
                        s = s.Remove(0, 10).Trim();
                        var adapterFunctionality = new StrategyFunctionality();
                        s = adapterFunctionality.ComponentInformation(s);

                        Console.WriteLine("From client -> " + s);

                        SeverSendMessage($"{clientName}:  {s}");
                        //thread = new Thread(() => SeverSendMessage($"{clientName}:  {s}"));
                        //thread.Start();
                    }
                    else
                    {
                        Console.WriteLine("From client -> " + s);
                        SeverSendMessage($"{clientName}:  {s}");
                        //thread = new Thread(() => SeverSendMessage($"{clientName}:  {s}"));
                        //thread.Start();
                    }
                    if (s == "game")
                    {
                        playGame = true;
                    }
                }
                reader.Close();
                writer.Close();
                client.Close();
                Console.WriteLine("Closing client connection!");
            }
            catch (IOException)
            {
                Console.WriteLine("Problem with client communication. Exiting thread.");
            }
            catch (Exception) { }
            finally
            {
                if (client != null)
                {
                    client.Close();
                }
            }
        }
    }
}
