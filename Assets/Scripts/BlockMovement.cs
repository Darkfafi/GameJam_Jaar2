using UnityEngine;
using System.Collections;

public class BlockMovement : MonoBehaviour {

	public Vector2 speed = Vector2.zero;
	public bool isMoving = false;
	
	// Update is called once per frame
	void Update () {
		transform.Translate(speed);
	}

	public void stop()
	{
		speed = Vector2.zero;
	}
}
