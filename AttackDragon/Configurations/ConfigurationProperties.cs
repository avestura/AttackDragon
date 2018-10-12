using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AttackDragon.Configurations
{
    public partial class Configuration
    {

        [XmlIgnore]
        public string IgnoredProperty { get; set; }

        public string StoredProperty { get; set; }

    }
}
