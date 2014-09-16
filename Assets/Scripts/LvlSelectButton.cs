using UnityEngine;
using System.Collections;

public class LvlSelectButton : MonoBehaviour {

	public int lvlNum;


	void Start()
	{
		if(PlayerPrefs.GetInt("unlock" + lvlNum) != 1 && lvlNum != 0)
		{
			collider2D.enabled = false;
			transform.GetChild(0).gameObject.SetActive(true);
		}
	}

	void OnMouseDown()
	{
		GameObject.FindGameObjectWithTag("SideDoors").GetComponent<LvlDoorScripts>().closeNow = true;
		GameObject.FindGameObjectWithTag("SideDoors").GetComponent<LvlDoorScripts>().lvlOverRide = "Level"+lvlNum;

		foreach(GameObject but in GameObject.FindGameObjectsWithTag("StartButton"))
		{
			but.collider2D.enabled = false;
		}
	}
}
