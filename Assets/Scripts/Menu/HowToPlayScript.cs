using UnityEngine;
using System.Collections;

public class HowToPlayScript : MonoBehaviour {
	
	public GameObject quitBut;
	public GameObject startBut;
	public GameObject helpScreen;

	void OnMouseEnter(){
		animation.Rewind ();
		animation.Play ();
		audio.Play ();
	}
	
	void OnMouseDown(){
		Instantiate (helpScreen, new Vector3(0,0,-1), this.transform.rotation);
		gameObject.collider2D.enabled = false;
		startBut.collider2D.enabled = false;
		quitBut.collider2D.enabled = false;
	}   
}
