using System;
using System.Collections;
using UnityEngine;

public class OtherAnimation : BaseAnimation
{
	//method of start
	override public void start( MonoBehaviour mono , PlayerAnimationInfo info )
	{
		base.start( mono,  info );		
		
		_am[info.getAniamtionID("shoujian")].wrapMode = WrapMode.ClampForever;
		_am[info.getAniamtionID("shoujian")].layer = AnimationLayer.NORMAL;
		_am[info.getAniamtionID("shoujian")].weight = 100;
		
		_am[info.getAniamtionID("bajian")].wrapMode = WrapMode.ClampForever;
		_am[info.getAniamtionID("bajian")].layer = AnimationLayer.NORMAL;
		_am[info.getAniamtionID("bajian")].weight = 100;
	}
	
	override public void enter()
	{
		_info.setAnimationState("ANMIATIONSTATE_FINISH", false);
		if ( Input.GetKeyDown( KeyCode.Tab ) )
		{
			bool isTab = (bool)_info.getAnimationState("ANMIATIONSTATE_ISTAB");
			_info.setAnimationState("ANMIATIONSTATE_ISTAB", !isTab);
			if ( !isTab )
			{
				_am.Play( _info.getAniamtionID("shoujian") );
				_mono.StartCoroutine(EndAnimation(animationTime("shoujian")));
			}
			else
			{
				_am.Play( _info.getAniamtionID("bajian") );
				_mono.StartCoroutine(EndAnimation(animationTime("shoujian")));
			}
		}
		else
		{
			_info.setAnimationState("ANMIATIONSTATE_FINISH", true);
		}
	}
	
	//method of update
	override public void update(){}
	
	//get animationclip time 
	override public float animationTime( string animationName )
	{
		return _am[ _info.getAniamtionID(animationName) ].length; 
	}
	
	private IEnumerator EndAnimation( float second )
	{
		yield return new WaitForSeconds( second );
		_info.setAnimationState("ANMIATIONSTATE_FINISH", true);
	}
}


