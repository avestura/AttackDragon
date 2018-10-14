using AttackDragon.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace AttackDragon.Views.Controls
{
    /// <summary>
    /// Interaction logic for Console.xaml
    /// </summary>
    public partial class Console : UserControl
    {
        public ObservableCollection<ConsoleItemViewModel> ConsoleItems { get; }
            = new ObservableCollection<ConsoleItemViewModel>();

        public Console()
        {
            InitializeComponent();

            MainLayout.DataContext = ConsoleItems;
        }
    }

}
