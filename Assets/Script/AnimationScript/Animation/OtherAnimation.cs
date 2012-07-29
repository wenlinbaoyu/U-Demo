using System;
using System.Collections;
using UnityEngine;

public class OtherAnimation : BaseAnimation
{
	//method of start
	override public void start( BaseController controller , PlayerAnimationInfo info )
	{
		base.start( controller,  info );		
		
		_am[info.getAniamtionID("shoujian")].wrapMode = WrapMode.ClampForever;
		_am[info.getAniamtionID("shoujian")].layer = AnimationLayer.NORMAL;
		_am[info.getAniamtionID("shoujian")].weight = 100;
		
		_am[info.getAniamtionID("bajian")].wrapMode = WrapMode.ClampForever;
		_am[info.getAniamtionID("bajian")].layer = AnimationLayer.NORMAL;
		_am[info.getAniamtionID("bajian")].weight = 100;
		

		//be hit animation
		_am[info.getAniamtionID("hit")].wrapMode = WrapMode.Once;
		_am[info.getAniamtionID("hit")].layer = AnimationLayer.NORMAL;
		_am[info.getAniamtionID("hit")].weight = 100;
	
		
		_am[info.getAniamtionID("hit")].wrapMode = WrapMode.Once;
		_am[info.getAniamtionID("hit")].layer = AnimationLayer.HIGH;
		_am[info.getAniamtionID("hit")].weight = 100;		
		
		
		_am[info.getAniamtionID("dead")].wrapMode = WrapMode.ClampForever;
		_am[info.getAniamtionID("dead")].layer = AnimationLayer.HIGH;
		_am[info.getAniamtionID("dead")].weight = 100;			
	}
	
	override public void enter()
	{
		//_info.setAnimationState("ANMIATIONSTATE_FINISH", false);
		
		if ( Input.GetKeyDown( KeyCode.Tab ) )
		{
			bool isTab = (bool)_info.getAnimationState("ANMIATIONSTATE_ISTAB");
			_info.setAnimationState("ANMIATIONSTATE_ISTAB", !isTab);
			if ( !isTab )
			{
				_am.Play( _info.getAniamtionID("shoujian") );
				_controller.StartCoroutine(EndAnimation(animationTime("shoujian")));
			}
			else
			{
				_am.Play( _info.getAniamtionID("bajian") );
				_controller.StartCoroutine(EndAnimation(animationTime("shoujian")));
			}
		}
		else if ( (bool)_info.getAnimationState("ANMIATIONSTATE_BEHIT"))
		{
			_am.Stop( _info.getAniamtionID("hit") );
			_am.Play( _info.getAniamtionID("hit") );
			_controller.StartCoroutine(EndAnimation(animationTime("hit")));
		}
		else if( (bool)_info.getAnimationState("ANMIATIONSTATE_BEHIT") )
		{
			_am.Play( _info.getAniamtionID("dead") );
		}
		else
		{
			_controller.eventMgr.Broadcast( 
				new AnimationControllerEvent( AnimationControllerEvent.EVENT_ANIMATION_FINISH, _controller )
				);
			
			_info.setAnimationState("ANMIATIONSTATE_FINISH", true);
		}
	}
	
	//method of update
	override public void update()
	{
		
	}
	
	//get animationclip time 
	override public float animationTime( string animationName )
	{
		return _am[ _info.getAniamtionID(animationName) ].length; 
	}
	
	private IEnumerator EndAnimation( float second )
	{
		yield return new WaitForSeconds( second );
		
		_controller.eventMgr.Broadcast( 
			new AnimationControllerEvent( AnimationControllerEvent.EVENT_ANIMATION_FINISH, _controller )
			);
		//_info.setAnimationState("ANMIATIONSTATE_FINISH", true);
	}
}


