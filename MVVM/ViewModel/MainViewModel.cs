using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ST3PRJ3.Core;


namespace ST3PRJ3.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand MakeMeasurementViewCommand { get; set; }

        public RelayCommand PatientInformationViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public MakeMeasurementViewModel MakeMeasurementVM { get; set; }
        public PatientInformationViewModel PatientInformationVM { get; set; }
        public MakeMeasurementViewModel MakeMeasurementViewModel { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            //HomeVM = new HomeViewModel();
            //MakeMeasurementVM = new MakeMeasurementViewModel();
            //PatientInformationVM = new PatientInformationViewModel();
            //CurrentView = HomeVM;
            //HomeViewCommand = new RelayCommand(o =>
            //{
            //    CurrentView = HomeVM;
            //});

            //MakeMeasurementViewCommand = new RelayCommand(o =>
            //{
            //    CurrentView = MakeMeasurementVM;

            //});


            //PatientInformationViewCommand = new RelayCommand(o =>
            //{
            //    CurrentView = PatientInformationVM;

            //});
        }
    }
}
