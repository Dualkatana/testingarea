using UnityEngine;

public class Bogengenerator : MonoBehaviour
{
	//Einzelteile der Schwerter
	public Transform[] sehnen;
	public Transform[] spannhoelzer;
	public Transform[] griffe;
	
	//Variable zum multiblem erstellen
	public static uint anzahl;
	
	void Start()
	{
		//Alle unterelemente durchgehen
		foreach(Transform t in transform)
		{
			//Debug.Log(t.name);
			if(t.name.Equals("pos_sehne") )
			{
				Object o = Instantiate(sehnen[Random.Range(0,sehnen.Length)], t.position, Quaternion.identity);
				GameObject go = GameObject.Find(o.name);
				go.name = go.name.ToUpper();
				go.transform.parent = t.transform;
				go.renderer.material.color = new Color(Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F));
			}
			else if(t.name.Equals("pos_spannholz"))
			{
				Object o = Instantiate(spannhoelzer[Random.Range(0,spannhoelzer.Length)], t.position, Quaternion.identity);
				GameObject go = GameObject.Find(o.name);
				go.name = go.name.ToUpper();
				go.transform.parent = t.transform;
				go.renderer.material.color = new Color(Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F));
			}
			else if(t.name.Equals("pos_griff"))
			{
				Object o = Instantiate(griffe[Random.Range(0,griffe.Length)], t.position, Quaternion.identity);
				GameObject go = GameObject.Find(o.name);
				go.name = go.name.ToUpper();
				go.transform.parent = t.transform;
				go.renderer.material.color = new Color(Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F));
			}
		}
		anzahl++;
		
		this.gameObject.AddComponent("PolygoneCounter");
		
		//Debug.Log(anzahl);
		
		name = "Bogen"+anzahl;
	}
		
	void OnCollisionEnter()
	{
		 Destroy(gameObject, 5);
	}
	
	void OnDestroy()
	{
        anzahl--;
    }
}

