using UnityEngine;

public class Stangengenerator : MonoBehaviour
{
	//Einzelteile der Schwerter
	public Transform[] kopf;
	public Transform[] stiel;
	
	//Variable zum multiblem erstellen
	public static uint anzahl;

	void Start()
	{
		//Alle unterelemente durchgehen
		foreach(Transform t in transform)
		{
			//Debug.Log(t.name);
			if(t.name.Equals("pos_kopf") )
			{
				Object o = Instantiate(kopf[Random.Range(0,kopf.Length)], t.position, Quaternion.identity);
				GameObject go = GameObject.Find(o.name);
				go.name = go.name.ToUpper();
				go.transform.parent = t.transform;
				go.renderer.material.color = new Color(Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F));
			}
			else if(t.name.Equals("pos_stiel") )
			{
				Object o = Instantiate(stiel[Random.Range(0,stiel.Length)], t.position, Quaternion.identity);
				GameObject go = GameObject.Find(o.name);
				go.name = go.name.ToUpper();
				go.transform.parent = t.transform;
				go.renderer.material.color = new Color(Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F));
			}
		}
		
		anzahl++;
		
		this.gameObject.AddComponent("PolygoneCounter");
		
		//Debug.Log(anzahl);
		
		name = "Stange"+anzahl;
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

