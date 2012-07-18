using System;
using System.Collections;
using UnityEngine;

public class AttackState : State< MainPlayerController >
{
	
	public static AttackState intance = null;
	public static AttackState getIntance()
	{
		if ( intance == null )
		{
			intance = new AttackState();
		}
		return intance;
	}
	
	private AttackState (){}
	
	override public void Enter( MainPlayerController obj )
	{
		obj.mgr.enter("attackHandler");
		
	}
	
	override public void Execute( MainPlayerController obj )
	{
		obj.mgr.update("attackHandler");
		
		bool isFinish = (bool)obj.mgr.getPlayerAnimationState("ANMIATIONSTATE_FINISH");
		if ( isFinish )
		{
			obj.stateMachine.changeState( IdleState.getIntance());
		}
	}
	
	override public void Exit( MainPlayerController obj )
	{
		obj.mgr.exit("attackHandler");
	}
}

