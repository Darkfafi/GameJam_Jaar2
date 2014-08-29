using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {

	bool doorMove = false;

	public GameObject leftBar;
	public GameObject rightBar;
	public AudioClip doorSound;

	float speed = 0.05f;
	
	void OnMouseEnter(){
		animation.Rewind ();
		animation.Play ();
		audio.Play ();
	}

	void OnMouseDown(){
		audio.clip = doorSound;
		doorMove = true;
		audio.Play ();
		//Application.LoadLevel("scene1");
	}

	void Update(){
		if (doorMove == true){
			if (leftBar.transform.position.x < 0) {
				leftBar.transform.Translate (new Vector2 (speed, 0));
			}
			if (rightBar.transform.position.x > 0) {
				rightBar.transform.Translate (new Vector2 (-speed, 0));
			}
			if(leftBar.transform.position.x > 0 && rightBar.transform.position.x < 0){
				Application.LoadLevel("scene1");
			}
		}
	}
}
