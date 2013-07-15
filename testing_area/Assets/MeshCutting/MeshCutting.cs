using UnityEngine;
using System.Collections;

public class MeshCutting : MonoBehaviour
{
	void Start()
	{
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		mesh.Optimize();
		foreach( Vector3 v3 in mesh.vertices )
		{
			Debug.Log( v3 );
		}
	}
	
	void Update()
	{
	
	}
}
