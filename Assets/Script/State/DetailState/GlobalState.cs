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
		EventManager mgr = obj.eventMgr;
		
		//regist be hit listener
		mgr.AddListener( EventManager.EVENT_BE_HIT, beHitHandler );
		mgr.AddListener( EventManager.EVENT_DEAD , deadHandler );
	}
	
	override public void Execute( BaseController obj )
	{
		obj.Down();	
	}
	
	override public void Exit( BaseController obj )
	{
		
	}
	
	private void beHitHandler( CommentEvent e )
	{
		if ( e == null ) return;
		
		
		BaseController obj = ( e as AnimationControllerEvent ).getController();
		if ( obj != null )
		{
			obj.mgr.setPlayerAnimationState( "ANMIATIONSTATE_BEHIT", true );
			obj.stateMachine.changeState( OtherState.getIntance() );
		}
	}
	
	private void deadHandler( CommentEvent e ) 
	{
		if ( e == null ) return;
		
		BaseController obj = ( e as AnimationControllerEvent ).getController();
		if ( obj != null )
		{
			obj.mgr.setPlayerAnimationState( "ANMIATIONSTATE_DEAD", true );
			obj.stateMachine.changeState( OtherState.getIntance() );
		}
	}
}

