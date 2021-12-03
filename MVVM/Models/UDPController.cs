using ST3PRJ3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST3PRJ3.MVVM.Models
{
    class UDPController
    {
        private UDPSender _udpSender;

        public UDPController(UDPSender UdpSender)
        {
            _udpSender = UdpSender;
        }
        public void Run()
        {
            _udpSender.Send("StartMeasure");
        }
    }
}
