using System;
using UnityEngine;

public class IdleState : State< BaseController >
{
	public static IdleState intance = null;
	public static IdleState getIntance()
	{
		if ( intance == null )
		{
			intance = new IdleState();
		}
		return intance;
	}
	
	
	private IdleState (){}
	
	override public void Enter( BaseController obj )
	{
		obj.mgr.enter("idleHandler");
	}
	
	override public void Execute( BaseController obj )
	{
		if ( Input.anyKey )
		{
			if ( Input.GetButton("Vertical") || Input.GetButton("Horizontal") )
			{
				obj.stateMachine.changeState( RunState.getIntance() );
			}
			else if ( Input.GetKeyDown( KeyCode.Space ))
			{
				obj.stateMachine.changeState( JumpState.getIntance() );
			}
			else if ( Input.GetButtonDown("Fire1"))
			{
				obj.stateMachine.changeState( AttackState.getIntance());
			}
			else
			{
				obj.stateMachine.changeState( OtherState.getIntance());
			}
		}

	}
	
	override public void Exit( BaseController obj )
	{
		
	}
	
}

