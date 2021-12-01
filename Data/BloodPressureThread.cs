using ST3PRJ3.DTO;
using ST3PRJ3.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST3PRJ3.Data
{
    public class BloodPressureThread
    {
        private readonly string _path;
        private readonly Measurement _BpData;

        public BloodPressureThread(string path, Measurement BpData)
        {
            _path = path;
            _BpData = BpData;
        }

        public void MeasureTheBloodpressure()
        {
            BloodPressureFileReader bloodPressureFileReader = new BloodPressureFileReader();
            MeasuremntDataProvider measurementDataProvider = new MeasuremntDataProvider();
            BloodPressureUDPReader bloodPressureUDPReader = new BloodPressureUDPReader();

            List<DTO_BloodPressure> bloodPressureInFile = bloodPressureFileReader.ReadBloodPressureInFile(_path);
            List<DTO_BloodPressure> bloodPressureFromUDP = bloodPressureUDPReader.ReadBloodPressureFromUDP(_path);
           
            measurementDataProvider.UpdateBPData(bloodPressureInFile, _BpData);
            measurementDataProvider.UpdateBPData(bloodPressureFromUDP, _BpData);

        }
    }
}
