using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

public class XmlLevel {
	
	[XmlAttribute("id")]
	public int id;
	
	[XmlArray("rows")]
	[XmlArrayItem("row")]
	public List<XmlRow> rows = new List<XmlRow>();
}
