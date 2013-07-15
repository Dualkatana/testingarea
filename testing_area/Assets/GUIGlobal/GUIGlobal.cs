using UnityEngine;
using System.Collections;

public class GUIGlobal : MonoBehaviour
{
	public static float f_offset_around = 10.0F;
	public static float f_button_size = 40.0F;
	
	//Variablen für die Menüpunkte
	private GUIHauptmenü hauptmenü;
	private GUIChat chat;
	private GUISkillbar skillbar;
	
	/*Verteileung Window ID:
	 * 0	Hauptmenü
	 * 1	Chat
	 * 2	Fähigkeiten
	 * */
	
	void Start()
	{
		hauptmenü = new GUIHauptmenü();
		chat = new GUIChat();
		skillbar = new GUISkillbar();
	}
	
	void Update()
	{
	
	}
	
	void OnGUI()
	{
		//Anzeigen
		hauptmenü.drawGUI();
		chat.drawGUI();
		skillbar.drawGUI();
		
		if( GUI.Button( new Rect(f_offset_around, f_offset_around, f_button_size, f_button_size), "H"))
		{
			hauptmenü.einblenden();
		}
		
		if( GUI.Button( new Rect(f_offset_around, Screen.height-f_offset_around-f_button_size, f_button_size, f_button_size), "C") )
		{
			chat.einblenden();
		}
			
		if( GUI.Button( new Rect(Screen.width-f_button_size-f_offset_around, Screen.height-f_offset_around-f_button_size, f_button_size, f_button_size), "T") )
		{
			skillbar.einblenden();
		}
	}
}
