using System;


public class OtherState : State<BaseController>
{
	public static OtherState intance = null;
	public static OtherState getIntance()
	{
		if ( intance == null )
		{
			intance = new OtherState();
		}
		return intance;
	}	
	
	private OtherState (){}
	
	override public void Enter( BaseController obj )
	{
		obj.mgr.enter("otherHandler");
	}
	
	override public void Execute( BaseController obj )
	{
		obj.mgr.update("otherHandler");
		
		bool isFinish = (bool)obj.mgr.getPlayerAnimationState("ANMIATIONSTATE_FINISH");
		if ( isFinish )
		{
			obj.stateMachine.changeState( IdleState.getIntance());
		}
	}
	
	override public void Exit( BaseController obj )
	{
		obj.mgr.exit("otherHandler");
	}	
}

