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
		
		animation.Stop("1013");
		animation["1013"].wrapMode =WrapMode.Once;
		animation.Play("1013");
		
		

		Debug.Log("name :" + collider.name );
		Transform obj = collider.transform.parent;
		while( obj != null )
		{
			Debug.Log("name :" + obj.name );
			obj = obj.parent;
		}
	}		
	
	
	void OnTriggerStay ( Collider collider )
	{		
	}
}
