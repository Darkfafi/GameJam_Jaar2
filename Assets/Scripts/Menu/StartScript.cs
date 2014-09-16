using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {

	public GameObject leftBar;
	public GameObject rightBar;
	public AudioClip doorSound;

	void OnMouseEnter(){
		animation.Rewind ();
		animation.Play ();
		audio.Play ();
	}

	void OnMouseDown(){
		audio.clip = doorSound;
		GameObject.FindGameObjectWithTag("SideDoors").GetComponent<LvlDoorScripts>().lvlOverRide = "LevelSelect";
		GameObject.FindGameObjectWithTag("SideDoors").GetComponent<LvlDoorScripts>().closeNow = true;
		audio.Play ();

		GameObject.FindGameObjectWithTag("HelpButton").collider2D.enabled = false;
		GameObject.FindGameObjectWithTag("StartButton").collider2D.enabled = false;
		GameObject.FindGameObjectWithTag("QuitButton").collider2D.enabled = false;
	}
}
