using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST3PRJ3.DTO
{
    public class DTO_DBInfo
    {
        public string _personNumber { get; set; }
        public int _bpData { get; set; }
        public DateTime _dato { get; set; }

        public DTO_DBInfo(string PersonNumber, DateTime Date, int _BPData)
        {
            _personNumber = PersonNumber;
            _dato = Date;
            _bpData = _BPData;
        }
    }
}
