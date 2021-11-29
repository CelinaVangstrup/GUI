using ST3PRJ3.Core;
using ST3PRJ3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ST3PRJ3.MVVM.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        public ICommand LoginButtonClickCommand { get; set; }
        public LoginViewModel()
        {
            //LoginButtonClickCommand = new RelayCommand(LoginButtonClick);
        }
        
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public void LoginButtonClick(object parameter)
        {
            //En lille snydegenvej til at kunne læse fra passwordbox, dette er imod MVVM https://newbedev.com/how-to-bind-to-a-passwordbox-in-mvvm
            var passwordBox = parameter as PasswordBox;
            var Password = passwordBox.Password;
            //---------------------------------------------//
            if (Username == "Søren" && Password == "123456") // Her kan username og password ændres
            {
                
                // Her opretter og åbner vi vinduet HealthCareMainWindow
                WindowNavigationService windowNav = new WindowNavigationService();
                IWindowService windowService = windowNav;
                windowService.CreateWindow();

                // Her lukker vi loginvinduet (skjuler det)
                windowService.CloseWindow();
            }
            else
            {
                //laves en popup besked
            }

        }

        
    }
}
