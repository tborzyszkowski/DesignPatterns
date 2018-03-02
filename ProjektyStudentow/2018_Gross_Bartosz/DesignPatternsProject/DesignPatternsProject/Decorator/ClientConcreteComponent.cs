using System.IO;
using System.Net.Sockets;

namespace DesignPatternsProject.Decorator
{
    internal class ClientConcreteComponent : BaseTcpClientInfo
    {
        public static int NumberOfConnectedClient = 0;

        public ClientConcreteComponent(TcpClient client, string clientName="")
        {
            TcpClient = client;
            Writer = new StreamWriter(client.GetStream());
            ClientName = clientName;
            ++NumberOfConnectedClient;
        }

        public override string GetClientName()
        {
            return ClientName;
        }

        public override TcpClient GetClientTcpObject()
        {
            return TcpClient;
        }

        public override StreamWriter GetClienctStreamWriter()
        {
            return Writer;
        }
    }
}