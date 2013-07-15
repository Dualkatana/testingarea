using UnityEngine;
using System.Collections;

public class horizontalMoving : MonoBehaviour
{
	public Transform[] waypoints;
	public float speed;
	
	private int currentPosition;
	
	void Start()
	{
		currentPosition = 0;
	}

	void Update()
	{
		Debug.DrawLine( waypoints[0].position, waypoints[1].position, Color.red);
			
		if( currentPosition == waypoints.Length )
			currentPosition = 0;
		else
		{
			if( transform.position != waypoints[currentPosition].position )
				transform.position = Vector3.MoveTowards( transform.position, waypoints[currentPosition].position, speed*Time.deltaTime);
			else
				currentPosition++;
		}
	}
}
