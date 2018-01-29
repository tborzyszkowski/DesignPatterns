using System.IO;
using System.Net.Sockets;

namespace DesignPatternsProject.Decorator
{
    internal class ConnectedClientDecarated : Decorator
    {
        public override void SetClientName(string newName)
        {
            this.ConnectedClientInfo.ClientName = newName;
        }

        public ConnectedClientDecarated(ClientConcreteComponent clientConcreteComponent) : base(clientConcreteComponent)
        {
        }

        public TcpClient GetClientTcp()
        {
            return this.ConnectedClientInfo.GetClientTcpObject();
        }

        public StreamWriter GetClientStreamWriter()
        {
            return this.ConnectedClientInfo.GetClienctStreamWriter();
        }

        public string GetClientName()
        {
            return this.ConnectedClientInfo.GetClientName();
        }
    }
}