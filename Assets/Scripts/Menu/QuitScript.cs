using UnityEngine;
using System.Collections;

public class QuitScript : MonoBehaviour {

	void OnMouseEnter(){
		animation.Rewind ();
		animation.Play ();
	}

	void OnMouseDown(){
		Application.Quit();
	} 
}
