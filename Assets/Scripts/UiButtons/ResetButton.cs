using UnityEngine;
using System.Collections;

public class ResetButton : MonoBehaviour {

	void OnMouseDown()
	{
		GameObject.FindGameObjectWithTag("SideDoors").GetComponent<LvlDoorScripts>().reset = true;
		GameObject.FindGameObjectWithTag("SideDoors").GetComponent<LvlDoorScripts>().closeNow = true;
	}
}
