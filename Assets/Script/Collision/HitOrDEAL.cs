using UnityEngine;
using System.Collections;

public class HitOrDEAL : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnTriggerEnter ( Collider collider )
	{
		Debug.Log("test player OnTriggerEnter ");
		animation["1013"].wrapMode =WrapMode.Once;
		animation.Play("1013");
	}		

	void OnTriggerExit ( Collider collider )
	{
		Debug.Log("test player OnTriggerExit ");
	}	
	
	void OnTriggerStay ( Collider collider )
	{		
	}
}
