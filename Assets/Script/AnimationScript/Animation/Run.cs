using System;
using UnityEngine;


public class Run : BaseAnimation
{	
	//method of start
	override public void start( Animation am , PlayerAnimationInfo info )
	{
		am[info.getAniamtionID("run")].wrapMode = WrapMode.Loop;
		am[info.getAniamtionID("run")].layer = AnimationLayer.LOWEST;
		am[info.getAniamtionID("run")].weight = 100;

		am[info.getAniamtionID("run_left")].wrapMode = WrapMode.Loop;
		am[info.getAniamtionID("run_left")].layer = AnimationLayer.LOWEST;
		am[info.getAniamtionID("run_left")].weight = 100;
		
		
		am[info.getAniamtionID("run_right")].wrapMode = WrapMode.Loop;
		am[info.getAniamtionID("run_right")].layer = AnimationLayer.LOWEST;
		am[info.getAniamtionID("run_right")].weight = 100;
		
		
		
		am[info.getAniamtionID("run_tab")].wrapMode = WrapMode.Loop;
		am[info.getAniamtionID("run_tab")].layer = AnimationLayer.LOWEST;
		am[info.getAniamtionID("run_tab")].weight = 100;
		
		am[info.getAniamtionID("run_left_tab")].wrapMode = WrapMode.Loop;
		am[info.getAniamtionID("run_left_tab")].layer = AnimationLayer.LOWEST;
		am[info.getAniamtionID("run_left_tab")].weight = 100;
		
		
		am[info.getAniamtionID("run_right_tab")].wrapMode = WrapMode.Loop;
		am[info.getAniamtionID("run_right_tab")].layer = AnimationLayer.LOWEST;
		am[info.getAniamtionID("run_right_tab")].weight = 100;
		
		
		am[info.getAniamtionID("walk")].wrapMode = WrapMode.Loop;
		am[info.getAniamtionID("walk")].layer = AnimationLayer.LOWEST;
		am[info.getAniamtionID("walk")].weight = 100;
		
		
		base.start( am,  info );
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
		return 0.0f;
		/*
		if ( _info.isTab )
		{
			return _am[ _info.getAniamtionID("run_tab") ].length; 
		}
		else
		{
			return _am[ _info.getAniamtionID("run") ].length; 
		}
		*/
	}
		
}


