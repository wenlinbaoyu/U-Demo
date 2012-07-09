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
			AID aid = new AID( "jump" );
			aid.setArgs("subanimationNumber", new string []{"1019", "1020", "1021", "1022"});
			aid.setArgs("subSendEvent", new string []{"Jumb_Begin", "", "", ""});
			aid.setArgs("subListenEvent", new string []{"", "", "People_InGround", ""});
			return new AID("jump");
		}
		else if( animationType == "attack" )
		{
			return new AID("attack");
		}
		
		return null;
	}
}

