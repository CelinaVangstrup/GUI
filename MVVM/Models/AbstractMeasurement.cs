﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST3PRJ3.MVVM.Models
{
    public class AbstractMeasurement
    {
        public enum UpdatedField
        {
            BPCount
        }
        private readonly List<IMeasurementObserver> _measurementObservers = new List<IMeasurementObserver>();

        public void Add(IMeasurementObserver observer)
        {
            _measurementObservers.Add(observer);
        }

        public void Remove(IMeasurementObserver observer)
        {
            _measurementObservers.Remove(observer);
        }

        protected void Notify(UpdatedField field)
        {
            foreach (IMeasurementObserver measurementObserver in _measurementObservers)
            {
                measurementObserver.Update(field);
            }
        }
    }
}
