using UnityEngine;
using System.Collections;

public class IngameFPS : MonoBehaviour
{
	private uint fps;
	private uint tmp;
	private float time;
	
	void Start()
	{
		time = 0;
	}
	
	void OnGUI()
	{
		GUI.Label( new Rect(Screen.width-100,5,100,20), "v 1.0 FPS:"+fps);
	}
	
	void Update()
	{
		time += Time.deltaTime;
		tmp++;
		if( time > 1.0F )
		{
			//Debug.Log(fps);
			fps = tmp;
			tmp = 0;
			time = 0;
		}
	}
}
