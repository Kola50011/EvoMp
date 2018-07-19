using System;
using System.Xml.Serialization;

namespace EvoMp.Module.MapImporter.Server.XML
{
  [Serializable()]
  public class SpoonerMapInformation
  {
    [XmlElement("Name")]
    public string Name { get; set; }

    [XmlElement("Dimension")]
    public int Dimension { get; set; }

    [XmlElement("CreatorIngameName")]
    public string CreatorIngameName { get; set; }
  }

}
