using UnityEngine;
using System.Collections;

public class bewegung : MonoBehaviour
{
	//Variable für das Ziel:
	private GameObject go_ziel;
	private float f_geschwindigkeit = 1f;
	
	private Vector3 v3_richtung;
	
	private bool b_treffer;
	
	void Start()
	{
		go_ziel = GameObject.FindWithTag("ziel");
		b_treffer = false;
		v3_richtung = new Vector3( (go_ziel.transform.position.x - this.transform.position.x)*f_geschwindigkeit ,
			                       (go_ziel.transform.position.y - this.transform.position.y)*f_geschwindigkeit ,
			                       (go_ziel.transform.position.z - this.transform.position.z)*f_geschwindigkeit );
	}
	
	void FixedUpdate()
	{
		if(!b_treffer)
		{
			//Debug Hilfslinie zeichen
			Debug.DrawLine(this.transform.position, go_ziel.transform.position);
			
			//Position des Ziels:
	//		go_ziel.transform.position.x ;
				
			//Eigene Position:
	//		this.transform.position.x ;
			
			//Bewegungsrichtung berechnen:
			
			//Neuausrichtung zum Ziel:
//			this.transform.rotation.SetFromToRotation( this.transform.position, go_ziel.transform.position );
			
			//Bewegung:
			rigidbody.AddForce(v3_richtung);
		}
	}
	
	void OnTriggerEnter(Collider collision)
	{
		if( collision.gameObject.tag == "ziel" )
		{
			b_treffer = true;
			this.rigidbody.useGravity = true;
		}
	}
}
