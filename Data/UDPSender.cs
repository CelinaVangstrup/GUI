using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace ST3PRJ3.Data
{
    class UDPSender
    {
        // Send metoden sender en string til RPI når der trykkes på knap på brugergrænseflade

        public bool Send(string data)
        {
			string ipAddress = "172.20.10.6"; // Ip-adresse
			int sendPort = 55700;             // Port

			byte[] packetdata = Encoding.ASCII.GetBytes(data);
			IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipAddress), sendPort);
			Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

			try
			{
				sock.SendTo(packetdata, ep);
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}
    }
}
