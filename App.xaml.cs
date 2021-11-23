using ST3PRJ3.MVVM.ViewModel;
using ST3PRJ3.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


namespace ST3PRJ3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Makes the LoginWindow to startup first
        protected override void OnStartup(StartupEventArgs e)
        {
            //MainWindow = new HealthcareMainWindow()
            //{
            //    DataContext = new HealthcareMainWindow()
            //};
            //MainWindow.Show();

            

            //base.OnStartup(e);
        }
    }
}
