using System;
using System.Collections;
using System.Collections.Generic;

public class CommentEvent
{
	private string _eventType = "";
	private Hashtable _args ;
	
	public CommentEvent ( string type )
	{
		_eventType = type;
	}
	
	public string eventType
	{
		get
		{
			return _eventType;
		}
	}
	
	public void setArgs( string argname, object o )
	{
		if ( _args == null )
		{
			_args = new Hashtable ();
		}
		
		_args.Add( argname, o );
	}
}

