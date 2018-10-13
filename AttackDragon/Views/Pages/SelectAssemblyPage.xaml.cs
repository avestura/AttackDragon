using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for SelectAssemblyPage.xaml
    /// </summary>
    public partial class SelectAssemblyPage : Page
    {
        public Frame ParentFrame { get; }

        public SelectAssemblyPage(Frame parentFrame)
        {
            ParentFrame = parentFrame;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Assembly (*.exe, *.dll)|*.dll;*.exe",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false,
                Title = "Select Assembly"
            };

            if(dialog.ShowDialog() == true)
            {
                try
                {
                    var asm = Assembly.LoadFrom(dialog.FileName);
                    ParentFrame.Navigate(new InspectorPage(asm));
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"File not valid, Reason: {ex.Message}" + ((ex.InnerException != null) ? $"\nInner{ex.InnerException.Message}" : ""));
                }
            }
        }
    }
}
