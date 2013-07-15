using UnityEngine;
using System.Collections;

public class LookAtTarget : MonoBehaviour
{
	public Transform target;
	public float speed;
	
	void Start()
	{
	
	}
	
	void Update()
	{
		//instand
//		transform.rotation = Quaternion.LookRotation( target.position - transform.position);

		//smoth (interpolieren mit zwischenschritten)
		transform.rotation = Quaternion.Slerp( transform.rotation, Quaternion.LookRotation( target.position - transform.position), speed*Time.deltaTime);
		
		//noch smother (nach drehgeschwindigkeit)
//		transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(target.position - transform.position), speed*Time.deltaTime);
	}
}
