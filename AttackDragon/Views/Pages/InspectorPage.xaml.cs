using AttackDragon.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace AttackDragon.Views.Pages
{
    /// <summary>
    /// Interaction logic for InspectorPage.xaml
    /// </summary>
    public partial class InspectorPage : Page
    {
        public Assembly TargetAssembly { get; }

        public InspectorPage(Assembly assembly)
        {
            TargetAssembly = assembly;
            InitializeComponent();

            DataContext = new InspectorViewModel
            {
                AssemblyName = TargetAssembly.GetName().Name,
                AssemblySize = $"{new FileInfo(TargetAssembly.Location).Length / 1024} KB"
            };
        }
    }
}
