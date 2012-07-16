using System;
using UnityEngine;

public class Jump : BaseAnimation
{
	enum JumpState
	{
		JUMP_BEGIN = 1,
		JUMP_UP    = 2,
		JUMP_DOWN  = 3,
		JUMP_FALL  = 4,
	}
	
	
	private JumpState curJumpState = JumpState.JUMP_BEGIN;
	//method of start
	override public void start( Animation am , PlayerAnimationInfo info )
	{
		am[info.getAniamtionID("jump_begin")].wrapMode = WrapMode.Once;
		am[info.getAniamtionID("jump_begin")].layer = AnimationLayer.NORMAL;
		am[info.getAniamtionID("jump_begin")].weight = 100;
		
		
		am[info.getAniamtionID("jump_up")].wrapMode = WrapMode.Once;
		am[info.getAniamtionID("jump_up")].layer = AnimationLayer.NORMAL;
		am[info.getAniamtionID("jump_up")].weight = 100;
		
		
		
		am[info.getAniamtionID("jump_down")].wrapMode = WrapMode.ClampForever;
		am[info.getAniamtionID("jump_down")].layer = AnimationLayer.NORMAL;
		am[info.getAniamtionID("jump_down")].weight = 100;		
	
		
		
		am[info.getAniamtionID("fall")].wrapMode = WrapMode.Once;
		am[info.getAniamtionID("fall")].layer = AnimationLayer.NORMAL;
		am[info.getAniamtionID("fall")].weight = 100;			
			
		
		base.start( am,  info );
	}
	
	
	//method of update
	override public void update()
	{
		/*
		if ( _info.curState == PlayerAnimationState.JUMP  && _info.isGround )
		{
			EventManager.getSingleton().sendMsg( "Player_Fall" );
		}
		
		if ( Input.GetButtonDown("Jump"))
		{
			//if ( curJumpState == JumpState.JUMP_BEGIN )
			//{
 				_info.curState = PlayerAnimationState.JUMP;
				//_am.Stop( _info.getAniamtionID("jump_up") );
				_am.Stop( _info.getAniamtionID("jump_down") );
				//_am.Stop( _info.getAniamtionID("fall") );
				//_am.Stop( _info.getAniamtionID("jump_begin") );
			
				setAnimationMsg("jump_begin", true);
			//}
		}
		
		*/
	}

	private void setAnimationMsg( string animationName, bool isSetMsg )
	{
		string id = _info.getAniamtionID(animationName);
		_am.Play(id);
		
		if ( isSetMsg )
		{ 
			AnimationEvent e = ProxyAnimationEvent.getAmimationEvent( "nextAnimation", nextAnimation );
			e.time = animationTime();
			setAnimationEvent( _info.getAniamtionID(animationName), e );
		}		
	}
	
	
	private void nextAnimation()
	{
		/*
		if ( _info.curState == PlayerAnimationState.JUMP )
		{
			switch( curJumpState )
			{
				case JumpState.JUMP_BEGIN:
				{
					curJumpState = JumpState.JUMP_UP;
					setAnimationMsg("jump_up", true);
				
					//send jump up msg
					EventManager.getSingleton().sendMsg("Player_JumpUp");
				
					break;
				}
				case JumpState.JUMP_UP:
				{
 					curJumpState = JumpState.JUMP_DOWN;
					setAnimationMsg("jump_down", false);
				
					//listen jump down msg
					EventManager.getSingleton().addEventListener( "Player_Fall", Fall );
					break;
				}
				case JumpState.JUMP_DOWN:
				{
					curJumpState = JumpState.JUMP_FALL;
					EventManager.getSingleton().removeEventListener( "Player_Fall", Fall );
					_am.Blend(_info.getAniamtionID("jump_down"), 0.0f, 0.1f);
					setAnimationMsg("fall", true);		
					break;
				}
				case JumpState.JUMP_FALL:
				{
					curJumpState = JumpState.JUMP_BEGIN;
					_info.curState = PlayerAnimationState.IDLE;
					return;
				}
				default:
				{
				 	_info.curState = PlayerAnimationState.IDLE;
					return;
				}
			}				
		}
		*/
	}
	
	private void Fall( CommentEvent e )
	{
		if ( e.eventType == "Player_Fall" && curJumpState == JumpState.JUMP_DOWN )
		{
			nextAnimation();
		}
	}
	
	//get animationclip time 
	override public float animationTime()
	{
		switch( curJumpState )
		{
			case JumpState.JUMP_BEGIN:
			{
				return _am[_info.getAniamtionID("jump_begin")].length;
			}
			case JumpState.JUMP_UP:
			{
				return _am[_info.getAniamtionID("jump_up")].length;
			}
			case JumpState.JUMP_DOWN:
			{
				return _am[_info.getAniamtionID("jump_down")].length;
			}
			case JumpState.JUMP_FALL:
			{
				return _am[_info.getAniamtionID("fall")].length;
			}
			default:
			{
				return 0.0f;
			}
		} 
	}	
}
