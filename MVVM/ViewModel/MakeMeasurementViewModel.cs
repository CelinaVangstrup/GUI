using LiveCharts;
using LiveCharts.Configurations;
using ST3PRJ3.Core;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ST3PRJ3.MVVM.ViewModel
{
    class MakeMeasurementViewModel : ViewModelBase, IMakeMeasurementViewModel
    {
       
        public ICommand StartButtonClickCommand { get; set; }
        public ICommand StopButtonClickCommand { get; set; }
        public ICommand SavButtonClickCommand { get; set; }

        public ChartValues<MeasureModel> ChartValues { get; set; }
        public Func<double, string> DateTimeFormatter { get; set; }
        public double AxisStep { get; set; }
        public double AxisUnit { get; set; }

        private double _axisMax;
        private double _axisMin;
        private double _trend;

        public MakeMeasurementViewModel()
        {
            StartButtonClickCommand = new RelayCommand(StartButtonClick);
            StopButtonClickCommand = new RelayCommand(StopButtonClick);
            SavButtonClickCommand = new RelayCommand(SaveButtonClick);
        }

        public void StartButtonClick(object parameter)
        {

            var mapper = Mappers.Xy<MeasureModel>()
                .X(model => model.DateTime.Ticks)   //use DateTime.Ticks as X
                .Y(model => model.Value);           //use the value property as Y

            //lets save the mapper globally.
            Charting.For<MeasureModel>(mapper);

            //the values property will store our values array
            ChartValues = new ChartValues<MeasureModel>();

            //lets set how to display the X Labels
            DateTimeFormatter = value => new DateTime((long)value).ToString("ss");

            //AxisStep forces the distance between each separator in the X axis
            AxisStep = TimeSpan.FromSeconds(1).Ticks;
            //AxisUnit forces lets the axis know that we are plotting seconds
            //this is not always necessary, but it can prevent wrong labeling
            AxisUnit = TimeSpan.TicksPerSecond;

            SetAxisLimits(DateTime.Now);

            var r = new Random();

            //starter målingen
            Task.Factory.StartNew(() =>
            {
                
                Stopwatch watch = new Stopwatch();
                watch.Start();

                while (true)
                {

                    //var x = watch.Elapsed;


                    Thread.Sleep(30);
                    var now = DateTime.Now;

                    _trend += r.Next(-8, 10);

                    ChartValues.Add(new MeasureModel
                    {
                        DateTime = now,
                        Value = _trend
                    });

                    SetAxisLimits(now);

                    //lets only use the last 150 values
                    if (ChartValues.Count > 150) ChartValues.RemoveAt(0);
                }
            }, TaskCreationOptions.LongRunning);
        }

        public double AxisMax
        {
            get { return _axisMax; }
            set
            {
                _axisMax = value;
                OnPropertyChanged("AxisMax");
            }
        }
        public double AxisMin
        {
            get { return _axisMin; }
            set
            {
                _axisMin = value;
                OnPropertyChanged("AxisMin");
            }
        }

        private void SetAxisLimits(DateTime now)
        {
            AxisMax = now.Ticks + TimeSpan.FromSeconds(1).Ticks; // lets force the axis to be 1 second ahead
            AxisMin = now.Ticks - TimeSpan.FromSeconds(8).Ticks; // and 8 seconds behind
        }

        public class MeasureModel
        {
            public DateTime DateTime { get; set; }
            public double Value { get; set; }
        }


        public void StopButtonClick(object parameter)
        {
            //stopper målingen
        }

        public void SaveButtonClick(object parameter)
        {
            //stopper målingen
        }
    }
}
