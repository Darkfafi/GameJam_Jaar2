using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {

	void OnMouseEnter(){
		animation.Rewind ();
		animation.Play ();
		audio.Play ();
	}

	void OnMouseDown(){
		Application.LoadLevel("scene1");
	}   
}
