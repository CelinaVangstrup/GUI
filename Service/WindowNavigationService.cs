using ST3PRJ3.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST3PRJ3.Service
{
    public class WindowNavigationService : IWindowService
    {
        //Metode til åbne et nyt vindue
        public void CreateWindow()
        {
            HealthcareMainWindow healthcareMainWindow = new HealthcareMainWindow
            {
                DataContext = new HealthcareMainWindow()
            };
            healthcareMainWindow.Show();
        }

        //Metode til at lukke et vindue
        public void CloseWindow()
        {
            LogIn login = new LogIn
            {
                DataContext = new LogIn()
            };
            login.Close();
        }
    }
}
