using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class PlanetGravity : MonoBehaviour
{
	private Transform planet;

    public static float GRAVITY = 9.81F;
	
	void Start()
	{
		rigidbody.useGravity = false;
		planet = GameObject.Find("Planet").transform;
	}
	
    void Update()
	{
		Debug.DrawLine( transform.position, planet.position, Color.red );
		
		/*	Schwerkraft zieht dieses GameObject zum Planetenkern	*/
		Vector3 gravity = (planet.position-transform.position).normalized*GRAVITY;
		rigidbody.AddForce( gravity );
    }
}
