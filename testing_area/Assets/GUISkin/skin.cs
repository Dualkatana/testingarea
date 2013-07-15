using UnityEngine;
using System.Collections;

public class skin : MonoBehaviour
{
	public GUISkin customGUISkin;
	
	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{

	}
	
	void OnGUI()
	{
		GUI.skin = customGUISkin;

		GUILayout.BeginArea( new Rect( 5,5,Screen.width-10,Screen.height-10) );
		GUILayout.Label("Test 1234");
		GUILayout.Box("Box");
		GUILayout.EndArea();
	}
}
