using System;
using UnityEngine;


public class Idle : BaseAnimation
{	
	//method of start
	override public void start( Animation am , PlayerAnimationInfo info )
	{
		am[info.getAniamtionID("idle")].wrapMode = WrapMode.Loop;
		am[info.getAniamtionID("idle")].layer = AnimationLayer.LOWEST;
		am[info.getAniamtionID("idle")].weight = 100;
		
		
		am[info.getAniamtionID("idle_tab")].wrapMode = WrapMode.Loop;
		am[info.getAniamtionID("idle_tab")].layer = AnimationLayer.LOWEST;
		am[info.getAniamtionID("idle_tab")].weight = 100;

		base.start( am,  info );
	}
	
	
	//method of update
	override public void update()
	{
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
	}
	
	//get animationclip time 
	override public float animationTime()
	{
		if ( _info.isTab )
		{
			return _am[ _info.getAniamtionID("idle_tab") ].length; 
		}
		else
		{
			return _am[ _info.getAniamtionID("idle") ].length; 
		}
	}
}


