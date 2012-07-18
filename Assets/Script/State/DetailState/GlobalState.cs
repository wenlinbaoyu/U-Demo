using System;


public class GlobalState : State<MainPlayerController>
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
	
	override public void Enter( MainPlayerController obj )
	{
		
	}
	
	override public void Execute( MainPlayerController obj )
	{
		obj.Down();	
	}
	
	override public void Exit( MainPlayerController obj )
	{
		
	}	
}

