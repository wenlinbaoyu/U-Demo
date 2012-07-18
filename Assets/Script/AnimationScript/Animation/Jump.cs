using System;
using System.Collections;
using UnityEngine;

public class Jump : BaseAnimation
{
	enum JumpType
	{
		JUMP_BEGIN = 1,
		JUMP_UP    = 2,
		JUMP_DOWN  = 3,
		JUMP_FALL  = 4,
		JUMP_NULL  = 5,
	}
	
	private JumpType _curJumpType = JumpType.JUMP_NULL;
	private const float jumpspeed = 0.8f;

	//method of start
	
	override public void start( MonoBehaviour mono, PlayerAnimationInfo info )
	{
		base.start( mono,  info );
		
		_am[info.getAniamtionID("jump_begin")].wrapMode = WrapMode.Once;
		_am[info.getAniamtionID("jump_begin")].layer = AnimationLayer.NORMAL;
		_am[info.getAniamtionID("jump_begin")].weight = 100;
		
		_am[info.getAniamtionID("jump_up")].wrapMode = WrapMode.Once;
		_am[info.getAniamtionID("jump_up")].layer = AnimationLayer.NORMAL;
		_am[info.getAniamtionID("jump_up")].weight = 100;
		
		_am[info.getAniamtionID("jump_down")].wrapMode = WrapMode.ClampForever;
		_am[info.getAniamtionID("jump_down")].layer = AnimationLayer.NORMAL;
		_am[info.getAniamtionID("jump_down")].weight = 100;		
	
		_am[info.getAniamtionID("fall")].wrapMode = WrapMode.Once;
		_am[info.getAniamtionID("fall")].layer = AnimationLayer.NORMAL;
		_am[info.getAniamtionID("fall")].weight = 100;			
			
	}
	
	
	override public void enter()
	{
		_curJumpType = JumpType.JUMP_BEGIN;
		_am.Play( _info.getAniamtionID("jump_begin"));
		_mono.StartCoroutine( wait( animationTime() ) );
		_info.setAnimationState("ANMIATIONSTATE_JUMPTYPE", "jumpBegin");
	}
	
	//method of update
	override public void update()
	{
		bool isGround = (bool)_info.getAnimationState("ANMIATIONSTATE_ISGROUND");
		if ( isGround && _curJumpType == JumpType.JUMP_DOWN )
		{
			EndAniamtion();
		}
	}
	
	//get animationclip time 
	override public float animationTime()
	{
		switch( _curJumpType )
		{
			case JumpType.JUMP_BEGIN:
			{
				return _am[_info.getAniamtionID("jump_begin")].length;
			}
			case JumpType.JUMP_UP:
			{
				return _am[_info.getAniamtionID("jump_up")].length;
			}
			case JumpType.JUMP_DOWN:
			{
				return _am[_info.getAniamtionID("jump_down")].length;
			}
			case JumpType.JUMP_FALL:
			{
				return _am[_info.getAniamtionID("fall")].length;
			}
			default:
			{
				return 0.0f;
			}
		} 
	}
	
	private IEnumerator wait( float second )
	{
		yield return new WaitForSeconds( second );
		
		EndAniamtion();
	}
	
	private void EndAniamtion( )
	{ 
		switch( _curJumpType )
		{
			case JumpType.JUMP_BEGIN:
			{
				//controller.Jump();
				_curJumpType = JumpType.JUMP_UP;
			
				_info.setAnimationState("ANMIATIONSTATE_JUMPTYPE", "jumpUp");
				_am.Play( _info.getAniamtionID("jump_up"));
				_mono.StartCoroutine( wait( animationTime()));
				break;
			}
			case JumpType.JUMP_UP:
			{
				_curJumpType = JumpType.JUMP_DOWN;
				_info.setAnimationState("ANMIATIONSTATE_JUMPTYPE", "jumpDown");
				_am.Play( _info.getAniamtionID("jump_down"));
				break;
			}
			case JumpType.JUMP_DOWN:
			{
				_curJumpType = JumpType.JUMP_FALL;
				_am.Play( _info.getAniamtionID("fall"));
				_info.setAnimationState("ANMIATIONSTATE_JUMPTYPE", "jumpFall");
				_mono.StartCoroutine( wait( animationTime()));
				break;
			}
			case JumpType.JUMP_FALL:
			{
				_curJumpType = JumpType.JUMP_NULL;
				_info.setAnimationState("ANMIATIONSTATE_JUMPTYPE", "jumpNull");
				break;
			}
			default:
			{
				break;
			}
		} 
	}	
	
}
