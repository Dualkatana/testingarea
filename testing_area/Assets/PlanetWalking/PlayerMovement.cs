using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	private Transform planet;
	private Vector3 moveDirection = Vector3.zero;
	
    public float walkSpeed;
	public float rotationLookSpeed;
    public float jumpPower;
	
	void Start()
	{
		planet = GameObject.Find("Planet").transform;
	}
	
	void Update() 
	{
		/*	Bewegung in abhängig von der Position zum Planeten	*/
		moveDirection = transform.position;
		
		movement();
		
		if( Input.GetKeyDown( KeyCode.Space ) )
			doJump();
		
		transform.position = moveDirection;
		
		/*	Spielerdrehung in abhängigkeit zum Planeten	*/
		rotating();
	}
	
	private void doJump()
	{
		Vector3 TransformedDirection = transform.TransformDirection( Vector3.up );
		rigidbody.velocity = TransformedDirection*jumpPower;
	}
	
	
	private void rotating()
	{
		//Berechnung der normalen vom Planetenmittelpunkt zum Spieler (Richtung -> vector)
		Vector3 planetNormale = transform.position-planet.position;
		planetNormale.Normalize();
		
		//Spieler neu zum Planetenmittelpunkt ausrichten (alter rot der neuen hinzufügen )
		transform.rotation = Quaternion.FromToRotation(transform.up, planetNormale) * transform.rotation;
		
		//Berechnung der Blickrichtung beim Drehen auf dem Planeten
		Quaternion headingDelta = Quaternion.AngleAxis(Input.GetAxis("Rotating")*rotationLookSpeed*Time.deltaTime, transform.up);
		
		//zusammenfassen
		transform.rotation = headingDelta * transform.rotation;
	}
	
	private void movement()
	{
		Vector3 direction = new Vector3(Input.GetAxis("HorizontalMove"), 0, Input.GetAxis("VerticalMove"));
		//von global nach lokal
		Vector3 TransformedDirection = transform.TransformDirection( direction );
		moveDirection += (TransformedDirection*walkSpeed*Time.deltaTime);
	}

}
