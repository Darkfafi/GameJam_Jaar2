using UnityEngine;
using System.Collections;

public class HowToPlayScript : MonoBehaviour {

	void OnMouseEnter(){
		animation.Rewind ();
		animation.Play ();
	}
	
	void OnMouseDown(){
		Application.LoadLevel("HelpScreen");
	}   
}
