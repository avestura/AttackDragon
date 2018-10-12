using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AttackDragon.Configurations
{
    public partial class Configuration
    {

        /// <summary>
        /// Creates <see cref="Configuration"/> folder if it doesn't exist
        /// </summary>
        public static void InitializeLocalFolder()
        {
            if (!Directory.Exists(DirectoryAddress))
            {
                Directory.CreateDirectory(DirectoryAddress);
            }
        }

        /// <summary>
        /// Saves <see cref="Configuration"/> in <see cref="FullPath"/>
        /// </summary>
        public void SaveSettingsToFile()
        {

            XmlSerializer xsSubmit = new XmlSerializer(typeof(Configuration));
            var xml = string.Empty;

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, this);
                    xml = sww.ToString();
                }
            }

            File.WriteAllText(FullPath, xml);

        }

        /// <summary>
        /// Loads <see cref="Configuration"/> from <see cref="FullPath"/> and sets to <see cref="App.Configuration"/>
        /// </summary>
        public static void LoadSettingsFromFile()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
                using (FileStream fileStream = new FileStream(FullPath, FileMode.Open))
                {
                    var stream = new StreamReader(fileStream, Encoding.UTF8);
                    App.CurrentApp.Configuration = (Configuration)serializer.Deserialize(stream);
                }
            }
            catch
            {

                App.CurrentApp.Configuration = new Configuration();
                App.CurrentApp.Configuration.SaveSettingsToFile();
            }

        }

    }
}
