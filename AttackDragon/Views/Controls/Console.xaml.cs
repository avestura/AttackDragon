using AttackDragon.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public void WriteComment(string text) => Write(text);
        public void WriteWarning(string text) => Write(text);
        public void WriteError(string text) => Write(text);
        public void WriteSuccess(string text) => Write(text);
        public void WritePrimary(string text) => Write(text);
        public void WriteNormal(string text) => Write(text);

        private void Write(string text, [CallerMemberName]string typeIdentifier = "")
        {
            ConsoleItems.Add(new ConsoleItemViewModel
            {
                Text = text,
                ConsoleItemType =
                    (ConsoleItemType)Enum.Parse(typeof(ConsoleItemType), typeIdentifier.Replace("Write", string.Empty))
            });
            if (ConsoleItems.Count > 50) ConsoleItems.Remove(ConsoleItems.First());
            Lv.ScrollIntoView(ConsoleItems.Last());
        }
    }

}
