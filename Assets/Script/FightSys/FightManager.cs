using UnityEngine;
using System.Collections;

public class FightManager : MonoBehaviour 
{
	private AttackManager _attackMgr = null;
	private DamageManager _demageMgr = null;
	
	
	private EventManager _eventMsg = null;
	
	// Use this for initialization
	void Start () 
	{
		_eventMsg = GetComponent<EventManager>();
		_attackMgr = new AttackManager( _eventMsg );
		_demageMgr = new DamageManager( _eventMsg );
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		_attackMgr.Update();
		_demageMgr.Update();
	}
	
	// Update 
	void OnMouseEnter ()
	{
		
	}

}
