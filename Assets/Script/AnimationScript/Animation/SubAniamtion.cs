using System;
using UnityEngine;
using UnityEditor;

/****
 * 
 * the sub aniamtion of AninamtionList
 *
 */
public class SubAniamtion : IBaseAnimation
{
	private string _aType;
	private string _eventSendName = "";
	private string _eventListenName = "";
	
	public delegate void NextHandler();
	private event NextHandler _nextEvent; 
	
	public SubAniamtion( string type  )
	{
		_aType = type;
	}
	
	//播放animationclip 
	public  void play( Animation am, object args )
	{
		am[ _aType ].layer  = 10;
		am[ _aType ].weight = 100;
	
		am.CrossFade( _aType );
		
		// if have no event to do 
		if ( _eventSendName == "" && _eventListenName == "")
		{
			AnimationEvent e = ProxyAnimationEvent.getAmimationEvent("nextAniamtion", nextAniamtion);
			e.time = animationTime( am ) * 0.95f;
			setAnimationEvent( am, e );
		}
		else
		{
			if ( _eventSendName != "")
			{
				AnimationEvent e = ProxyAnimationEvent.getAmimationEvent("sendMsg", sendMsg);
				e.time = animationTime( am ) * 0.95f;
				setAnimationEvent( am, e );
			}
			
			if ( _eventListenName != "" )
			{
				AnimationEvent e = ProxyAnimationEvent.getAmimationEvent("listenMsg", listenMsg);
				e.time = animationTime( am ) * 0.95f;
				setAnimationEvent( am, e);
			}
		}
	}
	
	public void setSendEvent( string eventName )
	{
		_eventSendName = eventName;
	}
	
	public void setListendEvent( string eventName )
	{
		_eventListenName = eventName;
	}
	
	public void setNextHandler( NextHandler handler )
	{
		_nextEvent += handler;
	}
	
	private void sendMsg( )
	{
		if ( _eventSendName != "") 
			EventManager.getSingleton().sendMsg( _eventSendName );
		
		 if ( _nextEvent != null ) _nextEvent();
	}
	
	private void listenMsg()
	{
		if ( _eventListenName != "")
			EventManager.getSingleton().addEventListener( _eventListenName, ListenFunc );
	}
	
	private void nextAniamtion()
	{
		if ( _nextEvent != null ) _nextEvent();
	}
	
	private void ListenFunc( CommentEvent e )
	{
		//remove Event
		EventManager.getSingleton().removeEventListener( _eventListenName, ListenFunc );
		
		if ( _nextEvent != null ) _nextEvent();
	}
	
	//设置动作相应
	public void setAnimationEvent( Animation am, AnimationEvent e )
	{
		AnimationUtility.SetAnimationEvents( am[_aType].clip, new AnimationEvent[]{e});
	}
	
	//get animationclip time 
	public float animationTime( Animation am )
	{ 
		return (am[_aType].length); 
	}
		
	//get animationclip time by normalaize
	public float animationTimeNormalize( Animation am ){ return 0.0f; }
}

