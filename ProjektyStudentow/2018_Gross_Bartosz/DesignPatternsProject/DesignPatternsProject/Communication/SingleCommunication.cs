using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using DesignPatternsProject.Interfaces;

namespace DesignPatternsProject.Communication
{
    public sealed class SingleCommunication : ICommunication
    {
        private static SingleCommunication instance = null;
        private static readonly object padlock = new object();

        public SingleCommunication()
        {
        }

        public static SingleCommunication Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new SingleCommunication();
                        }
                    }
                }
                return instance;
            }
        }

        public void SeverSendMessage()
        {
            string message = "";

            do
            {
                writer.WriteLine("From server -> " + message);
                writer.Flush();
                message = Console.ReadLine();

            } while (message.ToLower() != "exit");

            try
            {
                writer.WriteLine("exit");
                writer.Flush();
            }
            catch (Exception)
            {
            }

        }

        private StreamWriter writer;

        public void CloseServer()
        {
            CloseExistingConnectionOnCall = true;
            listener.Server.Close();
            listener.Stop();
        }

        public static TcpListener listener = null;
        private bool CloseExistingConnectionOnCall = false;

        public void CreatServer()
        {
            CloseExistingConnectionOnCall = false;

            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
                listener.Start();
                Console.WriteLine("EchoServer started...");
                while (true)
                {
                    Console.WriteLine("Waiting for incoming client connections...");
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("Accepted new client connection...");
                    StreamReader reader = new StreamReader(client.GetStream());
                    writer = new StreamWriter(client.GetStream());
                    string s = string.Empty;

                    Thread thread = new Thread(SeverSendMessage);
                    thread.Start();

                    while (!(s = reader.ReadLine()).Equals("Exit") || (s == null))
                    {
                        Console.WriteLine("From client -> " + s);
                        //writer.WriteLine("From server -> " + s);
                        writer.Flush();
                    }
                    reader.Close();
                    writer.Close();
                    client.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (listener != null)
                {
                    listener.Server.Close();
                    listener.Stop();
                }
            }
        }
    }
}
