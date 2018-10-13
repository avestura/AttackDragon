using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AttackDragon.ViewModels
{
    class InspectorViewModel : INotifyPropertyChanged
    {

        private string _assemblyName;
        private string _assemblySize;

        public string AssemblyName
        {
            get => _assemblyName;
            set { _assemblyName = value; OnPropertyChanged(); }
        }

        public string AssemblySize
        {
            get => _assemblySize;
            set { _assemblySize = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
