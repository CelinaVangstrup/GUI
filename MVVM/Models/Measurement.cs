using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST3PRJ3.MVVM.Models
{
    public class Measurement : AbstractMeasurement
    {
        private int systolic;
        private int diastolic;
        private int bloodPressure;

        public int Systolic
        {
            get => systolic;
            set => systolic = value;
        }

        public int Diastolic
        {
            get => diastolic;
            set => diastolic = value;
        }

        public int BloodPressure
        {
            get => bloodPressure;
            set => bloodPressure = value;
        }

        public void MeasurementComplete()
        {
            Notify();
        }
    }
}
