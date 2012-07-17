using System;
using UnityEngine;

public class IdleState : State< MainPlayerController >
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
	
	override public void Enter( MainPlayerController obj )
	{
		obj.mgr.play("idle", true);
	}
	
	override public void Execute( MainPlayerController obj )
	{
		if ( Input.GetButton("Vertical") || Input.GetButton("Horizontal") )
		{
			obj.stateMachine.changeState( RunState.getIntance() );
		}
		else if ( Input.GetKeyDown( KeyCode.Space ))
		{
			obj.stateMachine.changeState( JumpState.getIntance() );
		}
	}
	
	override public void Exit( MainPlayerController obj )
	{
		
	}
	
}

