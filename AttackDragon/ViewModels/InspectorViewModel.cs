using AttackDragon.Assets.Images;
using AttackDragon.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AttackDragon.ViewModels
{
    class InspectorViewModel : INotifyPropertyChanged
    {

        private string _assemblyName;
        private string _assemblySize;
        private List<InspectorTreeItem> _inspectorTree;

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

        public List<InspectorTreeItem> InspectorTrees
        {
            get => _inspectorTree;
            set { _inspectorTree = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
