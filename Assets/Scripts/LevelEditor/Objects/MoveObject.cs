using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {
	private Vector3 screenpoint;
	private float lockedZPosition;
	

	void OnMouseDown(){
		lockedZPosition = screenpoint.z;
		Screen.showCursor = false;
	}

	void OnMouseDrag(){

		Vector3 curPosition = Camera.main.ScreenToWorldPoint(new Vector3(Mathf.Round(Input.mousePosition.x), Mathf.Round(Input.mousePosition.y), screenpoint.z));
		curPosition.z = lockedZPosition;
		transform.position = curPosition;

	}

	void OnMouseUp(){
		gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
		var currentPos = transform.position;
		transform.position = new Vector3(Mathf.Round(currentPos.x), Mathf.Round(currentPos.y), Mathf.Round(currentPos.z));
		if(transform.position.x <= -1 || transform.position.x >= 12 || transform.position.y >= 1 || transform.position.y <= -12)
		{
			Destroy(gameObject);
		}
		Screen.showCursor = true;

	}
	
}
