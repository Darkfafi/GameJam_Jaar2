using UnityEngine;
using System.Collections;

public class LvlSelectButton : MonoBehaviour {

	public int lvlNum;

	void OnMouseDown()
	{
		Debug.Log("hgtujreif");
		GameObject.FindGameObjectWithTag("SideDoors").GetComponent<LvlDoorScripts>().closeNow = true;
		GameObject.FindGameObjectWithTag("SideDoors").GetComponent<LvlDoorScripts>().lvlOverRide = "Level"+lvlNum;

		foreach(GameObject but in GameObject.FindGameObjectsWithTag("StartButton"))
		{
			but.collider2D.enabled = false;
		}
	}
}
