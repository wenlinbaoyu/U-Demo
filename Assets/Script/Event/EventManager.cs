using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
	//evnet name 
	//进行攻击
	public const string EVENT_ATTACK = "EVENT_ATTACK";
	
	
	
	private EventDispather _dipather = null;	
	void Start()
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

