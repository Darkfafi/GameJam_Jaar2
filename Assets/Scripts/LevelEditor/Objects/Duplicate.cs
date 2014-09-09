using UnityEngine;
using System.Collections;

public class Duplicate : MonoBehaviour {
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction);

			if(hit.collider !=null)
			{
				Debug.Log("prefab/" + hit.collider.name);
				GameObject duplicate = Instantiate(Resources.Load("Prefabs/" + hit.collider.name), new Vector2(0,0),Quaternion.identity);
				duplicate.AddComponent<
			}
		}
	}
}
