using UnityEngine;
using System.Collections;

public class GUIChat
{
	private bool b_wirdAngezeigt;
	
	private float breite;
	private float höhe;
	
	public GUIChat()
	{
		b_wirdAngezeigt = false;
		
		breite = (Screen.width/3) - (2*GUIGlobal.f_offset_around);
		höhe = (Screen.height/3) - (2*GUIGlobal.f_offset_around);
	}
	
	public void einblenden()
	{
		if( b_wirdAngezeigt )
			ausblenden();
		else
		{
			b_wirdAngezeigt = true;
			Debug.Log("Chat einblenden");
		}
	}
	
	public void ausblenden()
	{
		b_wirdAngezeigt = false;
		Debug.Log("Chat ausblenden");
	}
	
	public void drawGUI()
	{
		if( b_wirdAngezeigt )
		{
			GUI.Window(1, new Rect(GUIGlobal.f_offset_around, Screen.height-GUIGlobal.f_offset_around-höhe, breite, höhe), GUIChatWindow, "Chat");
		}
	}
	
	void GUIChatWindow(int windowID)
	{
		GUI.Label(new Rect( 10,10,150,30), "Inhalt...");
	}
}
