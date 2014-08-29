using UnityEngine;
using System.Collections;

public class HelpScreenScript : MonoBehaviour {

	GameObject startBut;
	GameObject helpBut;
	GameObject quitBut;

	void Start(){
		//Debug.Log("afsfafs");
		startBut = GameObject.FindGameObjectWithTag("StartButton");
		helpBut = GameObject.FindGameObjectWithTag("HelpButton");
		quitBut = GameObject.FindGameObjectWithTag("QuitButton");
	}

	void OnMouseDown(){
		//Debug.Log("afsfafs2");
		helpBut.collider2D.enabled = true;
		startBut.collider2D.enabled = true;
		quitBut.collider2D.enabled = true;
		Destroy (this.gameObject);
	}  
}
