using UnityEngine;
using System.Collections;

public class gameOverScript : MonoBehaviour {

	void Start(){
		Invoke ("BackToMenu", 5f);
	}

	void BackToMenu(){
		GameObject.FindGameObjectWithTag("SideDoors").GetComponent<LvlDoorScripts>().closeNow = true;
		GameObject.FindGameObjectWithTag("SideDoors").GetComponent<LvlDoorScripts>().lvlOverRide = "Menu";
	}
}
