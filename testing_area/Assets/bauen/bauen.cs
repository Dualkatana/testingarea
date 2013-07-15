using UnityEngine;
using System.Collections;

public class bauen : MonoBehaviour
{
	//Einstellungen
	private float f_entfernung;
	private bool festmachenOK;
	private bool bDocking;
	
	//string für die interne anordnung der einzelnen Baugruppen
	private string strPhase;
	
	//Variable zum prüfen, ob dieses Script schon existiert
	public static bool exist;
	public Transform PrefabGebautesObjekt;

	//In Entwicklung
	private uint haltbarkeit;
	
	void Start()
	{
//		transform.parent = GameObject.Find("Player").transform;
		bDocking = false;
		f_entfernung = 20.0F;
		exist = true;
		//Unterteilung der einzelnen Baugphasen:
		//Vorbereitung der Z Position
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		//Phase_I:
		if( tag.Equals("Bauphase_I") )
		{
			strPhase = "Phase_I";
			haltbarkeit = 10;
			transform.position = new Vector3(transform.position.x, 0.125F, ray.GetPoint(f_entfernung).z);
			renderer.material.color = Color.green;
			festmachenOK = true;
		}
		else if( tag.Equals("Bauphase_II") )
		{
			haltbarkeit = 50;
			transform.position = new Vector3(transform.position.x, transform.position.y+transform.lossyScale.y, ray.GetPoint(f_entfernung).z);
			renderer.material.color = Color.red;
			festmachenOK = false;
		}
		else if( tag.Equals("Bauphase_III") )
		{
			haltbarkeit = 10;
			transform.position = new Vector3(transform.position.x, transform.position.y+transform.lossyScale.y, ray.GetPoint(f_entfernung).z);
			renderer.material.color = Color.red;
			festmachenOK = false;
		}
	
//		renderer.enabled = false;
	}
	
	void OnDestroy()
	{
		exist = false;
//		if( Sys_bauen.Haltbarkeitgesamt == 0)

		transform.parent = GameObject.Find(strPhase).transform;
		
		Sys_bauen.Haltbarkeitgesamt += haltbarkeit;
//		transform.parent = GameObject.Find("PrefGebautesObjekt").transform;
		gameObject.name = gameObject.name+"FEST";
	}
	
	void Update()
	{
		Ray ray;
//Entwicklungshilfe:
		if( Input.GetMouseButtonDown(0) )
			bDocking = false;
		
		/*				Unterteilung der einzelnen Steuerungen anhand der Baugruppe (Tags)				*/
		if(!bDocking)
		{
			if( tag.Equals("Bauphase_I") )
			{
				//Liene von "Camera" -> Mausposition
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				//Variable zum speichern des Treffers
				RaycastHit hit;
				//Wurde ein Colider getroffen? Treffer speichern in "hit"
		        if( Physics.Raycast(ray, out hit) )
				{
	//				Debug.DrawLine(ray.origin, hit.point); //Linie zeichnen
	//				Debug.Log("Entfernung: "+hit.distance); //Entfernung ausgeben
					//Position dieses Bauteils setzen
					Vector3 newPosition =  hit.point;
					//Dieses Bauteil ist 0.25F dick, also y 0.125F über 0
					newPosition.y = 0.125F;
					transform.position = newPosition;
				}
			}
			else
			{
				Debug.LogWarning("Steuerung dieses Bauteils nicht implementiert :"+tag);
			}

		}
		
		
//FUNKTIONSTÜCHTIG:
		/*				Mausrad abfrage			*/
/*		//Entfernung "Kamera" -> "Mauszeiger" einstellen:
		if( Input.GetAxis("Mouse ScrollWheel") != 0.0F ){
			transform.Translate(Vector3.forward * Time.deltaTime);
//			Vector3 newPos = GameObject.Find("Player").transform.TransformDirection(Vector3.forward);
//			newPos.z += Input.GetAxis("Mouse ScrollWheel");
			pos.z += Input.GetAxis("Mouse ScrollWheel");
			transform.position = pos;
		}
*/		

		/*		Bauteil an den Mauszeiger Positionieren:		*/
		//von der Camera zum Mouszeiger
//		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		//auf dieser linie bei 20.0F den Punkt
//		pos = ray.GetPoint(f_entfernung);
		
		//Unterteilung der einzelnen Baugphasen:
		//Phase_I:
		if( tag.Equals("Bauphase_I") )
//			pos.y = 0.125F;
		
//Maussteuerung
/*		if( Input.GetMouseButton(0) ){
			//Drehung ohne den Spieler
			// Bleibt bei der Rotation wie in der Welt -> Nur Position ändern
			
			//Position des Bauteils an diese Stelle setzen
			transform.position = pos;
			transform.parent = null;
			Debug.DrawRay(Camera.main.transform.position, pos-Camera.main.transform.position);
		}
		else if( Input.GetMouseButton(1) ){
			//Position des Bauteils an die Mausposition setzen
			transform.position = pos;
			//Bauteil an den Spieler klemmen


			Debug.DrawRay(Camera.main.transform.position, pos-Camera.main.transform.position);
		}
		else{
//			transform.parent = GameObject.Find("Player").transform;
		}
					
//Tastatursteuerung
		//Bauteil Links (Q)/Rechts (E) drehen
		if(Input.GetKey(KeyCode.Q)){
			transform.Rotate( 0, 0, 50*Time.deltaTime);
		}
		else if(Input.GetKey(KeyCode.E)){
			transform.Rotate( 0, 0, 50*Time.deltaTime*(-1));
		}
*/	
//"Anbauen": Position festmachen
		if( Input.GetKeyDown(KeyCode.Return) && festmachenOK ){	
			if( tag.Equals("Bauphase_I") )
				renderer.material.color = Color.blue;
			else
				renderer.material.color = Color.white;
			
			Destroy( GetComponent<bauen>() );
		}
		
		if( Input.GetKey(KeyCode.Delete) || Input.GetKey(KeyCode.Backspace) )
			Destroy(gameObject);
	
	}
	
