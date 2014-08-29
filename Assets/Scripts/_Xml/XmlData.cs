using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

[XmlRoot("data")]
public class XmlData {
	
	[XmlArray("levels")]
	[XmlArrayItem("level")]
	public List<XmlLevel> levels = new List<XmlLevel>();
}
