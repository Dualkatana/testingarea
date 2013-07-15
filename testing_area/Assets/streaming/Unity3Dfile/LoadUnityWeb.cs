using UnityEngine;
using System.Collections;

public class LoadUnityWeb : MonoBehaviour
{
	private WWW stream;	
	
	void Start()
	{
	
	}
	
	void OnGUI()
	{
		if( GUI.Button(new Rect( 50,50,100,25),"Load") )
		{
			StartCoroutine(StartLoad());
		}
		if(stream.progress != 0)
		{			
			GUI.Box(new Rect(0,0,Screen.width*stream.progress,25),"");
			GUI.Label(new Rect(Screen.width/2,0,100,25), (stream.progress*100).ToString("N2")+" %");
		}
	}
	
	IEnumerator StartLoad()
	{
        stream = new WWW("http://cm-game.no-ip.biz/data/webinterface/unity_lifedemos/fremd/whale.unity3d");
		
        while(!stream.isDone)
		{
            yield return null;
        }

        stream.LoadUnityWeb();
    }
}
