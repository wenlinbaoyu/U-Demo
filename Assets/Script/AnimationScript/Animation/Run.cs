using System;
using UnityEngine;


public class Run : BaseAnimation
{	

	//method of start
	override public void start( MonoBehaviour mono , PlayerAnimationInfo info )
	{
		base.start( mono,  info );	

		_am[info.getAniamtionID("run")].wrapMode = WrapMode.Loop;
		_am[info.getAniamtionID("run")].layer = AnimationLayer.LOWEST;
		_am[info.getAniamtionID("run")].weight = 100;

		_am[info.getAniamtionID("run_left")].wrapMode = WrapMode.Loop;
		_am[info.getAniamtionID("run_left")].layer = AnimationLayer.LOWEST;
		_am[info.getAniamtionID("run_left")].weight = 100;
		
		
		_am[info.getAniamtionID("run_right")].wrapMode = WrapMode.Loop;
		_am[info.getAniamtionID("run_right")].layer = AnimationLayer.LOWEST;
		_am[info.getAniamtionID("run_right")].weight = 100;
		
	
		_am[info.getAniamtionID("run_tab")].wrapMode = WrapMode.Loop;
		_am[info.getAniamtionID("run_tab")].layer = AnimationLayer.LOWEST;
		_am[info.getAniamtionID("run_tab")].weight = 100;
		
		_am[info.getAniamtionID("run_left_tab")].wrapMode = WrapMode.Loop;
		_am[info.getAniamtionID("run_left_tab")].layer = AnimationLayer.LOWEST;
		_am[info.getAniamtionID("run_left_tab")].weight = 100;
		
		
		_am[info.getAniamtionID("run_right_tab")].wrapMode = WrapMode.Loop;
		_am[info.getAniamtionID("run_right_tab")].layer = AnimationLayer.LOWEST;
		_am[info.getAniamtionID("run_right_tab")].weight = 100;
		
		
		_am[info.getAniamtionID("walk")].wrapMode = WrapMode.Loop;
		_am[info.getAniamtionID("walk")].layer = AnimationLayer.LOWEST;
		_am[info.getAniamtionID("walk")].weight = 100;
	}	
	
	override public void enter()
	{
		bool isTab = (bool)_info.getAnimationState("ANMIATIONSTATE_ISTAB");
		if ( isTab )
		{
			_am.Stop( _info.getAniamtionID("run") );
			_am.CrossFade( _info.getAniamtionID("run_tab") );
		}
		else
		{
			_am.Stop( _info.getAniamtionID("run_tab") );
			_am.CrossFade( _info.getAniamtionID("run") );
		}
	}
	
	//method of update
	override public void update()
	{
		/*
		if ( _info.curState == PlayerAnimationState.RUN )
		{
			if ( _info.isTab )
			{
				_am.Stop( _info.getAniamtionID("run") );
				_am.CrossFade( _info.getAniamtionID("run_tab") );
			}
			else
			{
				_am.Stop( _info.getAniamtionID("run_tab") );
				_am.CrossFade( _info.getAniamtionID("run") );
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
			return _am[ _info.getAniamtionID("run_tab") ].length; 
		}
		else
		{
			return _am[ _info.getAniamtionID("run") ].length; 
		}
	}
		
}


