﻿using ST3PRJ3.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST3PRJ3.MVVM
{
    public interface IMeasurementObserver
    {
        void Update(AbstractMeasurement.UpdatedField field);
    }
}
