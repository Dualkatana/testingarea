using UnityEngine;
using System.Collections;

public class Sys_bauen : MonoBehaviour
{
	public static uint Haltbarkeitgesamt;
	
	private string instruktionen = "Instruktionen Bauen:\n" +
	"<- Button Drücken um entsprechendes Bauteil zu erzeugen\n" +
	"-> LMT + Mausbewegen: Bauteil Bewegen\n" +
	"-> LMT + Mausrad: Bauteil weiter ran/weg\n" +
	"-> RMT + A/D: Bauteil mit dem Spieler Bewegen\n" +
	"-> <Q> oder <E> Gedrückthalten: Bauteil links/rechts Drehen\n" +
	"-> <ENTER> Festmachen: Bauteil Fixieren\n" +
	"Einzelne Bauphasen beachten !\n"+
	"Entfernungseinstellung mit Mausrad verbessern\n"+
	"Bei klick Bauteil an der Position anpassen, nicht mittig!\n";

	/*		Bauphase_I		*/
	public Transform PrefabBodenplatte;
	
	/*		Bauphase_II		*/
	public Transform PrefabHolzlatte;
	
	/*		Bauphase_III		*/
	public Transform PrefabNagel;
	// Use this for initialization
	void Start()
	{
		Haltbarkeitgesamt = 0;
	}
	
	
	void Update()
	{

	}
	
	void OnGUI()
	{
		/* Instruktionen:*/
		GUILayout.BeginArea( new Rect( Screen.width-400, 10, 400, 200) );
		GUILayout.Label( instruktionen );
		GUILayout.EndArea();
		
		GUILayout.BeginArea(new Rect(10, 10, 150, 300));
		GUILayout.Label("Haltbarkeit : "+Haltbarkeitgesamt);
		GUILayout.Label("Phase_I Baufläche:");
		if(GUILayout.Button("Bodenplatte") && !bauen.exist)
		{
			Instantiate( PrefabBodenplatte, transform.position, Quaternion.identity).name = "Bodenplatte";
		}
		GUILayout.Label("Phase_II Gerüst: ");
		if(GUILayout.Button("Holzlatte") && !bauen.exist)
		{
			Instantiate( PrefabHolzlatte, transform.position, Quaternion.identity).name = "Holzlatte";
		}
		GUILayout.Label("Phase_III Verstärkung:");
		if(GUILayout.Button("Nagel") && !bauen.exist)
		{
			Instantiate( PrefabNagel, transform.position, Quaternion.identity).name = "Nagel";
		}
		GUILayout.Label("Phase_VI Verkleidung");
		if(GUILayout.Button("Verkleidung") && !bauen.exist)
		{
			
		}
		GUILayout.EndArea();
	}
}
