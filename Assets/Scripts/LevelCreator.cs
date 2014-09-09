using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;


public class LevelCreator : MonoBehaviour {
	public int level;

	[SerializeField]
	private TextAsset xmlFile;

	private XmlData xmldata;

	void Start(){
		Instantiate(Resources.Load("Prefabs/LvlDoors"),new Vector3(Camera.main.transform.position.x,Camera.main.transform.position.y,0),Quaternion.identity);
		xmldata = loadXML();
		for(int i = 0; i < 13; i++)
		{
			string[] values = xmldata.levels[level].rows[i].rowString.Split(',');


			for(int j = 0; j < values.Length; j++)
			{
				switch(int.Parse(values[j]))
				{
				 case -1:
					Instantiate(Resources.Load("Prefabs/PlayerCube"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					Instantiate(Resources.Load("Prefabs/FloorTile"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					break;

				 case 0:
					Instantiate(Resources.Load("Prefabs/FloorTile"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					break;

				 case 1:
					Instantiate(Resources.Load("Prefabs/WallHor2"),new Vector3(j * 1,i * -1,0),Quaternion.identity);
					Instantiate(Resources.Load("Prefabs/FloorTile"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					break;

				 case 2:
					Instantiate(Resources.Load("Prefabs/WallHor"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					Instantiate(Resources.Load("Prefabs/FloorTile"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					break;

				case 3:
					Instantiate(Resources.Load("Prefabs/FloorTile"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					Instantiate(Resources.Load("Prefabs/WallCorner"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					break;

				case 4:
					Instantiate(Resources.Load("Prefabs/FloorTile"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					Instantiate(Resources.Load("Prefabs/WallVer2"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					break;

				case 5:
					Instantiate(Resources.Load("Prefabs/FloorTile"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					Instantiate(Resources.Load("Prefabs/WallVer"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					break;

				case 6:
					Instantiate(Resources.Load("Prefabs/FloorTile"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					Instantiate(Resources.Load("Prefabs/DeathWallHor2"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					break;

				case 7:
					Instantiate(Resources.Load("Prefabs/FloorTile"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					Instantiate(Resources.Load("Prefabs/DeathWallHor"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					break;

				case 8:
					Instantiate(Resources.Load("Prefabs/FloorTile"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					Instantiate(Resources.Load("Prefabs/DeathWallVer2"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					break;

				case 9:
					Instantiate(Resources.Load("Prefabs/FloorTile"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					Instantiate(Resources.Load("Prefabs/DeathWallVer"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					break;

				case 10:
					Instantiate(Resources.Load("Prefabs/FloorTile"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					Instantiate(Resources.Load("Prefabs/Exit"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					break;

				case 11:
					Instantiate(Resources.Load("Prefabs/NonMove"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					Instantiate(Resources.Load("Prefabs/FloorTile"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					break;

				case 12:
					Instantiate(Resources.Load("Prefabs/CubeStrong"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					Instantiate(Resources.Load("Prefabs/FloorTile"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					break;

				case 13:
					Instantiate(Resources.Load("Prefabs/CubeWeak"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					Instantiate(Resources.Load("Prefabs/FloorTile"), new Vector3(j * 1,i * -1,0),Quaternion.identity);
					break;

	
				}

			}
		}
		Destroy(gameObject);
	}

	XmlData loadXML() {
		XmlSerializer serializer = new XmlSerializer(typeof(XmlData));
		StringReader xmlstring = new StringReader(xmlFile.text);
		XmlTextReader xmlReader = new XmlTextReader(xmlstring);
		return serializer.Deserialize(xmlReader) as XmlData;
	}

}

