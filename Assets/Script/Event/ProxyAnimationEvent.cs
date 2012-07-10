using UnityEngine;
using System.Collections;

public class ProxyAnimationEvent : MonoBehaviour
{
	public delegate void EventHandler();
	private static Hashtable _eventTable;

	public static AnimationEvent getAmimationEvent( string handler_name, EventHandler handler )
	{
 		if ( _eventTable == null )
		{
			_eventTable = new Hashtable();
			_eventTable.Add( handler_name, new EventHandler( handler ) );
		}
		else
		{
			EventHandler tmp = _eventTable[ handler_name ] as EventHandler;
			if ( tmp != null)
			{
				tmp += handler;
			}
			else
			{
				tmp = new EventHandler( handler );
				_eventTable.Add( handler_name, tmp );
			}
		}
		
		AnimationEvent e = new AnimationEvent();
		e.functionName = "callback";
		e.stringParameter = handler_name;
		return e;
	}
	
	private void callback( string param )
	{
		EventHandler tmp = _eventTable[ param ] as EventHandler;
		if ( tmp != null )
		{
			tmp();
		}
		
		_eventTable.Remove( param );
	}
}

