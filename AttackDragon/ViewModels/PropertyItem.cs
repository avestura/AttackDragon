using AttackDragon.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AttackDragon.ViewModels
{
    public class PropertyItem
    {
        public ImageSource ImageSource { get; set; }

        public string Name => MethodInfo.Name;

        public string StandardName => Name.MethodStandardName();

        public MethodInfo MethodInfo { get; set; }
    }
}
