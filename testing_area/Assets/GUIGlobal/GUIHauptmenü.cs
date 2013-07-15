using UnityEngine;
using System.Collections;

public class GUIHauptmenü
{
	private bool b_wirdAngezeigt;
	
	private float breite;
	private float höhe;
	
	public GUIHauptmenü()
	{
		b_wirdAngezeigt = false;
		
		breite = (Screen.width/3) - (2*GUIGlobal.f_offset_around);
		höhe = (Screen.height/3)*2 - (2*GUIGlobal.f_offset_around);
	}
	
	public void einblenden()
	{
		if( b_wirdAngezeigt )
			ausblenden();
		else
		{
			b_wirdAngezeigt = true;
			Debug.Log("Hauptmenü einblenden");
		}
	}
	
	public void ausblenden()
	{
		b_wirdAngezeigt = false;
		Debug.Log("Hauptmenü ausblenden");
	}
	
	public void drawGUI()
	{
		if( b_wirdAngezeigt )
		{
			GUI.Window(0, new Rect( GUIGlobal.f_offset_around, GUIGlobal.f_offset_around, breite, höhe), GUIHauptmenüWindow, "Hauptmenü");
		}
	}
	
	void GUIHauptmenüWindow(int windowID)
	{
		GUI.Label(new Rect( 10,10,150,30), "Inhalt...");
	}
}
