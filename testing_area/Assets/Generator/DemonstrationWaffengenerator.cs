/* Script zum generieren von Waffen !
 * 
 * Nicht vergessen:
 * 	TAG zur einteilung der Kategorie (klinge,heft,griff)
 * 	die Jeweiligen 3D Modelle in das array schieben
 * 
 * */
using UnityEngine;
using System.Collections;

public class DemonstrationWaffengenerator : MonoBehaviour
{
	public Transform GerüstSchwert;
	public Transform GerüstHammer;
	public Transform GerüstAxt;
	public Transform GerüstStangen;
	public Transform GerüstBogen;

	public Transform SpawnPos;
	
//	private string str_kombinationen;
	
	void Start()
	{
//		str_kombinationen = "Combinations: ";
//		str_kombinationen += klingen.Length+" x "+hefter.Length+" x "+griffe.Length+" = ";
//		str_kombinationen += (klingen.Length*hefter.Length*griffe.Length);
	}
	
	void OnGUI()
	{
//		GUI.Label( new Rect(Screen.width/2,10, 300,30), "Press \"Space\" 2 generate new weapon !");
//		GUI.Label( new Rect(Screen.width/2,23, 300,30), str_kombinationen);
		
		GUI.Label(new Rect(150,5, 200, 23), "vertices: "+PolygoneCounter.i_vertexCount);
		GUI.Label(new Rect(150,20, 200, 23), "triangles: "+PolygoneCounter.i_trianglesLength);
		
		GUILayout.BeginArea(new Rect(10,10,100,800));
		GUILayout.Label("Generieren :");
		
		if( GUILayout.Button(Schwertgenerator.anzahl+" Schwerter") )
		{
			Instantiate( this.GerüstSchwert, SpawnPos.position, Quaternion.identity);
		}
		if( GUILayout.Button(Hammergenerator.anzahl+" Hämmer") )
		{
			Instantiate( this.GerüstHammer, SpawnPos.position, Quaternion.identity);
		}
		if( GUILayout.Button(Axtgenerator.anzahl+" Äxte") )
		{
			Instantiate( this.GerüstAxt, SpawnPos.position, Quaternion.identity);
		}
		if( GUILayout.Button(Stangengenerator.anzahl+" Stangen") )
		{
			Instantiate( this.GerüstStangen, SpawnPos.position, Quaternion.identity);
		}
		if( GUILayout.Button(Bogengenerator.anzahl+" Bogen") )
		{
			Instantiate( this.GerüstBogen, SpawnPos.position, Quaternion.identity);
		}
		GUILayout.EndArea();
	}
	
	void Update()
	{
/*		if(Input.GetKeyDown(KeyCode.Space))
		{
			//Alte Teile löschen
			Destroy(GameObject.FindGameObjectWithTag("klinge"));
			Destroy(GameObject.FindGameObjectWithTag("angel"));			
			Destroy(GameObject.FindGameObjectWithTag("griff"));
			
			Destroy(this.GetComponent("model_demonstration"));
		}
		
		if(Input.GetKeyUp(KeyCode.Space))
		{
			//Neue Teile spawnen
			Instantiate(klingen[Random.Range(0,klingen.Length)], GameObject.Find("pos_klinge").transform.position, Quaternion.identity);
			Instantiate(hefter[Random.Range(0,hefter.Length)], GameObject.Find("pos_angel").transform.position, Quaternion.identity);
			Instantiate(griffe[Random.Range(0,griffe.Length)], GameObject.Find("pos_griff").transform.position, Quaternion.identity);

			GameObject.FindGameObjectWithTag("klinge").transform.parent = GameObject.Find("pos_klinge").transform;
			GameObject.FindGameObjectWithTag("angel").transform.parent = GameObject.Find("pos_angel").transform;			
			GameObject.FindGameObjectWithTag("griff").transform.parent = GameObject.Find("pos_griff").transform;

			//Veranschaulichung: Zufallsfarben setzen
//			GameObject.FindGameObjectWithTag("klinge").renderer.material.color = new Color(Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F));
//			GameObject.FindGameObjectWithTag("heft").renderer.material.color = new Color(Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F));
//			GameObject.FindGameObjectWithTag("griff").renderer.material.color = new Color(Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F));
			
			this.gameObject.AddComponent("model_demonstration");
		}
*/	}
}
