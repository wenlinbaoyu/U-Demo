using UnityEngine;
using System.Collections;

public class EventCenter : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		//register event manager
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		EventManager.getSingleton().Update();
	}
}

