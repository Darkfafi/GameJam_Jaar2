﻿using UnityEngine;
using System.Collections;

public class HowToPlayScript : MonoBehaviour {

	void OnMouseEnter(){
		animation.Rewind ();
		animation.Play ();
		audio.Play ();
	}
	
	void OnMouseDown(){
		Application.LoadLevel("HelpScreen");
	}   
}