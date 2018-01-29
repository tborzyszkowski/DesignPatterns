using DesignPatternsProject.Extension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using DesignPatternsProject.Adapter;
using DesignPatternsProject.Interfaces;
using DesignPatternsProject.Strategy;

namespace DesignPatternsProject.Communication
{
    public sealed class CommunicationBase : IBaseCommunication, ICommunication
    {
        private static CommunicationBase instance = null;
        private static readonly object padlock = new object();
        private bool CloseExistingConnectionOnCall = false;
        //private TcpSingleCommunication.listener SingleCommunication.listener = null;

        public CommunicationBase()
        {
        }

        public static CommunicationBase Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new CommunicationBase();
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
                    SingleCommunication.listener.Stop();
                }
            }
        }

        public void SeverSendMessage(StreamWriter writer , string message = null)
        {
                writer.WriteLine("From server -> " + message);
                writer.Flush();
        }

        public void ProcessClientRequests(object argument)
        {
            var client = (TcpClient)argument;
            var playGame = false;
            var random = new Random();
            var number = random.Next(1, 100);

            try
            {
                var reader = new StreamReader(client.GetStream());
                var writer = new StreamWriter(client.GetStream());

                SeverSendMessage(writer, "Connected.");
                string s = String.Empty;
                while (!(s = reader.ReadLine()).Equals("Exit") || (s == null))
                {
                    s = s.Trim();

                    if (CloseExistingConnectionOnCall)
                    {
                        break;
                    }

                    if (playGame && !s.Equals(null))
                    {
                        try
                        {
                            string response = ExtensionsMethods.Game(number, Int32.Parse(s));
                            SeverSendMessage(writer, response);
                        }
                        catch (Exception e) { }
                    }
                    if (s.Contains("show info"))
                    {
                        s = s.Remove(0, 9).Trim();
                        var adapterFunctionality = new StrategyFunctionality();
                        s=adapterFunctionality.ComponentInformation(s);

                        Console.WriteLine("From client -> " + s);
                        SeverSendMessage(writer, s);
                    }
                    else
                    {
                        Console.WriteLine("From client -> " + s);
                        SeverSendMessage(writer, s);
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
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
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