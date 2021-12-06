using ST3PRJ3.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ST3PRJ3.MVVM.Models
{
    public class MeasuremntDataProvider
    {
        public void UpdateBPData(List<DTO_BloodPressure> bps, MeasurementModel bpData)
        {
            while (true)
            {
                foreach (DTO_BloodPressure x in bps)
                {
                    bpData.UpdateBloodPressure(x.Value);
                    
                    Thread.Sleep(500);

                }
            }
        }

        public void UpdateDiaSysData(List<DTO_BloodPressure> bps, MeasurementModel bpData)
        {
            //while (true)
            //{
                
            //    List<int> diasysList = new List<int>();
            //    foreach (DTO_BloodPressure x in bps)
            //    {
            //        diasysList.Add(x.Value);
            //        Thread.Sleep(500);
            //    }
            //    int max = diasysList.Max();

            //    bpData.UpdateBloodPressure(max);
            //    diasysList.Clear();
            //}
        }

    }
}
