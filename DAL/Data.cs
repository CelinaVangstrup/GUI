using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using DTO;

namespace DAL
{
    public class Data : IData
    {
        public Data() { }

        public List<DTO_Bloodpressure> ReadBloodpressureFromUDP()
        {
            bool done = false;
            int listenPort = 55600;
            List<DTO_Bloodpressure> dataList = new List<DTO_Bloodpressure>();
            string filePath = @".\Maaling1.txt"; // Ændre navn på fil
            using (UdpClient listener = new UdpClient(listenPort))
            {
                IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Any, listenPort);
                while (!done)
                {
                    byte[] receivedData = listener.Receive(ref listenEndPoint);

                    Console.WriteLine("Receiving from client: " + Encoding.ASCII.GetString(receivedData));


                    //Tilføjer data til en txt fil - skal laves om til database
                    dataList.Add(new DTO_Bloodpressure(Convert.ToInt32(Encoding.ASCII.GetString(receivedData))));
                    //File.WriteAllLines(filePath, dataList);

                }
                return dataList;
            }
        }
    }
}
