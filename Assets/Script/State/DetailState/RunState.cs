using System;
using UnityEngine;

public class RunState : State< MainPlayerController >
{
	private bool isTab = false;
	public static RunState intance = null;
	public static RunState getIntance()
	{
		if ( intance == null )
		{
			intance = new RunState();
		}
		return intance;
	}
	
	private RunState (){}
	override public void Enter( MainPlayerController obj )
	{
		obj.mgr.enter("runHandler");
	}
	
	override public void Execute( MainPlayerController obj )
	{
		if ( Input.GetKeyDown( KeyCode.Space))
		{
			obj.stateMachine.changeState( JumpState.getIntance());
		}
		else if ( Input.GetButtonDown("Fire1"))
		{
			obj.stateMachine.changeState( AttackState.getIntance());
		}
		else if ( Input.GetButton("Vertical") || Input.GetButton("Horizontal") )
		{
			obj.DirectionTurn();
			
			if ( Input.GetButton("Horizontal") )
				obj.Move( 0.0f, Mathf.Abs( Input.GetAxis("Horizontal")));
			else
				obj.Move( 0.0f, Mathf.Abs( Input.GetAxis("Vertical")));
		}
		else
		{
			obj.stateMachine.changeState( IdleState.getIntance());
		}
	}
	
	override public void Exit( MainPlayerController obj )
	{
		
	}
}


