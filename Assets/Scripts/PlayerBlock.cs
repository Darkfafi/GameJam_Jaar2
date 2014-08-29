using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBlock : MonoBehaviour {
	
	private List<GameObject> toCheck = new List<GameObject>();
	private List<GameObject> hasChecked = new List<GameObject>();
	public float maxSpeed;

	private List<BlockMovement> allBlocks = new List<BlockMovement>();

	void Start()
	{
		allBlocks.Add(GetComponent<BlockMovement>());
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("SlimeWek"))
		{
			allBlocks.Add(obj.GetComponent<BlockMovement>());
		}
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("SlimeStr"))
		{
			allBlocks.Add(obj.GetComponent<BlockMovement>());
		}
	}

	// Update is called once per frame
	void Update () {


		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			move(new Vector2(0,maxSpeed));
		}
		else if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			move(new Vector2(0,-maxSpeed));
		}
		else if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			move(new Vector2(-maxSpeed,0));
		}
		else if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			move(new Vector2(maxSpeed,0));
		}
		else if(Input.GetKeyDown(KeyCode.R))
		{
			Application.LoadLevel(Application.loadedLevel);
		}


		foreach(BlockMovement mve in allBlocks)
		{
			mve.move();
		}
		foreach(BlockMovement mve in allBlocks)
		{
			mve.checkCollide();
		}
	}

	private void move(Vector2 dir)
	{

		bool canMove = true;
		foreach(BlockMovement mve in allBlocks){
			if(mve.isMoving)
			{  canMove = false;  }
		}

		if(canMove)
		{
			toCheck.Add(gameObject);

			while(toCheck.Count > 0)
			{

				
				toCheck[0].GetComponent<BlockMovement>().isMoving = true;
				toCheck[0].GetComponent<BlockMovement>().speed = dir;

				Collider2D[] coll;

				coll = Physics2D.OverlapCircleAll(toCheck[0].transform.position,0.7f);

				foreach(Collider2D col in coll)
				{
					checkBlc(col.gameObject);
				}


				hasChecked.Add(toCheck[0]);
				toCheck.RemoveAt(0);
			}

			hasChecked.Clear();
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
