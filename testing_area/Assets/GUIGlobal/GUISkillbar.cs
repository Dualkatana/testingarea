using UnityEngine;
using System.Collections;

public class GUISkillbar
{
	private bool b_wirdAngezeigt;
	
	private float breite;
	private float höhe;
	
	public GUISkillbar()
	{
		b_wirdAngezeigt = false;
		
		breite = (Screen.width/3)*2 - (2*GUIGlobal.f_offset_around);
		höhe = 50;
	}
	
	public void einblenden()
	{
		if( b_wirdAngezeigt )
			ausblenden();
		else
		{
			b_wirdAngezeigt = true;
			Debug.Log("Skillbar einblenden");
		}
	}
	
	public void ausblenden()
	{
		b_wirdAngezeigt = false;
		Debug.Log("Skillbar ausblenden");
	}
	
	public void drawGUI()
	{
		if( b_wirdAngezeigt )
		{
			GUI.Window(2, new Rect(Screen.width-breite-GUIGlobal.f_offset_around, Screen.height-höhe-GUIGlobal.f_offset_around, breite, höhe), GUISkillbarWindow, "Skillbar");			
		}
	}
	
	void GUISkillbarWindow(int windowID)
	{
		GUI.Label(new Rect( 10,10,150,30), "Inhalt...");
	}
}
