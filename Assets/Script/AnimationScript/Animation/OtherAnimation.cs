using System;
using UnityEngine;

public class OtherAnimation : BaseAnimation
{
	//method of start
	override public void start( Animation am , PlayerAnimationInfo info )
	{
		am[info.getAniamtionID("shoujian")].wrapMode = WrapMode.Once;
		am[info.getAniamtionID("shoujian")].layer = AnimationLayer.NORMAL;
		am[info.getAniamtionID("shoujian")].weight = 100;
		
		am[info.getAniamtionID("bajian")].wrapMode = WrapMode.Once;
		am[info.getAniamtionID("bajian")].layer = AnimationLayer.NORMAL;
		am[info.getAniamtionID("bajian")].weight = 100;
		
		base.start( am,  info );
	}
	
	//method of update
	override public void update()
	{
		if ( Input.GetKeyDown( KeyCode.Tab ) )
		{
			_info.isTab = !_info.isTab;
			if ( _info.isTab )
			{
				_am.Play( _info.getAniamtionID("shoujian") );
			}
			else
			{
				_am.Play( _info.getAniamtionID("bajian") );
			}	
		}
	}
	
	//get animationclip time 
	override public float animationTime( string animationName )
	{
		return _am[ _info.getAniamtionID(animationName) ].length; 
	}
}


