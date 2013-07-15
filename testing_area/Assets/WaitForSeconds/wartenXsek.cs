using UnityEngine;
using System.Collections;

public class wartenXsek : MonoBehaviour
{
	public bool warte;
	public int sekunden;
	
	void Start ()
	{
		
	}

	IEnumerator warten()
	{
		warte = false;
		yield return new WaitForSeconds(sekunden);
		warte = true;
		print(Time.time);
	}
	
	void Update ()
	{
		if( warte )
			StartCoroutine( warten() );
	}
}