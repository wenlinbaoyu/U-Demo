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
	
	virtual public void Enter( MainPlayerController obj )
	{
		obj.mgr.play("attack");
		obj.mgr.setPlayerAnimationState("attackNum", 1);
		obj.StartCoroutine( wait( obj.mgr.getAniamtionLength("attack")+0.3f, obj));
	}
	
	virtual public void Execute( MainPlayerController obj )
	{
		int number = obj.mgr.getPlayerAnimationState("attackNum");
		if ( number == 1 )
		{
			obj.mgr.setPlayerAnimationState("attackNum", 2);
		}
		
		obj.Move(0, 0);
	}
	
	virtual public void Exit( MainPlayerController obj )
	{
		
	}
	
	
	private IEnumerator wait( float second, object obj )
	{
		yield return new WaitForSeconds( second );
		NextHit( obj );
	}
	
	private void NextHit( object obj )
	{
		MainPlayerController controller = obj as MainPlayerController;
		if ( controller != null )
		{
			int number = controller.mgr.getPlayerAnimationState("attackNum");
			if ( number == 1)
			{
				
			}
		}
	}
}

