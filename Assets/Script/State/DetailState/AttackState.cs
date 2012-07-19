using System;
using System.Collections;
using UnityEngine;

public class AttackState : State< BaseController >
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
	
	override public void Enter( BaseController obj )
	{
		obj.mgr.enter("attackHandler");
		
	}
	
	override public void Execute( BaseController obj )
	{
		obj.mgr.update("attackHandler");
		
		bool isFinish = (bool)obj.mgr.getPlayerAnimationState("ANMIATIONSTATE_FINISH");
		if ( isFinish )
		{
			obj.stateMachine.changeState( IdleState.getIntance());
		}
	}
	
	override public void Exit( BaseController obj )
	{
		obj.mgr.exit("attackHandler");
	}
}

