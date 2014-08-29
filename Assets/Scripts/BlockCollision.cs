using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockCollision : MonoBehaviour {

	private List<GameObject> toCheck = new List<GameObject>();
	private List<GameObject> hasChecked = new List<GameObject>();

	public void colliding()
	{

		toCheck.Add(gameObject);
		
		while(toCheck.Count > 0)
		{

			if(toCheck[0].tag != "SlimeWek")
			{
				Collider2D[] coll;
				coll = Physics2D.OverlapCircleAll(toCheck[0].transform.position,0.7f);
				foreach(Collider2D col in coll)
				{
					checkBlc(col.gameObject);
				}
			}

			toCheck[0].GetComponent<BlockMovement>().stop();
			toCheck[0].transform.position = new Vector3(Mathf.Round(toCheck[0].transform.position.x),Mathf.Round(toCheck[0].transform.position.y),Mathf.Round(toCheck[0].transform.position.z));
			
			hasChecked.Add(toCheck[0]);
			toCheck.RemoveAt(0);
		}
		hasChecked.Clear();
	}

	private bool checkBlc(GameObject blck)
	{
		if(blck != null && (blck.tag == "SlimeStr" || blck.tag == "Player") && blck.GetComponent<BlockMovement>().isMoving )
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
			
			blck.GetComponent<BlockMovement>().isMoving = false;
			toCheck.Add(blck);
			return true;
		}
		
		
		
		return false;
	}

}
