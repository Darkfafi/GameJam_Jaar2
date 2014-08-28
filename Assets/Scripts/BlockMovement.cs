using UnityEngine;
using System.Collections;

public class BlockMovement : MonoBehaviour {

	public Vector2 speed = Vector2.zero;
	public bool isMoving = false;
	
	// Update is called once per frame
	public void move () {
		transform.Translate(speed);
		if(Physics2D.OverlapCircleAll(transform.position,0.4f).Length > 1)
		{
			Debug.Log("T");
		}
		
	}

	public void stop()
	{
		isMoving = false;
		speed = Vector2.zero;
	}
}
