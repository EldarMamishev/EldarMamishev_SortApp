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
using ViewModel.Views;

namespace View.Views
{
    /// <summary>
    /// Interaction logic for MainControlsView.xaml
    /// </summary>
    public partial class MainControlsView : UserControl
    {
        private MainControlsViewModel mainControlsVM;
        public MainControlsViewModel MainControlsVM
        {
            get
            {
                return mainControlsVM ?? 
                    (mainControlsVM = new MainControlsViewModel());
            }
        }

        public MainControlsView()
        {

            InitializeComponent();
        }
    }
}
