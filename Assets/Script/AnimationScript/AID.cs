using System;
using System.Collections.Generic;

public class AID
{
	private string _id;
	private Hashtable _args;
	
	public AID( string id )
	{
		this._id = id;
	}
	
	public string id
	{
		get
		{
			return _id;
		}
	}
	
	public object getObject( string index )
	{
		return _args[index];
	}
	
	
	public Array getArray( string index )
	{
		return getObject( index ) as Array;
	}
	
	public void setArgs( string index, object arg )
	{
		if ( _args == null )
		{
			_args = new Hashtable();
		}
		_args.Add( name, arg );
	}
}


