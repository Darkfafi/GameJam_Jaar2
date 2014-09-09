using UnityEngine;
using System.Collections;

public class ButtonRotate : MonoBehaviour {

	public bool leftButton;
	public int turnDirect = 0;

	void Start()
	{
		if(leftButton)
		{
			transform.position = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(0,0,0)).x,transform.position.y);

			transform.GetChild(0).localPosition = new Vector2(-1,1);
			gameObject.GetComponent<CircleCollider2D>().center = new Vector2(-1,1);
		}
		else
		{
			transform.position = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0,0)).x,transform.position.y);

			transform.GetChild(0).localPosition = new Vector2(1,1);
			gameObject.GetComponent<CircleCollider2D>().center = new Vector2(1,1);
		}
	}

	// Update is called once per frame
	void Update () {
		if(turnDirect == 1)
		{
			if(leftButton)
			{
				transform.Rotate(new Vector3(0,0,-2));
				if(transform.rotation.eulerAngles.z < 270)
				{
					turnDirect = 0;
					Quaternion tPos = transform.rotation;
					tPos.eulerAngles = new Vector3(0,0,270);
					transform.rotation = tPos;
				}
			}
			else
			{
				transform.Rotate(new Vector3(0,0,2));
				if(transform.rotation.eulerAngles.z > 90)
				{
					turnDirect = 0;
					Quaternion tPos = transform.rotation;
					tPos.eulerAngles = new Vector3(0,0,90);
					transform.rotation = tPos;
				}
			}
		}
		else if(turnDirect == -1)
		{
			if(leftButton)
			{
				transform.Rotate(new Vector3(0,0,2));
				if(transform.rotation.eulerAngles.z < 90)
				{
					turnDirect = 0;
					Quaternion tPos = transform.rotation;
					tPos.eulerAngles = new Vector3(0,0,0);
					transform.rotation = tPos;
				}
			}
			else
			{
				transform.Rotate(new Vector3(0,0,-2));
				if(transform.rotation.eulerAngles.z > 90)
				{
					turnDirect = 0;
					Quaternion tPos = transform.rotation;
					tPos.eulerAngles = new Vector3(0,0,0);
					transform.rotation = tPos;
				}
			}
		}
	}
}










