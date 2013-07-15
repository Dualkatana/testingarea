using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
	
public class Sys_steuerung : MonoBehaviour
{
	public float f_geschwindigkeit_gehen = 10.0F;
	public float f_geschwindigkeit_rennen = 20.0F;
	public float f_drehgeschwindigkeit = 2.0F;
	
	private float f_curSpeed;
	
	private bool b_warten;
//	private bool b_bewegt;
	
//	private util_ingameInfo v;
	
	public Transform PrefabStein;
	
	void Start()
	{
//		v = new util_ingameInfo("Script: Sys_steuerung 2.1 (WSAD, Pfeiltasten, linksAlt + Maus, linksShift + W)");
//		b_warten = true;
//		b_bewegt = false;
	}
	
	void OnGUI()
	{
//		v.anzeige();
	}
	
	void FixedUpdate()
	{
		CharacterController controller = GetComponent<CharacterController>();
		
		if( Input.GetKey(KeyCode.LeftAlt) )
		{
			//MausCurser ausblenden:
			Screen.showCursor = false;
			Screen.lockCursor = true;
			//Links/Rechts drehen mit Maus
			transform.Rotate(0, (Input.GetAxis("Mouse X")*f_drehgeschwindigkeit), 0);
			//Hoch/Runter mit der Maus
			float f_blick = Input.GetAxis("Mouse Y")*(-1) + Camera.mainCamera.transform.localEulerAngles.x;
			Camera.mainCamera.transform.localEulerAngles = new Vector3(f_blick,0,0);
		}
		else
		{
			//MausCurser einblenden:
			Screen.showCursor = true;
			Screen.lockCursor = false;
			if(Input.GetKey(KeyCode.A))
			{
				transform.Rotate( 0, f_drehgeschwindigkeit*(-1), 0);
			}
			else if(Input.GetKey(KeyCode.D))
			{
				transform.Rotate( 0, f_drehgeschwindigkeit, 0);
			}
//			transform.Rotate(0, Input.GetAxis("Horizontal")*f_drehgeschwindigkeit, 0);
		}
		
		Vector3 v3_richtung = transform.TransformDirection(Vector3.forward);
		
		if( (Input.GetKey(KeyCode.LeftShift)) && (Input.GetKey(KeyCode.W)) )
		{
			//Vorwärts Rennen
			f_curSpeed = f_geschwindigkeit_rennen;
		}
		else if( Input.GetKey(KeyCode.W) )
		{
			//Vorwärts/Rückwerts laufen
			f_curSpeed = f_geschwindigkeit_gehen;
		}
		else if( Input.GetKey(KeyCode.S) )
		{
			//Vorwärts/Rückwerts laufen
			f_curSpeed = f_geschwindigkeit_gehen*(-1);
		}
		else
		{
			f_curSpeed = 0;
		}
		
/*		if( Input.GetKey(KeyCode.W) )
		{
			if( (Input.GetKey(KeyCode.LeftShift))  )
			{
				//		Vorwärts Rennen
				Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z+f_geschwindigkeit_rennen);
				transform.position = pos;
			}
			else
			{
				//		Vorwärts laufen
				Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z+f_geschwindigkeit_gehen);
				transform.position = pos;
			}
		}
		else if( Input.GetKey(KeyCode.S) )
		{
			Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z+f_geschwindigkeit_gehen*(-1));
			transform.position = pos;
		}
*/

/*		if( (Input.GetKey(KeyCode.LeftShift)) && (Input.GetKey(KeyCode.W)) )
		{
			//Vorwärts Rennen
			f_curSpeed = f_geschwindigkeit_rennen * Input.GetAxis("Vertical");
		}
		else
		{
			//Vorwärts/Rückwerts laufen
			//f_curSpeed = f_geschwindigkeit_gehen * Input.GetAxis("Vertical");
			Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z+f_geschwindigkeit_gehen);
			transform.position = pos;
		}
*/
				
		//Wurde eine Bewegung ausgeführt?
//		if( Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) )
//			b_bewegt = true;
		
		//Bewegung umsetzen
		controller.SimpleMove(v3_richtung * f_curSpeed);
		
		//Wartefunktion (Grund: nur alle x Sek bewegungsdaten senden)
//		if( b_warten )
//			StartCoroutine( warten(1) );
	}
	
/*	void LateUpdate()
	{
		Sys_Verbindung.verbindung.bewegung( transform.position.x, transform.position.y, transform.position.z, 0.0F );
	}*/
	
/*	public IEnumerator warten( int i_sekunden )
	{
		b_warten = false;
		yield return new WaitForSeconds(i_sekunden);
		if(b_bewegt)
		{
			Sys_verbindung.verbindung.bewegung( Sys_verbindung.ID, transform.position.x, transform.position.y, transform.position.z, 0.00F );
			b_bewegt = false;
			//Debug.Log("Bewegungsdaten gesendet");
			//Blickrichtung: Rotation Y
			//Debug.Log( "Vektor Rotation: "+transform.localRotation.eulerAngles );
			//v.zusatzinfo( "bewegung gesendet: "+transform.position.ToString() );
		}
		b_warten = true;
	}
*/
}