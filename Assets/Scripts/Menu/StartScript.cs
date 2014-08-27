using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {

	void OnMouseEnter(){
		animation.Rewind ();
		animation.Play ();
	}

	void OnMouseDown(){
		Application.LoadLevel("scene1");
	}   
}
