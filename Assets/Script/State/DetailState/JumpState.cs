using System.Collections;
using UnityEngine;

public class JumpState : State< MainPlayerController >
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
	private const float jumpspeed = 0.8f;
	override public void Enter( MainPlayerController obj )
	{
		obj.mgr.play("jump_begin", false);
		obj.mgr.setPlayerAnimationState("jumpState", JumpType.JUMP_BEGIN);
		obj.StartCoroutine( wait( obj.mgr.getAniamtionLength("jump_begin"), obj) );
	}
	
	override public void Execute( MainPlayerController obj )
	{
		int type = (int)obj.mgr.getPlayerAnimationState("jumpState");
		
		if ( (Input.GetButton("Vertical") || Input.GetButton("Horizontal")) && 
			type != JumpType.JUMP_FALL && type != JumpType.JUMP_BEGIN )
		{
			if ( Input.GetButton("Horizontal") )
				obj.Move( 0.0f, Mathf.Abs(Input.GetAxis("Horizontal")) * jumpspeed);
			else
				obj.Move( 0.0f, Mathf.Abs(Input.GetAxis("Vertical")) * jumpspeed);
		}
		else
		{
			obj.Move(0, 0);
		}
		
		if ( obj.ccontroller.isGrounded && type == JumpType.JUMP_DOWN )
		{
			EndAniamtion( obj );
		}
	}
	
	override public void Exit( MainPlayerController obj )
	{
		obj.mgr.setPlayerAnimationState("jumpState", JumpType.JUMP_NULL);
	}
	
	
	private IEnumerator wait( float second, object obj )
	{
		yield return new WaitForSeconds( second );
		EndAniamtion( obj );
	}
	
	private void EndAniamtion( object obj  )
	{ 

		MainPlayerController controller = obj as MainPlayerController;
		int type = (int)controller.mgr.getPlayerAnimationState("jumpState");
		
		if ( type == JumpType.JUMP_BEGIN)
		{
			controller.Jump();
			controller.mgr.setPlayerAnimationState("jumpState", JumpType.JUMP_UP);
			controller.mgr.play( "jump_up", false );
			controller.StartCoroutine( wait( controller.mgr.getAniamtionLength("jump_up"), obj));
		}
		else if ( type == JumpType.JUMP_UP )
		{
			controller.mgr.play("jump_down", false);
			controller.mgr.setPlayerAnimationState("jumpState", JumpType.JUMP_DOWN);

		}
		else if ( type == JumpType.JUMP_DOWN )
		{
			controller.mgr.setPlayerAnimationState("jumpState", JumpType.JUMP_FALL);
			
			controller.mgr.play( "fall", false );
			controller.StartCoroutine( wait( controller.mgr.getAniamtionLength("fall"), obj));					
		}
		else if ( type == JumpType.JUMP_FALL )
		{
			controller.stateMachine.changeState( IdleState.getIntance() );	
		}
	}
}
