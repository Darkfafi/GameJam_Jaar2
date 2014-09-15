﻿using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {

	bool doorMove = false;

	public GameObject leftBar;
	public GameObject rightBar;
	public AudioClip doorSound;

	float speed = 6f;

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
