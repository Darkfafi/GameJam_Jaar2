using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

	void OnMouseDown()
	{
		GameObject.FindGameObjectWithTag("SideDoors").GetComponent<LvlDoorScripts>().lvlOverRide = "Menu";
		GameObject.FindGameObjectWithTag("SideDoors").GetComponent<LvlDoorScripts>().closeNow = true;
	}
}
