using UnityEngine;
using System.Collections;

public class LvlDoorScripts : MonoBehaviour {

	public Transform left;
	public Transform right;
	public bool closeNow = false;
	private bool openNow = true;
	
	// Update is called once per frame
	void Update () {
		if(closeNow)
		{
			left.Translate(new Vector2(0.1f,0));
			right.Translate(new Vector2(-0.1f,0));
			if(left.localPosition.x > -9.75)
			{
				Application.LoadLevel(Application.loadedLevel + 1);
			}
		}
		else if(openNow)
		{
			left.Translate(new Vector3(-0.1f,0,0));
			right.Translate(new Vector3(0.1f,0,0));
			if(left.localPosition.x < -15.7f)
			{
				left.transform.localPosition = new Vector3(-15.7f,0,0);
				right.transform.localPosition = new Vector3(15.7f,0,0);
				openNow = false;
			}
		}
	}
}
