using UnityEngine;
using System.Collections;

public class DamageManager 
{
	private EventManager _eventMsg = null;
	
	private RoleStatus _status = null;
	
	// Use this for initialization
	public DamageManager ( EventManager mgr, RoleStatus status )
	{
		_eventMsg = mgr;
		_status   = status;
	}
	
	// Update is called once per frame
	public void Update () {}
	
	
	//apply Managers
	public void applyDamage( )
	{
		_status.curHP -= 10;
		Debug.Log( "Hit role hp " + _status.curHP );
	}
}
