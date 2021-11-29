using JetBrains.Annotations;
using LiveCharts;
using LiveCharts.Configurations;
using ST3PRJ3.Core;
using ST3PRJ3.Data;
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
       

        public ICommand StopButtonClickCommand { get; set; }
        public ICommand SavButtonClickCommand { get; set; }
        private string _puls;
        private string _file = @"..\..\..\BPfiles\MaalingGris.txt";
        //public ChartValues<MeasureModel> ChartValues { get; set; }
        //public Func<double, string> DateTimeFormatter { get; set; }
        private readonly Measurement _measurementModel = new Measurement();

        public MakeMeasurementViewModel()
        {
            _measurementModel.Add(this);
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

        public string Puls
        {
            get => _puls;
            set
            {
                _puls = value;
                OnPropertyChanged();
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

        private void StartButtonClick()
        {
            BloodPressureThread bloodPressureThread = new BloodPressureThread(_file, _measurementModel);
            Thread bpThread = new Thread(bloodPressureThread.MeasureTheBloodpressure);
            bpThread.Start();

        }



        public void StopButtonClick(object parameter)
        {
            //stopper målingen
        }

        public void SaveButtonClick(object parameter)
        {
            //stopper målingen
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
