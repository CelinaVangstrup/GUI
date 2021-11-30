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
        public void UpdateBPData(List<DTO_BloodPressure> bps, Measurement bpData)
        {
            while (true)
            {
                foreach (DTO_BloodPressure bp in bps)
                {
                    bpData.UpdateBloodPressure(bp.Value);
                    Thread.Sleep(500);

                }
            }
        }
    }
}
