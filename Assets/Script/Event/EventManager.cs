using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
	//evnet name 
	//进行攻击
	public const string EVENT_ATTACK = "EVENT_ATTACK";
	public const string EVENT_STOP_ATTACK = "EVENT_STOP_ATTACK";
	public const string EVENT_BE_HIT = "EVENT_BE_HIT";
	public const string EVENT_DEAD   = "EVENT_DEAD";
	
	private EventDispather _dipather = null;	
	
	void Awake()
	{
		_dipather = new EventDispather();
	}
	
	public void AddListener(string eventType, Callback handler)
	{
		if ( _dipather != null )
		{
			_dipather.AddListener( eventType, handler );
		}
	}
		
	public void RemoveListener(string eventType, Callback handler)
	{
		if ( _dipather != null )
		{
			_dipather.RemoveListener( eventType, handler );
		}
	}
	
	public void Broadcast(string eventType)
	{
		if ( _dipather != null )
		{
			_dipather.Broadcast( eventType );
		}
	}
	
	public void Broadcast(string eventType, MessengerMode mode)
	{
		if ( _dipather != null )
		{
			_dipather.Broadcast( eventType, mode );
		}
	}
}

