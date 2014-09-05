using UnityEngine;
using System.Collections;

public class InputControll : MonoBehaviour {

	private int currentInputId = -1;
	private Vector3 startpos;
	private float startTime;
	private PlayerBlock playerScript;

	private delegate void InputCheck();
	InputCheck inputCheck;

	public float maxSwipeTime;
	public float minSwipeDistance;

	void Start()
	{
		playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBlock>();

		if(SystemInfo.deviceType == DeviceType.Desktop)
		{
			inputCheck = desktopInputCheck;
		}
		else if(SystemInfo.deviceType == DeviceType.Handheld)
		{
			inputCheck = handHeldInputCheck;
		}
	}
	
	// Update is called once per frame
	void Update () {

		inputCheck();
	}

	private void handHeldInputCheck()
	{
		if(currentInputId == -1)
		{
			foreach(Touch t in Input.touches)
			{
				if(t.phase == TouchPhase.Began)
				{
					currentInputId = t.fingerId;
					startpos = Camera.main.ScreenToWorldPoint(t.position);
					startTime = Time.time;
				}
			}
		}
		else
		{
			foreach(Touch t in Input.touches)
			{
				if(t.fingerId == currentInputId && t.phase == TouchPhase.Ended)
				{
					currentInputId = -1;
					Vector3 touchDistance = Camera.main.ScreenToWorldPoint(t.position) - startpos;
					if(Mathf.Abs(touchDistance.magnitude) > minSwipeDistance && Time.time-startTime < maxSwipeTime )
					{
						if(Mathf.Abs(touchDistance.x) > Mathf.Abs(touchDistance.y))
						{
							//Horizontal swipe
							if(touchDistance.x == Mathf.Abs(touchDistance.x))
							{
								//swipe right
								playerScript.move(new Vector2(1,0));
							}
							else
							{
								//swipe left
								playerScript.move(new Vector2(1,0));
							}
						}
						else
						{
							//Vertical swipe
							if(touchDistance.y == Mathf.Abs(touchDistance.y))
							{
								//swipe up
								playerScript.move(new Vector2(0,1));
							}
							else
							{
								//swipe down
								playerScript.move(new Vector2(0,-1));
							}
						}
					}
				}
			}
		}
	}

	private void desktopInputCheck()
	{
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			playerScript.move(new Vector2(0,1));
		}
		else if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			playerScript.move(new Vector2(0,-1));
		}
		else if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			playerScript.move(new Vector2(-1,0));
		}
		else if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			playerScript.move(new Vector2(1,0));
		}
		else if(Input.GetKeyDown(KeyCode.R))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
