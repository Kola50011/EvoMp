using System;
using System.Xml.Serialization;

namespace EvoMp.Module.MapImporter.Server.XML
{
  [Serializable()]
  [XmlRoot("SpoonerPlacements")]
  public class SpoonerMap
  {
    [XmlElement("Placement", typeof(SpoonerMapObject))]
    public SpoonerMapObject[] MapObjects{ get; set; }
  }

}
