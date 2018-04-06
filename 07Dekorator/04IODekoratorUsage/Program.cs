using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace _04IODekoratorUsage {
    //
    // See: https://www.productivecsharp.com/2012/09/decorator-pattern-streams-in-net/
    //
    class Program {
        static void Main() {
            RunServer();
            SendMessage("Hello, I am sending this message using the decorator pattern.");
        }

        private static void RunServer() {
            var tcpListener = new TcpListener(IPAddress.Any, 8888);

            new Thread(() =>
            {
                tcpListener.Start();
                var client = tcpListener.AcceptTcpClient();

                // Configure the receiving pipiline of streams
                var networkStream = client.GetStream();
                var cryptoStream = new CryptoStream(networkStream, new SHA512Managed(), CryptoStreamMode.Read);
                var gzipStream = new GZipStream(cryptoStream, CompressionMode.Decompress);
                var bufferedStream = new BufferedStream(gzipStream, 64);

                var fileStream = new FileStream("result.txt", FileMode.Create);

                using (bufferedStream)
                {
                    using (fileStream)
                    {
                        while (true)
                        {
                            int data = bufferedStream.ReadByte();
                            if (data == -1) break;

                            fileStream.WriteByte((byte)data);
                        }
                    }
                }

                Process.Start("result.txt");
            }).Start();

            Thread.Sleep(1000);
        }

        private static void SendMessage(string message) {
            var client = new TcpClient("localhost", 8888);

            // Configure the sending pipiline of streams
            var networkStream = client.GetStream();
            var cryptoStream = new CryptoStream(networkStream, new SHA512Managed(), CryptoStreamMode.Write);
            var gzipStream = new GZipStream(cryptoStream, CompressionMode.Compress);
            var bufferedStream = new BufferedStream(gzipStream, 64);

            using (bufferedStream)
            {
                foreach (var b in Encoding.Unicode.GetBytes(message))
                {
                    bufferedStream.WriteByte(b);
                }
            }
        }
    }
}
