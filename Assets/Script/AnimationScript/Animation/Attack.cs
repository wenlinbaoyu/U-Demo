using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Attack : BaseAnimation
{	
	private int attack_num = 0;
	private delegate void multipleHitHandle();
	private List<multipleHitHandle> _handleList;
		
	
	//method of start
	override public void start( BaseController controller , PlayerAnimationInfo info )
	{
		base.start( controller,  info );
		
		_am[info.getAniamtionID("attack")].wrapMode = WrapMode.ClampForever;
		_am[info.getAniamtionID("attack")].layer = AnimationLayer.NORMAL;
		_am[info.getAniamtionID("attack")].weight = 100;
		
		
		_am[info.getAniamtionID("attack_double")].wrapMode = WrapMode.Once;
		_am[info.getAniamtionID("attack_double")].layer = AnimationLayer.NORMAL;
		_am[info.getAniamtionID("attack_double")].weight = 100;
			
		_am[info.getAniamtionID("attack_shou")].wrapMode = WrapMode.Once;
		_am[info.getAniamtionID("attack_shou")].layer = AnimationLayer.NORMAL;
		_am[info.getAniamtionID("attack_shou")].weight = 100;
			
		_am[info.getAniamtionID("attack_double_shou")].wrapMode = WrapMode.Once;
		_am[info.getAniamtionID("attack_double_shou")].layer = AnimationLayer.NORMAL;
		_am[info.getAniamtionID("attack_double_shou")].weight = 100;
				
		_handleList = new List<multipleHitHandle>();

	}
	
	
	override public void enter()
	{
		if (  Input.GetButtonDown("Fire1") )
		{
			
			//发送攻击事件
			if ( _controller.eventMgr != null )
			{
				_controller.eventMgr.Broadcast( EventManager.EVENT_ATTACK );
			}
			
			_info.setAnimationState("ANMIATIONSTATE_FINISH", false);
			bool isGround = (bool)_info.getAnimationState("ANMIATIONSTATE_ISGROUND");
			if ( !isGround )
			{
				_info.setAnimationState("ANMIATIONSTATE_FINISH", true);
				return;
			}
			
			if ( attack_num == 0)
			{
				//if ( (_controller.weaponTransform != null) && (_controller.weaponTransform.collider != null) )
				//{
					//_controller.weaponTransform.collider.enabled = true;
			//	}
				
				Transform tf = _controller.weaponTransform;
				if ( tf != null && tf.collider != null )
				{
					tf.collider.enabled = true;
				}
				
				
				attack_num = 1;
				_am.Play( _info.getAniamtionID("attack") );
				_controller.StartCoroutine( wait(animationTime("attack"), nextAttackAnimation));
			}
		}
	}
	
	//method of update
	override public void update()
	{
		if (  Input.GetButtonDown("Fire1") )
		{
			if ( attack_num == 1)
			{
				attack_num = 2;
				multipleHitHandle handle = new multipleHitHandle( doubleAttack );
				_handleList.Add(handle);
			}
		}
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
			Transform tf = _controller.weaponTransform;
			if ( tf != null && tf.collider != null )
			{
				tf.collider.enabled = false;
			}
			
			
			playEndAnimation();
		}
	}
	
	private void playEndAnimation()
	{
		
		string endAnimation = "";
		if ( attack_num == 1) endAnimation = "attack_shou";
		if ( attack_num == 2)  endAnimation = "attack_double_shou";
		
		_am.Play( _info.getAniamtionID(endAnimation) );
		
		_controller.StartCoroutine( wait(animationTime(endAnimation), endAttackAnimation));
	}
	
	private void endAttackAnimation()
	{
		attack_num = 0;
		_handleList.Clear();
		_info.setAnimationState("ANMIATIONSTATE_FINISH", true);
	}
	
	private void doubleAttack()
	{
		_am.Play( _info.getAniamtionID("attack_double") );
		
		_controller.StartCoroutine( wait(animationTime("attack_double"), nextAttackAnimation));
	}
	
	//get animationclip time 
	override public float animationTime( string animationName )
	{
		return _am[ _info.getAniamtionID(animationName)].length; 	
	}
	
	
	private IEnumerator wait( float second, multipleHitHandle handler)
	{
		yield return new WaitForSeconds( second );
		handler();
	}
}


