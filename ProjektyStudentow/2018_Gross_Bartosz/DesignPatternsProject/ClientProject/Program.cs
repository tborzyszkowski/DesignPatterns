using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;

namespace ClientProject
{
    public class EchoClient
    {
        private static StreamWriter writer;
        private static StreamReader reader;
        private static String s = String.Empty;
        private static String communicationEnd = String.Empty;
        private static TcpClient client;

        private static void ClientGetMessage()
        {
            string message = "";

            try
            {
                do
                {
                    var server_string = reader.ReadLine();
                    message = server_string;
                    Console.WriteLine(server_string);

                } while (message.ToLower() != "exit");
                communicationEnd = "exit";
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("No response from server. Closeing Connection");
            }
            catch (IOException)
            {
            }
            catch (ObjectDisposedException)
            {
            }
            finally
            {
                reader.Close();
                writer.Close();
                client.Close();
            }
        }

        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            ImExit();
        }

        private static void ImExit()
        {
            writer.WriteLine("im exit");
            writer.Flush();
        }


        static bool ConsoleEventCallback(int eventType)
        {
            if (eventType == 2)
            {
                Console.WriteLine("Console window closing, death imminent");
                ImExit();
            }
            return false;
        }
        static ConsoleEventDelegate handler;   // Keeps it from getting garbage collected
                                               // Pinvoke
        private delegate bool ConsoleEventDelegate(int eventType);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);

        public static void Main()
        {
            try
            {
                    handler = new ConsoleEventDelegate(ConsoleEventCallback);
                    SetConsoleCtrlHandler(handler, true);

                client = new TcpClient("127.0.0.1", 8080);
                reader = new StreamReader(client.GetStream());
                writer = new StreamWriter(client.GetStream());

                Thread thread = new Thread(ClientGetMessage);
                thread.Start();
                Console.Write("Enter a string to send to the server: ");

                while (!s.Equals("exit") && !communicationEnd.Equals("exit"))
                {
                    s = Console.ReadLine();
                    writer.WriteLine(s);
                    writer.Flush();
                }

                Console.Write("Communication End");
                ImExit();
                reader.Close();
                writer.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}