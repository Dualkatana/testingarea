using UnityEngine;
using System.Collections;

public class model_demonstration : MonoBehaviour
{
	/* Hinweis: Das angehangene 3D_Modell muss den Tag "3D_Modell" zugewiesen bekommen ! */
	public int geschwindigkeit = 40;
	private static int i_vertexCount = 0;
	private static int i_trianglesLength = 0;
	
	public string str_anmerkung;
	
	private GameObject go_modell;
	
	void Start()
	{
		MeshFilter[] meshes = gameObject.GetComponentsInChildren<MeshFilter>();
        foreach(MeshFilter m in meshes)
		{
			i_vertexCount += m.mesh.vertexCount;
			i_trianglesLength += m.mesh.triangles.Length/3;
			//info: Jeder "punkt" hat 3 verbindungen d.h. anz / 3
        }
	}

	void Update()
	{
		//Drehung
		transform.Rotate(0, geschwindigkeit*Time.deltaTime, 0);
	}
	
	void OnGUI()
	{
		GUI.Label(new Rect(150,5, 200, 23), "vertices: "+i_vertexCount);
		GUI.Label(new Rect(150,20, 200, 23), "triangles: "+i_trianglesLength);
		
		if( !str_anmerkung.Equals(string.Empty) )
			GUI.Label(new Rect(10,Screen.height-110,Screen.width,100), str_anmerkung);
	}
}
