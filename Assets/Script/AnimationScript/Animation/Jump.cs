using System;
using UnityEngine;

public class Jump : AniamtionContainer, IBaseAnimation
{
	//private const string ANIMATION_NAME = "1019";
	//public Jump(){}
	
	private bool _isPlaying = false;
	override public void start( AID aid )
	{
		Array array = aid.getArray("subanimationNumber");
		Array sendEvntArray = aid.getArray("subSendEvent");
		Array listenEventArray = aid.getArray("subListenEvent");
		
		for ( int i = 0; i < array.Length ; i ++ )
		{
			Jump_sub subAm = new Jump_sub( array[i] );
			if ( sendEvntArray[i] != "" )
			{
				subAm.setSendEvent( sendEvntArray[i] );	
			}
			
			if ( listenEventArray[i] != "" )
			{
				subAm.setListendEvent( listenEventArray[i] );	
			}
			
			addAniamtion( new Jump_sub( array[i]));
		}
	}
	
	private Animation _am = null;
	private int playNum =  0 ;
	//播放animationclip
	public  void play( Animation am, object args )
	{
		if ( _isPlaying ) return ;
		
		_am = am;
		playerList( am );
	}
	
	override public void playerList( )
	{
		IBaseAnimation subAnimation = getAnimation( playNum );
		if ( subAnimation == null )
		{
			_isPlaying = true;
			playNum = 0;
			EventManager.getSingleton().sendMsg( "EndAniamtonContainer" );
		}
		else
		{
			subAnimation.play( _am , null);
		}
		
	}
	
	
	//设置动作相应
	public void setAnimationEvent( Animation am, AnimationEvent e ){}
	
	//get animationclip time 
	public float animationTime( Animation am ){ return 0.0f; }
		
		
	//get animationclip time by normalaize
	public float animationTimeNormalize( Animation am ){ return 0.0f; }
	
	public void addAniamtion( IBaseAnimation am ){}
	
	public void removeAniamtion( IBaseAnimation am ){}
}


public class Jump_sub : IBaseAnimation
{
	private string _aType;
	private string _eventSendName = "";
	private string _eventListenName = "";
	
	private delegate void NextHandler();
	private event NextHandler _nextEvent; 
	//private EventManager.EventHandler _listendHandler; 
	
	
	public Jump_sub( string type  )
	{
		_aType = type;
	}
	
	//播放animationclip 
	public  void play( Animation am, object args )
	{
		am.CrossFade( _aType );
		
		if ( _eventSendName == "" && _eventSendName == "")
		{
			if ( _nextHandler != null )
				_nextHandler();
		}
		else
		{
			if ( _eventSendName != "")
			{
				
			}
			
			if ( _eventSendName != "" )
			{
				
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
		_nextHandler += handler;
	}
	
	private void sendMsg( )
	{
		if ( _eventListenName != "") 
			EventManager.getSingleton().sendMsg( _eventSendName );
	}
	
	private void listenMsg()
	{
		if ( _eventListenName != "")
			EventManager.getSingleton().addEventListener( _eventListenName, ListenFunc );
	}
	
	
	private void ListenFunc( CommentEvent e )
	{
		if ( _nextHandler != null )
			_nextHandler();
	}
	
	//设置动作相应
	public void setAnimationEvent( Animation am, AnimationEvent e )
	{
		
	}
	
	//get animationclip time 
	public float animationTime( Animation am ){ return 0.0f; }
		
	//get animationclip time by normalaize
	public float animationTimeNormalize( Animation am ){ return 0.0f; }
	
}