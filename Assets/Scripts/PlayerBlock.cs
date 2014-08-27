using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBlock : MonoBehaviour {
	
	private List<GameObject> toCheck = new List<GameObject>();
	private List<GameObject> hasChecked = new List<GameObject>();
	public float maxSpeed;

	// Update is called once per frame
	void Update () {
		if(GetComponent<BlockMovement>().isMoving)
		{
			if(Input.GetKey(KeyCode.UpArrow))
			{
				move(new Vector2(0,maxSpeed));
			}
			else if(Input.GetKey(KeyCode.DownArrow))
			{
				move(new Vector2(0,-maxSpeed));
			}
			else if(Input.GetKey(KeyCode.LeftArrow))
			{
				move(new Vector2(-maxSpeed,0));
			}
			else if(Input.GetKey(KeyCode.RightArrow))
			{
				move(new Vector2(maxSpeed,0));
			}
		}
	}

	private void move(Vector2 dir)
	{

		toCheck.Add(gameObject);

		while(toCheck.Count > 0)
		{

			
			toCheck[0].GetComponent<BlockMovement>().isMoving = true;
			toCheck[0].GetComponent<BlockMovement>().speed = dir;

			Vector3 BlcPos = toCheck[0].transform.position;
			Collider2D[] coll;

			coll = Physics2D.OverlapCircleAll(toCheck[0].transform.position,0.7f);

			foreach(Collider2D col in coll)
			{
				checkBlc(col.gameObject);
			}


			toCheck[0].GetComponent<BlockMovement>().speed = dir;

			hasChecked.Add(toCheck[0]);
			toCheck.RemoveAt(0);
		}
	}


	//+++Needs to be turned to void+++
	private bool checkBlc(GameObject blck)
	{
		if(blck != null && (blck.tag == "SlimeStr" || blck.tag == "SlimeWek") && !blck.GetComponent<BlockMovement>().isMoving )
		{

			foreach(GameObject blk in toCheck)
			{
				if(blk == blck)
				{	return false;	}
			}
			foreach(GameObject blk in hasChecked)
			{
				if(blk == blck)
				{	return false;	}
			}
			
			blck.GetComponent<BlockMovement>().isMoving = true;
			toCheck.Add(blck);
			return true;
		}



		return false;
	}

}
