using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackDragon.Configurations
{
    public partial class Configuration
    {
        /// <summary>
        /// Name of <see cref="Configuration"/> file
        /// </summary>
        private const string FileName = "App.Config.Xml";

        /// <summary>
        /// Directory to store <see cref="Configuration"/> in it
        /// </summary>
        private static string DirectoryAddress = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//Aryan Software//AttackDragon//";

        /// <summary>
        /// Full path of <see cref="Configuration"/> file
        /// </summary>
        private static string FullPath = DirectoryAddress + FileName;

    }
}
