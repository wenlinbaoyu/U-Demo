using System;


public class AIDManager : Singleton< AIDManager >
{
	public AIDManager ()
	{
	}
	
	
	//get a AID
	//
	public AID getAID( int playerTypeID , string animationType )
	{
		if ( animationType == "idle")
		{
			return new AID("idle");
		}
		else if( animationType == "run" )
		{
			return new AID("run");
		}
		else if( animationType == "jump" )
		{
			return new AID("jump");
		}
		else if( animationType == "attack" )
		{
			return new AID("attack");
		}
		
		return null;
	}
}

