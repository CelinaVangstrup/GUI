using ST3PRJ3.MVVM.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ST3PRJ3.MVVM.View
{
    /// <summary>
    /// Interaction logic for MakeMeasurementView.xaml
    /// </summary>
    public partial class MakeMeasurementView : UserControl, IMakeMeasurementViewModel
    {
        public MakeMeasurementView()
        {
            InitializeComponent();
            DataContext = new MakeMeasurementViewModel();
        }


    }
}
