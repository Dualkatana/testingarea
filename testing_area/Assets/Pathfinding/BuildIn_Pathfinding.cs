using UnityEngine;
using System.Collections;

public class BuildIn_Pathfinding : MonoBehaviour
{
	public Transform target;
	
	private NavMeshAgent nav;
	
	void Start()
	{
		nav = gameObject.GetComponent<NavMeshAgent>();
	}
	
	void Update()
	{
		nav.destination = target.position;
	}
}
