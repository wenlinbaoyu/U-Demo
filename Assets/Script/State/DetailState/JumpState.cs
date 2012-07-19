using System.Collections;
using UnityEngine;

public class JumpState : State< BaseController >
{
	public static JumpState intance = null;
	public static JumpState getIntance()
	{
		if ( intance == null )
		{
			intance = new JumpState();
		}
		return intance;
	}
	
	private JumpState () {}
	
	private float jumpspeed = 0.8f;
	override public void Enter( BaseController obj )
	{
		obj.mgr.enter("jumpHandler");
	}
	
	override public void Execute( BaseController obj )
	{	
		string jumpstate = (string)obj.mgr.getPlayerAnimationState("ANMIATIONSTATE_JUMPTYPE");
		
		obj.mgr.setPlayerAnimationState("ANMIATIONSTATE_ISGROUND", obj.ccontroller.isGrounded);
		obj.mgr.update("jumpHandler");
		
		if ( (Input.GetButton("Vertical") || Input.GetButton("Horizontal")) && jumpstate != "jumpBegin" && jumpstate != "jumpFall" )
		{
			if ( Input.GetButton("Horizontal") )
				obj.Move( 0.0f, Mathf.Abs(Input.GetAxis("Horizontal")) * jumpspeed);
			else
				obj.Move( 0.0f, Mathf.Abs(Input.GetAxis("Vertical")) * jumpspeed);
		}
		else
		{
			obj.Move(0.0f, 0.0f);
		}
		
		if ( obj.ccontroller.isGrounded && jumpstate == "jumpUp")
		{
			obj.Jump();
		}
		else if ( obj.ccontroller.isGrounded && jumpstate == "jumpNull" )
		{
			obj.stateMachine.changeState( IdleState.getIntance());
		}
	}
	
	override public void Exit( BaseController obj )
	{
		obj.mgr.exit("jumpHandler");
	}
}
