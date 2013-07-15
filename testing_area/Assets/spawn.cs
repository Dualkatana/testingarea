using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour
{
	public GameObject geschoss;
	private GameObject go_ziel;
	
	private Vector3 v3_neue_Position;
	
	void Start()
	{
		go_ziel = GameObject.FindWithTag("ziel");
	}
	
	void Update()
	{
	
	}
	
	void OnGUI()
	{
		if( GUI.Button(new Rect(10, 50, 100, 30), "Reset" ) )
			Application.LoadLevel(0);
			
		if( GUI.Button(new Rect(10,10,100,30), "Feuer !") )
			Instantiate(geschoss, transform.position, Quaternion.identity);
		
		v3_neue_Position = go_ziel.transform.position;
		
		if( GUI.Button(new Rect(200,50,30,30), "<-") )
		{
			v3_neue_Position.x += 1;
		}
		if( GUI.Button(new Rect(235,50,30,30), "->") )
		{
			v3_neue_Position.x += -1;
		}		
		if( GUI.Button(new Rect(217,20,30,30), "^") )
		{
			v3_neue_Position.y += 1;
		}
		if( GUI.Button(new Rect(217,80,30,30), "v") )
		{
			v3_neue_Position.y += -1;
		}
		go_ziel.transform.position = v3_neue_Position;
	}
}
