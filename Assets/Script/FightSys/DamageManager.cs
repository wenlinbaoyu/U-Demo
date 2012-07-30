using UnityEngine;
using System.Collections;

public class DamageManager 
{
	private EventManager _eventMsg = null;
	
	private RoleStatus _status = null;
	private BaseController _controller = null;
	// Use this for initialization
	public DamageManager ( EventManager mgr, RoleStatus status, BaseController controller )
	{
		_eventMsg = mgr;
		_status   = status;
		_controller = controller;
	}
	
	// Update is called once per frame
	public void Update () {}
	
	
	//apply Managers
	public void applyDamage( )
	{
		//_status.curHP -= 10;
		
		Debug.Log(_eventMsg);
		_status.AddjustCurrentHP( -10 );
		if ( _status.curHP > 0 )
		{
			_eventMsg.Broadcast( new AnimationControllerEvent( AnimationControllerEvent.EVENT_BE_HIT, _controller ));
		}
		else
		{
			_eventMsg.Broadcast( new AnimationControllerEvent( AnimationControllerEvent.EVENT_DEAD, _controller ));
		}
		
		Debug.Log( "Hit role hp " + _status.curHP );
	}
}
