using ST3PRJ3.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ST3PRJ3.Data
{
    public class BloodPressureUDPReader
    {
        public List<DTO_BloodPressure> ReadBloodPressureFromUDP(string path)
        {
            bool done = false;
            int listenPort = 55600;
            List<DTO_BloodPressure> dataList = new List<DTO_BloodPressure>();
            //string filePath = @".\MaalingGris4.txt"; // Ændre navn på fil
            using (UdpClient listener = new UdpClient(listenPort))
            {
                IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Any, listenPort);
                while (!done)
                {
                    byte[] receivedData = listener.Receive(ref listenEndPoint);

                    string value = (Encoding.ASCII.GetString(receivedData));

                    DTO_BloodPressure bp = new DTO_BloodPressure();

                    bp.Value = Convert.ToInt32(value);

                    dataList.Add(bp);
                    
                }
            }
            return dataList;
        }
    }
}
