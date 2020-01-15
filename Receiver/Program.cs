using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Receiver {
    class Program {
        static void Main(string[] args) {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Bind(new IPEndPoint(IPAddress.Any, 11223));

            byte[] buffer = new byte[1500];
            EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
            while (true) {
                socket.ReceiveFrom(buffer, ref endPoint);

                BinaryReader reader = new BinaryReader(new MemoryStream(buffer));
                int i = reader.ReadInt32();
                Console.WriteLine(i);
            }
        }
    }
}
