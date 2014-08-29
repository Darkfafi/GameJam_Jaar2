using UnityEngine;
using System.Collections;

public class BlockMovement : MonoBehaviour {

	public Vector2 speed = Vector2.zero;
	public bool isMoving = false;
	
	// Update is called once per frame
	public void move () {
		transform.Translate(speed);
	}
	public void checkCollide()
	{
		Collider2D[] allhits =  Physics2D.OverlapCircleAll(transform.position,0.45f);
		if(allhits.Length > 1)
		{
			if(gameObject.tag == "Player")
			{
				if(allhits[0].gameObject.tag == "Goal" || allhits[1].gameObject.tag == "Goal")
				{
					Application.LoadLevel(Application.loadedLevel + 1);
				}
				else if(allhits[0].gameObject.tag == "Goal" || allhits[1].gameObject.tag == "Goal")
				{

				}
				else
				{
					GetComponent<BlockCollision>().colliding();
				}
			}
			else
			{
				GetComponent<BlockCollision>().colliding();
			}
		}
	}

	public void stop()
	{
		isMoving = false;
		speed = Vector2.zero;
	}
}
