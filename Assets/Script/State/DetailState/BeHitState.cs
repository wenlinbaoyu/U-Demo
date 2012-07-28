using System;


public class BeHitState : State< BaseController >
{
	public static BeHitState intance = null;
	public static BeHitState getIntance()
	{
		if ( intance == null )
		{
			intance = new BeHitState();
		}
		return intance;
	}
	
	private BeHitState (){}	
	
	override public void Enter( BaseController obj )
	{
		
	}
	
	override public void Execute( BaseController obj )
	{
		
	}
	
	override public void Exit( BaseController obj )
	{
		
	}
}

