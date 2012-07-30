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
		obj.eventMgr.AddListener( AnimationControllerEvent.EVENT_ANIMATION_FINISH, animationFinish );
		obj.mgr.enter("otherHandler");
	}
	
	override public void Execute( BaseController obj )
	{
		obj.mgr.update("otherHandler");
		
		/*
		bool isFinish = (bool)obj.mgr.getPlayerAnimationState("ANMIATIONSTATE_FINISH");
		if ( isFinish )
		{
			obj.stateMachine.changeState( IdleState.getIntance());
		}
		*/
	}
	
	override public void Exit( BaseController obj )
	{
		obj.mgr.exit("otherHandler");
	}	
	
	private void animationFinish( CommentEvent e )
	{
		if ( e == null ) return ;
		BaseController obj = (e as AnimationControllerEvent).getController();
		
		if ( obj != null )
		{
			obj.eventMgr.RemoveListener( AnimationControllerEvent.EVENT_ANIMATION_FINISH, animationFinish );
			obj.stateMachine.changeState( IdleState.getIntance());
		}
	}
		
}

