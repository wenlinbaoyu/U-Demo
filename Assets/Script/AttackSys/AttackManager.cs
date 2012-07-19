using UnityEngine;
using System.Collections;

public class AttackManager : MonoBehaviour 
{
	
	EventManager _eventMsg = null;
	
	// Use this for initialization
	void Start () 
	{
		_eventMsg = GetComponent<EventManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
