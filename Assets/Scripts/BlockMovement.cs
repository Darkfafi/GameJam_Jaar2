using UnityEngine;
using System.Collections;

public class BlockMovement : MonoBehaviour {

	public Vector2 speed = Vector2.zero;
	public bool isMoving = false;
	
	// Update is called once per frame
	public void move () {
		transform.Translate(speed * Time.deltaTime);
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
					PlayerPrefs.SetInt("unlock"+(Application.loadedLevel - 1),1);
					GameObject.FindGameObjectWithTag("SideDoors").GetComponent<LvlDoorScripts>().closeNow = true;
				}
				else if(allhits[0].gameObject.tag == "DeathWall" || allhits[1].gameObject.tag == "DeathWall")
				{
					GameObject.FindGameObjectWithTag("SideDoors").GetComponent<LvlDoorScripts>().closeNow = true;
					GameObject.FindGameObjectWithTag("SideDoors").GetComponent<LvlDoorScripts>().reset = true;
					Destroy(gameObject);
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
