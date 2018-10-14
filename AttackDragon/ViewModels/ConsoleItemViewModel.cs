using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AttackDragon.ViewModels
{
    public class ConsoleItemViewModel : ViewModelBase
    {
        private ConsoleItemType _consoleItemType;
        private string _text;

        public ConsoleItemType ConsoleItemType
        {
            get => _consoleItemType;
            set { _consoleItemType = value; OnPropertyChanged(); }
        }

        public SolidColorBrush TextColor =>
            (_consoleItemType == ConsoleItemType.Success) ? new SolidColorBrush(Color.FromRgb(142, 210, 138)) :
            (_consoleItemType == ConsoleItemType.Error) ? new SolidColorBrush(Color.FromRgb(243, 129, 106)) :
            (_consoleItemType == ConsoleItemType.Comment) ? new SolidColorBrush(Color.FromRgb(128, 128, 128)) :
            (_consoleItemType == ConsoleItemType.Primary) ? new SolidColorBrush(Color.FromRgb(122, 192, 255)) :
            (_consoleItemType == ConsoleItemType.Warning) ? new SolidColorBrush(Color.FromRgb(255, 204, 0)) :
            new SolidColorBrush(Color.FromRgb(223, 230, 233));

        public string Text
        {
            get => _text;
            set { _text = value; OnPropertyChanged(); }
        }
    }

    public enum ConsoleItemType
    {
        NormalText, Comment, Warning, Error, Success, Primary
    }
}
