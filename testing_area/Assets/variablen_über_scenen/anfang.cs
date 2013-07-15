using UnityEngine;
using System.Collections;


public class anfang : MonoBehaviour
{
    void Awake()
	{
        DontDestroyOnLoad(GameObject.Find("GameObject2save"));
    }
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Application.LoadLevel(1);	
		}
	}
}