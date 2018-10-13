using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AttackDragon.Models
{
    public class InspectorTreeItem
    {
        public string Name { get; set; }

        public ImageSource ImageSource { get; set; }

        public bool ShowMethods { get; set; }

        public string FullName { get; set; }

        public List<InspectorTreeItem> Children { get; set; }
    }
}
