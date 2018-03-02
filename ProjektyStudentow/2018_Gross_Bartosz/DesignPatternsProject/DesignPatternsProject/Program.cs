using System;
using System.Diagnostics;
using System.Threading;
using DesignPatternsProject.Adapter;
using DesignPatternsProject.Communication;
using DesignPatternsProject.FactoryReflection;
using DesignPatternsProject.Interfaces;
using DesignPatternsProject.Strategy;
using DesignPatternsProject.Decorator;

namespace DesignPatternsProject
{
    public class DesignPatternsProject
    {
        private static void FactoryGroup()
        {
            bool close = false;
            Thread thread = null;
            Console.WriteLine("Choose option :");
            string consoleChoose = "s";


            ICommunication communicationMode = null;
            while (consoleChoose.ToLower() != "exit" && !close)
            {
                Console.Clear();
                Console.WriteLine("Options: \n" +
                                  "1: Open Server CommunicationBase Connection\n" +
                                  "2: Close Server CommunicationBase Connection\n" +
                                  "3: Single Connection Talking Mode\n" +
                                  "4: Multi Connection Talking Mode\n" +
                                  "5: Close MultiCLient Server Connection\n" +
                                  "9: Close Program\n" +
                                  "");
                switch (Console.ReadLine())
                {
                    case "1":
                        communicationMode = Factory.GetCommunicationObject("DesignPatternsProject.Communication.CommunicationBase");
                        thread = new Thread(communicationMode.CreatServer);
                        thread.Start();
                        break;
                    case "2":
                        try
                        {
                            communicationMode.CloseServer();
                            thread.Interrupt();
                            thread.Abort();
                        }
                        catch (ThreadInterruptedException e)
                        {
                        }
                        break;
                    case "3":
                        communicationMode = Factory.GetCommunicationObject("DesignPatternsProject.Communication.SingleCommunication");
                        communicationMode.CreatServer();
                        break;
                    case "8":
                        communicationMode.CloseServer();
                        break;
                    case "4":
                        communicationMode = Factory.GetCommunicationObject("DesignPatternsProject.Communication.MultiCommunication");
                        thread = new Thread(communicationMode.CreatServer);
                        thread.Start();
                        break;
                    case "5":
                        try
                        {
                            communicationMode.CloseServer();
                            thread.Interrupt();
                            thread.Abort();
                        }
                        catch (ThreadInterruptedException) { }
                        break;
                    case "9":
                        SingleCommunication.listener.Server.Close();
                        SingleCommunication.listener.Stop();
                        close = true;
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }

                Console.Clear();
            }
        }

        public static void Main()
        {
            FactoryGroup();
        }
    }
}