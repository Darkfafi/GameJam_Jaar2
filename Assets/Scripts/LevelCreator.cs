using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;


public class LevelCreator : MonoBehaviour {
	public Transform wall;
	public Transform exit;

	public int level;

	[SerializeField]
	private TextAsset xmlFile;

	private XmlData xmldata;

	void Start(){
		xmldata = loadXML();
		for(int i = 0; i < 12; i++)
		{
			string[] values = xmldata.levels[level].rows[i].rowString.Split(',');
			int.Parse(values[0]);

			for(int j = 0; j < values.Length; j++)
			{
				switch(int.Parse(values[j]))
				{
				 case 1:
					Instantiate(wall,new Vector3(j * 1,i * -1,0),Quaternion.identity);
					break;

				 case 2:
					Instantiate(exit, new Vector3(j * 1,i * -1,0),Quaternion.identity);
					break;

	
				}

			}
		}
		
	}

	XmlData loadXML() {
		XmlSerializer serializer = new XmlSerializer(typeof(XmlData));
		StringReader xmlstring = new StringReader(xmlFile.text);
		XmlTextReader xmlReader = new XmlTextReader(xmlstring);
		return serializer.Deserialize(xmlReader) as XmlData;
	}
}
