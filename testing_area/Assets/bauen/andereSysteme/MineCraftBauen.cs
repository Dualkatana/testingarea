/*Note: Konvertiert von Java -> C#*/
using UnityEngine;
using System.Collections;

public class MineCraftBauen : MonoBehaviour
{
	public GameObject Block;
	
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
		if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
		{
			Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition);
			RaycastHit hit;
			if( Physics.Raycast(ray, out hit, 20.0F) ) //http://docs.unity3d.com/Documentation/ScriptReference/Physics.Raycast.html
			{
				//Wir haben einen Treffer
				if( Input.GetMouseButtonDown(1) )
				{
					//Transform newBlock = Instantiate
					Instantiate(Block, hit.collider.transform.position+hit.normal.normalized, Quaternion.identity);
				}
				else
				{
					Destroy(hit.transform.gameObject);
				}
			}
		}
	}
}
