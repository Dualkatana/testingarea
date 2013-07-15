using UnityEngine;
using System.Collections;

public class AI_Pathfinding : MonoBehaviour
{
	private Transform target;
	private float movementSpeed = 3.0f;
	
	void Start()
	{
		target = GameObject.FindWithTag("Player").transform;
	}

	void Update()
	{
		transform.LookAt( target.position );
		
		transform.Translate(Vector3.forward*movementSpeed*Time.deltaTime);
	}
}
