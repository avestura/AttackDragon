using AttackDragon.Assets.Images;
using AttackDragon.Extensions;
using AttackDragon.Models;
using AttackDragon.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        /// <summary>
        /// Assembly to inspect
        /// </summary>
        public Assembly TargetAssembly { get; }

        private InspectorViewModel ViewModel { get; }

        private Frame ParentFrame { get; }

        public InspectorPage(Assembly assembly, Frame parentFrame)
        {
            TargetAssembly = assembly;
            ParentFrame = parentFrame;
            InitializeComponent();

            DataContext = ViewModel = new InspectorViewModel
            {
                AssemblyName = TargetAssembly.GetName().Name,
                AssemblySize = $"{new FileInfo(TargetAssembly.Location).Length / 1024} KB",
                InspectorTrees = BuildTree(TargetAssembly),
                Methods = new ObservableCollection<PropertyItem>()
            };

        }

        /// <summary>
        /// Builds the type tree from <see cref="Assembly"/>
        /// </summary>
        /// <param name="assembly">The assembly to build tree from</param>
        /// <returns>A list of inspector tree item</returns>
        public ObservableCollection<InspectorTreeItem> BuildTree(Assembly assembly)
        {
            var root = new InspectorTreeItem
            {
                Name = assembly.GetName().Name,
                ImageSource =
                ((string.Equals(System.IO.Path.GetExtension(assembly.Location), ".exe", StringComparison.OrdinalIgnoreCase))
                ? VisualStudioImages.Application.Value
                : VisualStudioImages.Library.Value),
                ShowMethods = false,
                Children = new List<InspectorTreeItem>()
            };

            var tree = new ObservableCollection<InspectorTreeItem> { root };

            foreach(Type type in assembly.GetTypes())
            {
                root.Children.Add(new InspectorTreeItem
                {
                    Name = type.Name,
                    ShowMethods = true,
                    ImageSource = VisualStudioImages.Class.Value,
                    FullName = type.FullName
                });
            }

            return tree;
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is InspectorTreeItem treeItem && treeItem.ShowMethods)
            {
                ViewModel.Methods.Clear();
                var type = TargetAssembly.GetType(treeItem.FullName);
                type.GetMethods().ToList().ForEach(AddItemToViewModel);
            }
            else
            {
                ViewModel.Methods.Clear();
            }
        }

        private void AddItemToViewModel(MethodInfo method)
        {
            if(method.Name.StartsWith("get_")
                || method.Name.StartsWith("set_"))
            {
                if (!ViewModel.Methods.Any(item => item.StandardName == method.Name.MethodStandardName()))
                {
                    ViewModel.Methods.Add(new PropertyItem
                    {
                        ImageSource = VisualStudioImages.Property.Value,
                        MethodInfo = method,
                        MemberItemType = MemberItemType.Property
                    });
                }
            }
            else if (method.Name.StartsWith("add_")
                || method.Name.StartsWith("remove_"))
            {
                if (!ViewModel.Methods.Any(item => item.StandardName == method.Name.MethodStandardName()))
                {
                    ViewModel.Methods.Add(new PropertyItem
                    {
                        ImageSource = VisualStudioImages.Event.Value,
                        MethodInfo = method,
                        MemberItemType = MemberItemType.Event
                    });
                }
            }
            else
            {
                ViewModel.Methods.Add(new PropertyItem
                {
                    ImageSource = VisualStudioImages.Method.Value,
                    MethodInfo = method,
                    MemberItemType = MemberItemType.Method
                });
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MethodList.SelectedItem is PropertyItem item)
            {
                ViewModel.MethodDetails =
                    $"{item.MemberItemType.ToString()} {item.StandardName}\n\n" +
                    $"IsGeneric: {item.MethodInfo.IsGenericMethod}\n" +
                    $"IsAbstract: {item.MethodInfo.IsAbstract}\n";

                ViewModel.MethodDetailsVisibility = Visibility.Visible;
            }
            else
            {
                ViewModel.MethodDetailsVisibility = Visibility.Collapsed;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteComment($"Attack Dragon Version {Extensions.Extensions.GetVersion()}");
        }

        private void RunTestMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as MenuItem)?.Tag as PropertyItem;

            if (item.MemberItemType == MemberItemType.Event)
            {
                Console.WriteError("Can not test Events.");
            }
            else if (item.MemberItemType == MemberItemType.Property)
            {
                Console.WriteWarning("Can not test properties in this version of AttackDragon, consider updating app if a newer version is avaliable.");
            }
            else
            {
                Console.WriteNormal($"Testing {item.Name}...");
            }

        }

        private void CloseFile_Click(object sender, RoutedEventArgs e)
        {
            ParentFrame.Navigate(new SelectAssemblyPage(ParentFrame));
        }

        private void ExitApplication_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }
    }
}
