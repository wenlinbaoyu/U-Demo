using UnityEngine;
using System.Collections;

public class test1Collision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter ( Collider collider )
	{
		Debug.Log("test player !!!! OnTriggerEnter ");
		Debug.Log("---------------------------");
		Debug.Log("name : " + collider.name );
	}		

	void OnTriggerExit ( Collider collider )
	{
		Debug.Log("test player!!!! OnTriggerExit ");
	}	
	
	void OnTriggerStay ( Collider collider )
	{
		Debug.Log("test player!!!!  OnTriggerStay ");
	}	
}
