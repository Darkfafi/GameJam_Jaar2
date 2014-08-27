using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBlock : MonoBehaviour {
	
	private List<GameObject> toCheck = new List<GameObject>();
	private List<GameObject> hasChecked = new List<GameObject>();
	public float maxSpeed;

	// Update is called once per frame
	void Update () {
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

	private void move(Vector2 dir)
	{

		toCheck.Add(gameObject);

		while(toCheck.Count > 0)
		{

			
			toCheck[0].GetComponent<BlockMovement>().isMoving = true;
			toCheck[0].GetComponent<BlockMovement>().speed = dir;

			Vector3 BlcPos = toCheck[0].transform.position;
			RaycastHit2D coll;

			//check left
			coll = Physics2D.Raycast(BlcPos + new Vector3(-1,0,0),BlcPos + new Vector3(-1,0,0));
			if(coll.collider != null)
			{ checkBlc(coll.collider.gameObject); }

			//check right
			coll = Physics2D.Raycast(BlcPos + new Vector3(1,0,0),BlcPos + new Vector3(1,0,0));
			if(coll.collider != null)
			{ checkBlc(coll.collider.gameObject); }

			//check up
			coll = Physics2D.Raycast(BlcPos + new Vector3(0,1,0),BlcPos + new Vector3(0,1,0));
			if(coll.collider != null)
			{ checkBlc(coll.collider.gameObject); }

			//check down
			coll = Physics2D.Raycast(BlcPos + new Vector3(0,-1,0),BlcPos + new Vector3(0,-1,0));
			if(coll.collider != null)
			{ checkBlc(coll.collider.gameObject); }

			toCheck[0].GetComponent<BlockMovement>().speed = dir;

			hasChecked.Add(toCheck[0]);
			toCheck.RemoveAt(0);
		}
	}


	//+++Needs to be turned to void+++
	private bool checkBlc(GameObject blck)
	{
		if(blck != null && !blck.GetComponent<BlockMovement>().isMoving && (blck.tag == "SlimeStr" || blck.tag == "SlimeWek"))
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
			Debug.Log("Addcube");
			return true;
		}



		return false;
	}

}
