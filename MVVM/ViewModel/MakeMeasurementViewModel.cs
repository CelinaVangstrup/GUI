using JetBrains.Annotations;
using LiveCharts;
using LiveCharts.Configurations;
using ST3PRJ3.Core;
using ST3PRJ3.Data;
using ST3PRJ3.DTO;
using ST3PRJ3.MVVM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;


namespace ST3PRJ3.MVVM.ViewModel
{
    class MakeMeasurementViewModel : INotifyPropertyChanged, IMeasurementObserver
    {
        private int _bloodPressure;
        private int _diaSysPressure;
        public ChartValues<DTO_BloodPressure> ChartValues { get; set; }
        private double _trend;
        private string _file = @"C:\Users\Søren Mehlsen\OneDrive\source\repos\GUI\BPfiles\MaalingGris.txt";
        private string _udp;
        public double AxisStep { get; set; }
        public double AxisUnit { get; set; }
        private double _axisMax;
        private double _axisMin;
        private BloodPressureFileReader udpReader;
        public Func<double, string> DateTimeFormatter { get; set; }
        //public ChartValues<MeasureModel> ChartValues { get; set; }
        //public Func<double, string> DateTimeFormatter { get; set; }
        private readonly MeasurementModel _measurementModel = new MeasurementModel();

        public MakeMeasurementViewModel()
        {
            _measurementModel.Add(this);

            var mapper = Mappers.Xy<DTO_BloodPressure>()
                .X(model => model.DateTime.Ticks)   //use DateTime.Ticks as X
                .Y(model => model.Value);           //use the value property as Y

            //lets save the mapper globally.
            Charting.For<DTO_BloodPressure>(mapper);

            //the values property will store our values array
            ChartValues = new ChartValues<DTO_BloodPressure>();

            DateTimeFormatter = value => new DateTime((long)value).ToString("ss");

            if (ChartValues.Count > 100) ChartValues.RemoveAt(0);

        }

        public string File
        {
            get => _file;
            set
            {
                _file = value;
                OnPropertyChanged();
            }
        }



        public int BloodPressure
        {
            get => _bloodPressure;
            set
            {
                _bloodPressure = value;
                OnPropertyChanged();
            }
        }

        public int DiaSysPressure
        {
            get => _diaSysPressure;
            set
            {
                _diaSysPressure = value;
                OnPropertyChanged();           
               
            }
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




     

        #region StartButtonClickCommand
        public ICommand _startButtonClickCommand;

        public ICommand StartButtonClickCommand => _startButtonClickCommand ?? (_startButtonClickCommand =
                                                    new RelayCommand(StartButtonClick,
                                                        StartButtonClickCanExecute));
        private bool StartButtonClickCanExecute()
        {
            return true;
        }
        #endregion

        public void StartButtonClick()
        {
            //Vi starter med at få sendt start måling til RPI igennem UDP
            //UDPSender udpSender = new UDPSender();
            //UDPController udpController = new UDPController(udpSender);
            //Thread StartButtonIsPressedThread = new Thread(udpController.Run);
            //StartButtonIsPressedThread.Start();

            MeasureThread bloodPressureThread = new MeasureThread(_file, _measurementModel);

            //MeasureThread bloodPressureThread = new MeasureThread(_measurementModel);


            Thread bpThread1 = new Thread(bloodPressureThread.MeasureTheBloodpressure);
            Thread bpThread = new Thread(Read);
            //Thread diaSysThread = new Thread(bloodPressureThread.MeasureTheDiaSysPressure);

            bpThread.IsBackground = true;
            bpThread1.IsBackground = true;
            //diaSysThread.IsBackground = true;


            //diaSysThread.Start();
            bpThread.Start();
            bpThread1.Start();

            //Task.Factory.StartNew(Read);






            // Thread for analyze puls

        }

        public void Read()
        {
            var r = new Random();

            while (true)
            {
                Thread.Sleep(30);
                var now = DateTime.Now;

                _trend += r.Next(-8, 10);

                ChartValues.Add(new DTO_BloodPressure
                {
                    DateTime = now,
                    Value = Convert.ToInt32(_trend)
                });
            }
        }


    
        #region StopButtonClickCommand
        public ICommand _stopButtonClickCommand;

        public ICommand StopButtonClickCommand => _stopButtonClickCommand ?? (_stopButtonClickCommand =
                                                    new RelayCommand(StopButtonClick,
                                                        StopButtonClickCanExecute));
        private bool StopButtonClickCanExecute()
        {
            return true;
        }
        #endregion

        public void StopButtonClick()
        {
            // stopper tråd

            //bpThread.Abort();
            //diaSysThread.Abort();

          


        }

        #region SaveButtonClickCommand
        public ICommand _saveButtonClickCommand;

        public ICommand SaveButtonClickCommand => _saveButtonClickCommand ?? (_saveButtonClickCommand =
                                                    new RelayCommand(SaveButtonClick,
                                                        SaveButtonClickCanExecute));
        private bool SaveButtonClickCanExecute()
        {
            return true;
        }
        #endregion

        public void SaveButtonClick()
        {
            //gemmer målingen

            DataBase localdatabase = new DataBase(); // Opretter objektet databse / opretter database hvis den ikke allerede er oprettet

            //localdatabase.OpenConnection(); // Åbner forbindelse til database

            //localdatabase.CloseConnection(); // Lukker forbindelse til database
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void Update(AbstractMeasurement.UpdatedField field)
        {
            BloodPressure = _measurementModel.BloodPressure;
            //ChartValues = _measurementModel.BloodPressure;

            //DiaSysPressure = _measurementModel.DiaSysPressure;

            //_ChartValues = new ChartValues<double>();

            //_ChartValues.Add(Convert.ToDouble(_measurementModel.BloodPressure));

            //ChartValues = _ChartValues;

            //udpReader = new BloodPressureFileReader();
            //_ChartValues = new ChartValues<DTO_BloodPressure>();
            //List<DTO_BloodPressure> bpList = udpReader.ReadBloodPressureInFile(_file);
            //foreach (var x in bpList)
            //{
            //    _ChartValues.Add(x);
            //}

            //ChartValues.Add(new DTO_BloodPressure()
            //{
            //    Value = Convert.ToInt32(_measurementModel.BloodPressure),
            //    DateTime = DateTime.Now

            //});
            //ChartValues = _ChartValues;
        }
    }
}
