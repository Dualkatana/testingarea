using UnityEngine;
using System.Collections;

public class PolygoneCounter : MonoBehaviour
{
	/* Hinweis: Das angehangene 3D_Modell muss den Tag "3D_Modell" zugewiesen bekommen ! */
//	public int geschwindigkeit = 40;
	public static int i_vertexCount = 0;
	public static int i_trianglesLength = 0;
	
	private int thisVertexCount = 0;
	private int thistrianglesLength = 0;
	
	private GameObject go_modell;
	
	void Start()
	{
		MeshFilter[] meshes = gameObject.GetComponentsInChildren<MeshFilter>();
        foreach(MeshFilter m in meshes)
		{
			thisVertexCount += m.mesh.vertexCount;
			thistrianglesLength += m.mesh.triangles.Length/3;
			//info: Jeder "punkt" hat 3 verbindungen d.h. anz / 3
        }
		i_vertexCount += thisVertexCount;
		i_trianglesLength += thistrianglesLength;
	}

	void Update()
	{
		//Drehung
		//transform.Rotate(0, geschwindigkeit*Time.deltaTime, 0);
	}
	
/*	void OnGUI()
	{
		{
			GUI.Label(new Rect(150,5, 200, 23), "vertices: "+i_vertexCount);
			GUI.Label(new Rect(150,20, 200, 23), "triangles: "+i_trianglesLength);
		}
	}
*/
	
	void OnDestroy()
	{
        i_vertexCount -= thisVertexCount;
		i_trianglesLength -= thistrianglesLength;
    }
}
