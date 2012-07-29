using System;
using System.Collections;
using System.Collections.Generic;

public class CommentEvent
{
	private string _eventType = "";
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
}

