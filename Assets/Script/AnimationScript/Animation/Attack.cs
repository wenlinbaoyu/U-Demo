using System;
using UnityEngine;
using System.Collections.Generic;

public class Attack : BaseAnimation
{	
	private int attack_num = 0;
	private delegate void multipleHitHandle();
	private List<multipleHitHandle> _handleList;
		
	//method of start
	override public void start( Animation am , PlayerAnimationInfo info )
	{
		am[info.getAniamtionID("attack")].wrapMode = WrapMode.Once;
		am[info.getAniamtionID("attack")].layer = AnimationLayer.NORMAL;
		am[info.getAniamtionID("attack")].weight = 100;
		
		
		am[info.getAniamtionID("attack_double")].wrapMode = WrapMode.Once;
		am[info.getAniamtionID("attack_double")].layer = AnimationLayer.NORMAL;
		am[info.getAniamtionID("attack_double")].weight = 100;
			
		am[info.getAniamtionID("attack_shou")].wrapMode = WrapMode.Once;
		am[info.getAniamtionID("attack_shou")].layer = AnimationLayer.NORMAL;
		am[info.getAniamtionID("attack_shou")].weight = 100;
			
		am[info.getAniamtionID("attack_double_shou")].wrapMode = WrapMode.Once;
		am[info.getAniamtionID("attack_double_shou")].layer = AnimationLayer.NORMAL;
		am[info.getAniamtionID("attack_double_shou")].weight = 100;
					

		
		_handleList = new List<multipleHitHandle>();
		base.start( am,  info );
	}
	
	
	//method of update
	override public void update()
	{
		/*
		if ( Input.GetButtonDown("Fire1"))
		{
		
			if ( !_info.isGround ) return;
			if ( _info.curState == PlayerAnimationState.JUMP ) return;

			_info.curState = PlayerAnimationState.ATTACK;
			if ( attack_num == 0)
			{
				attack_num = 1;
				_am.Play( _info.getAniamtionID("attack") );
				
				AnimationEvent e = ProxyAnimationEvent.getAmimationEvent( "nextAttackAnimation", nextAttackAnimation );
				e.time = animationTime("attack");
				setAnimationEvent( _info.getAniamtionID("attack"), e ); 
			}
			else if ( attack_num == 1)
			{
				attack_num = 2;
				multipleHitHandle handle = new multipleHitHandle( doubleAttack );
				_handleList.Add(handle);
			}
		}
		*/
	}
	
	private void nextAttackAnimation()
	{
		if ( _handleList.Count > 0 )
		{
			multipleHitHandle handler = _handleList[0];
			_handleList.RemoveAt(0);
			handler();
		}
		else
		{
			playEndAnimation();
		}
	}
	
	private void playEndAnimation()
	{
		
		string endAnimation = "";
		if ( attack_num == 1) endAnimation = "attack_shou";
		if ( attack_num == 2)  endAnimation = "attack_double_shou";
		
		_am.Play( _info.getAniamtionID(endAnimation) );
		
		AnimationEvent e = ProxyAnimationEvent.getAmimationEvent( "endAttackAnimation", endAttackAnimation );
		e.time = animationTime(endAnimation);
		setAnimationEvent( _info.getAniamtionID(endAnimation), e );	
	}
	
	private void endAttackAnimation()
	{
		attack_num = 0;
		_handleList.Clear();
		//_info.curState = PlayerAnimationState.IDLE;
	}
	
	private void doubleAttack()
	{
		_am.Play( _info.getAniamtionID("attack_double") );
		AnimationEvent e = ProxyAnimationEvent.getAmimationEvent( "nextAttackAnimation", nextAttackAnimation );
		e.time = animationTime("attack_double");
		setAnimationEvent( _info.getAniamtionID("attack_double"), e );
	}
	
	//get animationclip time 
	override public float animationTime( string animationName )
	{
		return _am[ _info.getAniamtionID(animationName)].length; 	
	}
}


