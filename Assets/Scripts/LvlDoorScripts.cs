using UnityEngine;
using System.Collections;

public class LvlDoorScripts : MonoBehaviour {

	public Transform left;
	public Transform right;
	public bool closeNow = false;
	public bool reset = false;
	private bool openNow = true;
	public ButtonRotate[] uiButtons;
	public string lvlOverRide;
	
	// Update is called once per frame
	void Update () {
		if(closeNow)
		{
			foreach(ButtonRotate but in uiButtons)
			{
				but.turnDirect = -1;
			}

			left.Translate(new Vector2(6*Time.deltaTime,0));
			right.Translate(new Vector2(-6*Time.deltaTime,0));
			if(left.localPosition.x > -9.75)
			{
				Debug.Log(lvlOverRide);
				if(lvlOverRide != "")
				{
					Application.LoadLevel(lvlOverRide);
				}
				else if(reset)
				{
					Application.LoadLevel(Application.loadedLevel);
				}
				else
				{
					Application.LoadLevel(Application.loadedLevel + 1);
				}
			}
		}
		else if(openNow)
		{
			left.Translate(new Vector3(-6*Time.deltaTime,0,0));
			right.Translate(new Vector3(6*Time.deltaTime,0,0));
			if(left.localPosition.x < -15.7f)
			{
				foreach(ButtonRotate but in uiButtons)
				{
					but.turnDirect = 1;
				}

				left.transform.localPosition = new Vector3(-15.7f,0,0);
				right.transform.localPosition = new Vector3(15.7f,0,0);
				openNow = false;
			}
		}
	}
}
