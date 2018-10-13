using AttackDragon.Assets.Images;
using AttackDragon.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace AttackDragon.ViewModels
{
    class InspectorViewModel : INotifyPropertyChanged
    {

        private string _assemblyName;
        private string _assemblySize;
        private ObservableCollection<InspectorTreeItem> _inspectorTree;
        private ObservableCollection<PropertyItem> _methods;
        private string _methodDetails;
        public Visibility _methodDetailsVisibility;

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

        public string MethodDetails
        {
            get => _methodDetails;
            set { _methodDetails = value; OnPropertyChanged(); }
        }

        public Visibility MethodDetailsVisibility
        {
            get => _methodDetailsVisibility;
            set { _methodDetailsVisibility = value; OnPropertyChanged(); }
        }

        public ObservableCollection<InspectorTreeItem> InspectorTrees
        {
            get => _inspectorTree;
            set { _inspectorTree = value; OnPropertyChanged(); }
        }

        public ObservableCollection<PropertyItem> Methods
        {
            get => _methods;
            set { _methods = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
