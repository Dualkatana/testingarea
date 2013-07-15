using UnityEngine;
using System.Collections;

public class PlanetRotation : MonoBehaviour
{
	public float rotationSpeed;
	
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
		transform.RotateAround( Vector3.forward, rotationSpeed*Time.deltaTime );
	}
}
