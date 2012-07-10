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
			aid.setArgs("subSendEvent",   new string []{"Jumb_Begin", "", "", ""});
			aid.setArgs("subListenEvent", new string []{"", "", "People_InGround", ""});
			aid.setArgs("subAnimationLayer", 
						new int []{AnimationLayer.NORMAL, AnimationLayer.NORMAL, AnimationLayer.NORMAL, AnimationLayer.NORMAL});
			return aid;
		}
		else if( animationType == "shoujian" )
		{
			AID aid = new AID( "shoujian" );
			aid.setArgs("subanimationNumber", new string []{"1011"});
			aid.setArgs("subAnimationLayer", new int []{AnimationLayer.NORMAL});
		
			return aid;
		}
		else if( animationType == "bajian")
		{
			AID aid = new AID( "bajian" );
			aid.setArgs("subanimationNumber", new string []{"1012"});
			return aid;
		}
		else if( animationType == "attack" )
		{
			AID aid = new AID( "attack" );
			aid.setArgs("subanimationNumber", new string []{"1017"});			
			return aid;
		}
		
		return null;
	}
}

