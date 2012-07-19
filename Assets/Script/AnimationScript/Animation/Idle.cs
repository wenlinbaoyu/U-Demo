using System;
using UnityEngine;


public class Idle : BaseAnimation
{	
	//method of start
	override public void start( BaseController controller , PlayerAnimationInfo info )
	{
		base.start( controller,  info );
		
		_am[info.getAniamtionID("idle")].wrapMode = WrapMode.Loop;
		_am[info.getAniamtionID("idle")].layer = AnimationLayer.LOWEST;
		_am[info.getAniamtionID("idle")].weight = 100;
		
		
		_am[info.getAniamtionID("idle_tab")].wrapMode = WrapMode.Loop;
		_am[info.getAniamtionID("idle_tab")].layer = AnimationLayer.LOWEST;
		_am[info.getAniamtionID("idle_tab")].weight = 100;

	}
	
	
	override public void enter()
	{
		bool isTab = (bool)_info.getAnimationState("ANMIATIONSTATE_ISTAB");
		if ( isTab )
		{
			_am.Stop( _info.getAniamtionID("idle") );
			_am.CrossFade( _info.getAniamtionID("idle_tab") );
		}
		else
		{
			_am.Stop( _info.getAniamtionID("idle_tab") );
			_am.CrossFade( _info.getAniamtionID("idle") );
		}
	}
	
	//method of update
	override public void update()
	{
		/*
		if ( _info.curState == PlayerAnimationState.IDLE )
		{
			if ( _info.isTab )
			{
				_am.Stop( _info.getAniamtionID("idle") );
				_am.CrossFade( _info.getAniamtionID("idle_tab") );
			}
			else
			{
				_am.Stop( _info.getAniamtionID("idle_tab") );
				_am.CrossFade( _info.getAniamtionID("idle") );
			}
		}
		*/
	}
	
	//get animationclip time 
	override public float animationTime()
	{
		bool isTab = (bool)_info.getAnimationState("ANMIATIONSTATE_ISTAB");
		if ( isTab )
		{
			return _am[ _info.getAniamtionID("idle_tab") ].length; 
		}
		else
		{
			return _am[ _info.getAniamtionID("idle") ].length; 
		}
	}
}


