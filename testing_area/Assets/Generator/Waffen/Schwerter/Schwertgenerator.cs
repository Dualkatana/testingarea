using UnityEngine;

public class Schwertgenerator : MonoBehaviour
{
	//Einzelteile der Schwerter
	public Transform[] klingen;
	public Transform[] parierstangen;
	public Transform[] griffe;
	
	//Variable zum multiblem erstellen
	public static uint anzahl;
	
	void Start()
	{
		//Alle unterelemente durchgehen
		foreach(Transform t in transform)
		{
			//Debug.Log(t.name);
			if(t.name.Equals("pos_klinge") )
			{
				Object o = Instantiate(klingen[Random.Range(0,klingen.Length)], t.position, Quaternion.identity);
				GameObject go = GameObject.Find(o.name);
				go.name = go.name.ToUpper();
				go.transform.parent = t.transform;
				go.renderer.material.color = new Color(Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F));
			}
			else if(t.name.Equals("pos_parierstange"))
			{
				Object o = Instantiate(parierstangen[Random.Range(0,parierstangen.Length)], t.position, Quaternion.identity);
				GameObject go = GameObject.Find(o.name);
				go.name = go.name.ToUpper();
				go.transform.parent = t.transform;
				go.renderer.material.color = new Color(Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F));
			}
			else if(t.name.Equals("pos_griff"))
			{
				Object o = Instantiate(griffe[Random.Range(0,klingen.Length)], t.position, Quaternion.identity);
				GameObject go = GameObject.Find(o.name);
				go.name = go.name.ToUpper();
				go.transform.parent = t.transform;
				go.renderer.material.color = new Color(Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F));
			}
		}
		anzahl++;
		
		this.gameObject.AddComponent("PolygoneCounter");
		
		//Debug.Log(anzahl);
		
		name = "Schwert"+anzahl;
		
		//Destroy(this,5.0F);
	}
	
	void OnCollisionEnter()
	{
		 //Destroy(gameObject, 20);
	}
	
	void OnDestroy()
	{
        anzahl--;
    }
}

