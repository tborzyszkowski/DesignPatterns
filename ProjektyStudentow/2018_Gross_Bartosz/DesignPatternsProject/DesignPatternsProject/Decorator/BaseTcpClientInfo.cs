using System.IO;
using System.Net.Sockets;

namespace DesignPatternsProject.Decorator
{
    internal abstract class BaseTcpClientInfo
    {
        public string ClientName { get; set; }

        protected TcpClient TcpClient { get; set; }

        protected StreamWriter Writer { get; set; }

        public abstract string GetClientName();
        public abstract TcpClient GetClientTcpObject();
        public abstract StreamWriter GetClienctStreamWriter();
    }
}
