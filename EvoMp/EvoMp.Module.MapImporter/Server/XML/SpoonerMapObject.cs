using System;
using System.Xml.Serialization;

namespace EvoMp.Module.MapImporter.Server.XML
{
  [Serializable()]
  public class SpoonerMapObject
  {

    [XmlElement("ModelHash")]
    public string ModelHash { get; set; }

    [XmlElement("Type")]
    public int Type { get; set; }

    [XmlElement("Dynamic")]
    public bool Dynamic { get; set; }

    [XmlElement("FrozenPos")]
    public bool FrozenPos { get; set; }

    [XmlElement("HashName")]
    public string HashName { get; set; }

    [XmlElement("OpacityLevel")]
    public int OpacityLevel { get; set; }

    [XmlElement("IsCollisionProof")]
    public bool IsCollisionProof { get; set; }

    [XmlElement("ObjectProperties", typeof(ObjectProperties))]
    public ObjectProperties ObjectProperties { get; set; }

    [XmlElement("PositionRotation", typeof(PositionRotation))]
    public PositionRotation PositionRotation { get; set; }
  }

  [Serializable()]
  public class PositionRotation
  {
    [XmlElement("X")]
    public double X { get; set; }

    //[XmlArray("PositionRotation")]
    [XmlElement("Y")]
    public double Y { get; set; }

    //[XmlArray("PositionRotation")]
    [XmlElement("Z")]
    public double Z { get; set; }

    //[XmlArray("PositionRotation")]
    [XmlElement("Pitch")]
    public double Xr { get; set; }

    // [XmlArray("PositionRotation")]
    [XmlElement("Roll")]
    public double Yr { get; set; }

    // [XmlArray("PositionRotation")]
    [XmlElement("Yaw")]
    public double Zr { get; set; }
  }

  [Serializable()]
  public class ObjectProperties
  {
    [XmlElement("TextureVariation")]
    public int TextureVariation { get; set; }
  }
}
