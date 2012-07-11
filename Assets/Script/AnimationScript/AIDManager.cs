using System;


public class AIDManager : Singleton< AIDManager >
{
	public AIDManager ()
	{
	}
	
	
	//get a AID
	//
	public AID getAID( int playerTypeID , string animationType, object prama )
	{
		if ( animationType == "idle")
		{
			return null;//new AID("idle");
		}
		else if( animationType == "run" )
		{
			AID aid = new AID( "jump" );
			bool tab = (bool)prama;
			if ( tab )
				aid.setArgs("subanimationNumber", new string[]{"1008"}); 
			else
				aid.setArgs("subanimationNumber", new string[]{"1003"}); 
			return aid;
		}
		else if( animationType == "jump" )
		{
			AID aid = new AID( "jump" );
			aid.setArgs("subanimationNumber", new string []{"1019", "1020", "1021", "1022"});
			aid.setArgs("subSendEvent",   	  new string []{"Jumb_Begin", "", "", ""});
			aid.setArgs("subListenEvent",     new string []{"", "", "People_InGround", ""});
			aid.setArgs("subAnimationLayer",  new int []{AnimationLayer.NORMAL, AnimationLayer.NORMAL, AnimationLayer.NORMAL, AnimationLayer.NORMAL});
			aid.setArgs("subListenFlag", 	  new bool[]{false, false, true, false});
			return aid;
		}
		else if( animationType == "shoujian" )
		{
			AID aid = new AID( "shoujian" );
			aid.setArgs("subanimationNumber", new string []{"1011"});
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
			aid.setArgs("subanimationNumber", new string []{"1015"});			
			return aid;
		}
		else if ( animationType == "attack_2")
		{
			AID aid = new AID( "attack" );
			aid.setArgs("subanimationNumber", new string []{"1016"});			
			return aid;
		}
		return null;
	}
}

