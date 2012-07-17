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
	
	
	private Transform _transform = null;
	private CharacterController _controller = null;
	
	override public void Enter( MainPlayerController obj )
	{
		isTab = (bool)obj.mgr.getPlayerAnimationState("isTab");
		if ( isTab )
			obj.mgr.play("run_tab", true);
		else
			obj.mgr.play("run", true);
		
		
		_transform = obj.gameObject.transform;
		_controller = obj.ccontroller;
	}
	
	override public void Execute( MainPlayerController obj )
	{
		if ( Input.GetKeyDown( KeyCode.Space))
		{
			obj.stateMachine.changeState( JumpState.getIntance());
		}
		else if ( Input.GetButtonDown("Fire1"))
		{
			//转换攻击状态
			int g = 1;
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
	
	private void swap( ref float num1, ref float num2 )
	{
		float temp = num1;
		num2 = num1;
		num1 = temp;	
	}
	
	private float ClampAngle( float angle , float min , float max ) 
	{
		if (angle < -360)	angle += 360;
		if (angle > 360) 	angle -= 360;
		return Mathf.Clamp (angle, min, max);
	}	
	
}


