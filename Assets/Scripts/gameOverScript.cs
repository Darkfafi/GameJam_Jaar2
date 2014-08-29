using UnityEngine;
using System.Collections;

public class gameOverScript : MonoBehaviour {

	void Start(){
		Invoke ("BackToMenu", 5f);
	}

	void BackToMenu(){
		Application.LoadLevel("Menu");
	}
}
