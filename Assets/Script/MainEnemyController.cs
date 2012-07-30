using System;
using UnityEngine;


public class MainEnemyController : BaseController
{
	
	private PlayerAnimationInfo _info = null;
	void Start () 
	{	
		//get CharacterController component
		ccontroller = GetComponent<CharacterController>();
		
		//init event manager
		eventMgr = GetComponent<EventManager>();
		Debug.Log( eventMgr );
		if ( eventMgr == null )
		{
			Debug.LogError ( this.gameObject.name   + "cann't get some event manager ");
		}
		
		//init fight FightManager
		FightManager fmgr = GetComponent<FightManager>();
		if ( fmgr != null )
		{
			fmgr.init( this );
		}
		
		//create player animation info
		_info = new PlayerAnimationInfo( 1, true );
		_info.setAllHander(null, 
						   null, 
						   typeof(Idle), 
						   null, 
			  			   null, 
						   typeof(OtherAnimation));
		
		//get animation manager
		mgr = AnimationMgrFactory.getSingleton().getManager( this,  _info );
		Debug.Log( mgr );
		if ( mgr == null )
		{
			Debug.LogError (  this.gameObject.name  + "cann't get some AnimationManager ");
		}
		
		//state machine
		stateMachine = new StateMachine< BaseController >( this );
		Debug.Log( stateMachine );
		if ( stateMachine == null )
		{
			Debug.LogError ( this.gameObject.name   + "cann't get some StateMachine ");
		}
		else
		{
			stateMachine.setGlobalState( GlobalState.getInstance());
			stateMachine.setCurrentState( IdleState.getIntance() );
		}
		
		

		
		//weaponTrial.SetTime(0.0f, 0, 1);
		
		//weaponTrailAnimation = new WeaponTrailAnimation();
		//weaponTrailAnimation.weaponTrial = weaponTrial;
	}
	
	
 	override public void DirectionTurn()
	{
		
	}
	
	override public void Move( float x , float z )
	{
		
	}
	
	override public void Down()
	{
		
	}
	
	override public void Jump()
	{
		
	}
	
}


