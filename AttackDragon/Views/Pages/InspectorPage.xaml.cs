using AttackDragon.Assets.Images;
using AttackDragon.Models;
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
                AssemblySize = $"{new FileInfo(TargetAssembly.Location).Length / 1024} KB",
                InspectorTrees = BuildTree(TargetAssembly)
            };
        }

        public List<InspectorTreeItem> BuildTree(Assembly assembly)
        {
            var root = new InspectorTreeItem
            {
                Text = assembly.GetName().Name,
                ImageSource =
                ((string.Equals(System.IO.Path.GetExtension(assembly.Location), ".exe", StringComparison.OrdinalIgnoreCase))
                ? VisualStudioImages.Application.Value
                : VisualStudioImages.Library.Value),
                Children = new List<InspectorTreeItem>()
            };

            var tree = new List<InspectorTreeItem> { root };

            foreach(Type type in assembly.GetTypes())
            {
                root.Children.Add(new InspectorTreeItem
                {
                    Text = type.Name,
                    ImageSource = VisualStudioImages.Class.Value
                });
            }

            return tree;
        }
    }
}
