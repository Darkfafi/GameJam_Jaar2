using UnityEngine;
using System.Collections;

public class Duplicate : MonoBehaviour {
	private Vector3 mousePos;

	void OnMouseDown(){

		mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,0));
		mousePos.x = 0;
		mousePos.y = 0;
		Debug.Log("prefab/" + gameObject.name);
		GameObject duplicate = Instantiate(Resources.Load("Prefabs/" + gameObject.name), new Vector2(mousePos.x,mousePos.y),Quaternion.identity) as GameObject;
		duplicate.AddComponent<MoveObject>();
		duplicate.GetComponent<SpriteRenderer>().sortingOrder = 3;
	}
}
