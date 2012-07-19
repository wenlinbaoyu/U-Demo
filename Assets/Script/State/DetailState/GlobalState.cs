using System;


public class GlobalState : State<BaseController>
{
	private static GlobalState _instance = null;
	public static GlobalState getInstance()
	{
		if ( _instance == null )
		{
			_instance = new GlobalState();
		}
		return _instance;
	}
	
	private GlobalState (){}
	
	override public void Enter( BaseController obj )
	{
		
	}
	
	override public void Execute( BaseController obj )
	{
		obj.Down();	
	}
	
	override public void Exit( BaseController obj )
	{
		
	}	
}

