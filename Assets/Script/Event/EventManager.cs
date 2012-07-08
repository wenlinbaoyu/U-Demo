using System;
using System.Collections;
using System.Collections.Generic;

public class EventManager : Singleton< EventManager >
{
	public delegate void EventHandler( CommentEvent e );
	private Hashtable _eventTable; 
	private List<CommentEvent> _msgList;
			
	public EventManager ()
	{
		_eventTable = new Hashtable();
		_msgList = new List<CommentEvent>();
	}
	
	public void addEventListener( string eType,  EventHandler func )
	{
		if ( _eventTable != null )
		{
			EventHandler handler = _eventTable[eType] as EventHandler;
			if ( handler == null)
			{
				handler = new EventHandler( func );
				_eventTable.Add( eType, func );
			}
			else
			{
				handler += func;
			}
		}
	}
	
	public void removeEventListener( string eType, EventHandler func )
	{
		if ( _eventTable != null )
		{
			EventHandler handler = _eventTable[eType] as EventHandler;
			if ( handler == null )
			{
				return;
			}
			else
			{
				handler -= func;
			}
		}
	}
	
	
	public void sendMsg( string eType )
	{
		CommentEvent e = new CommentEvent( eType );
		sendMsg ( e );
	}
	
	
	public void sendMsg( CommentEvent e )
	{
		_msgList.Add( e );
	}
	
	public void Update()
	{
		if ( _msgList.Count > 0)
		{
			for ( int i = 0 ; i < _msgList.Count ; i ++ )
			{
				CommentEvent e = _msgList[ i ] as CommentEvent;
				EventHandler handler = _eventTable[e.eventType] as EventHandler;
				if ( handler != null )
				{
					handler( e );
				}
			}
		}
		//clear event list
		_msgList.Clear();
	}
	
	/*
	public void	FiexUpdate()
	{
		
	}
	*/
}