	void OnGUI()
	{
		GUI.Label(new Rect(Screen.width/2-75, Screen.height/3-15, 150, 50), "Festmachen: <ENTER>\nLöschen: <DEL>");
	}
	
	void OnTriggerEnter(Collider collision)
	{
		/*		Überprüfen auf Docking		*/
		if( !bDocking )
		{
			if( tag.Equals("Bauphase_I") && collision.gameObject.tag.Equals("Bauphase_I") )
			{
				Debug.LogWarning("OnTriggerEnter: Mögliches Docking");
				Debug.LogWarning("Position des zu Dockenden Objektes: "+collision.transform.position.x+"|"+collision.transform.position.y+"|"+collision.transform.position.z);
				//Berechnung der Position
				Vector3 posDocking = transform.position;
				//Docking entlang der Z Achse
				if( (transform.position.z > (collision.transform.position.z-collision.transform.localScale.z)) && (transform.position.z < (collision.transform.position.z-collision.transform.localScale.z+5.0F)) )
				{
					Debug.LogError("Docking bei -Z");
					posDocking.x = collision.transform.position.x;
					posDocking.z = collision.transform.position.z-collision.transform.localScale.z;
				}
				else if( (transform.position.z < (collision.transform.position.z+collision.transform.localScale.z)) && (transform.position.z < (collision.transform.position.z+collision.transform.localScale.z*2-5.0F)) )
				{
					Debug.LogError("Docking bei +Z");
					posDocking.x = collision.transform.position.x;
					posDocking.z = collision.transform.position.z+collision.transform.localScale.z;
				}
				//Docking entlang der Y Achse
				bDocking = true;
				Debug.LogWarning("Docking bei:"+posDocking.x+"|"+posDocking.y+"|"+posDocking.z);
				transform.position = posDocking;
			}
		}
		
		/*		Überprüfen ob Bauteil an einem korektem Ort ist		*/
		if( tag.Equals("Bauphase_II") && collision.gameObject.tag.Equals("Bauphase_I") )
		{
			Debug.Log("OnCollisionEnter: Bauphase_II berührt Bauphase_I");
			renderer.material.color = Color.green;
			festmachenOK = true;
		}
		else if(tag.Equals("Bauphase_II") && collision.gameObject.tag.Equals("Bauphase_II") )
		{
			Debug.Log("OnCollisionEnter: Bauphase_II berührt Bauphase_II");
			renderer.material.color = Color.green;
			festmachenOK = true;
		}
		else if( tag.Equals("Bauphase_III") && collision.gameObject.tag.Equals("Bauphase_II"))
		{
			Debug.Log("OnCollisionEnter: Bauphase_III berührt Bauphase_II");
			renderer.material.color = Color.green;
			festmachenOK = true;
		}
	}
	
	void OnTriggerStay(Collider collision)
	{
/*		if( tag.Equals("Bauphase_II") && collision.gameObject.tag.Equals("Bauphase_I") )
		{
			Debug.Log("OnCollisionStay: Bauphase_II berührt Bauphase_I");
			renderer.material.color = Color.green;
		}
*/	}
	
	void OnTriggerExit(Collider collision)
	{
		if( tag.Equals("Bauphase_II") && ( collision.gameObject.tag.Equals("Bauphase_I") || collision.gameObject.tag.Equals("Bauphase_II") ) )
		{
			renderer.material.color = Color.red;
			festmachenOK = false;
		}
		else if( tag.Equals("Bauphase_III") && collision.gameObject.tag.Equals("Bauphase_II"))
		{
			renderer.material.color = Color.red;
			festmachenOK = false;
		}
	}
	
	
	
/*	void OnCollisionEnter(Collision collision)
	{

//		if( !Input.GetKey( KeyCode.Space) )
//			Destroy( GetComponent<Rigidbody>() );
//		renderer.material.color = Color.red;
	}
	
	void OnCollisionExit(Collision collision)
	{
//		renderer.material.color = Color.green;
	}
	
	void OnCollisionStay(Collision collision)
	{

    }*/
}
