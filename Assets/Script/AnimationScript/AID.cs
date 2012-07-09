using System;
using System.Collections;

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
		if ( _args == null ) return null; 
		return  _args[ index ];
	}
	
	/*
	public int getInt( string index )
	{
		object arg = getObject( index );
		if ( arg is int )
		{
			return int(arg);
		}
		return 0;
	}
	
	public int getString( string index )
	{
		return getObject( index ) as string;
	}
	
	public float getFloat( string index )
	{
		return getObject( index ) as float;
	}
	*/
	
	public Array getArray( string index )
	{
		return getObject( index ) as Array;
	}
	
	
	public void setArgs( string name, object arg )
	{
		if ( _args == null )
		{
			_args = new Hashtable();
		}
		_args.Add( name, arg );
	}
}


