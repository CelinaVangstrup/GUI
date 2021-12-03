using ST3PRJ3.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ST3PRJ3.View
{
    /// <summary>
    /// Interaction logic for HealthcareMainWindow.xaml
    /// </summary>
    public partial class HealthcareMainWindow : Window
    {

        public HealthcareMainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e) //Flyt rundt på vinduet med mus
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void RegisterPatient_Checked(object sender, RoutedEventArgs e)
        {
            DataContext = new HomeView();
        }

        private void MakeMeasurement_Checked(object sender, RoutedEventArgs e)
        {
            DataContext = new MakeMeasurementView();
        }

        private void History_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void Threshhold_Checked(object sender, RoutedEventArgs e)
        {
            DataContext = new ThresholdValues();
        }

        private void Logout_Checked(object sender, RoutedEventArgs e)
        {
            DataContext = new LogIn();
        }
    }
}
