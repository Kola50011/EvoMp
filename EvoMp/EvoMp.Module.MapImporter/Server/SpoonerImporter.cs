using System.IO;
using System.Xml.Serialization;

namespace EvoMp.Module.MapImporter.Server
{
    public class SpoonerImporter
    {
        public SpoonerImporter()
        {
            
        }

        public bool ImportMap(string xmlPath)
        {
            // Path is no xml file -> return false.
            if(!xmlPath.EndsWith(".xml"))
                return false;

            // Load xml file.
            XmlSerializer serializer = new XmlSerializer(typeof(XML.SpoonerMap));
            StreamReader reader = new StreamReader(xmlPath);
            XML.SpoonerMap map = (XML.SpoonerMap)serializer.Deserialize(reader);
            reader.Close();


            return true;
        }
    }
}
