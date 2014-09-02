using UnityEngine;
using System.Collections;

public class Duplicate : MonoBehaviour {

	void Update () {

		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

		if(hit.collider !=null)
		{
			Debug.Log("nice");
		}

	}
}
