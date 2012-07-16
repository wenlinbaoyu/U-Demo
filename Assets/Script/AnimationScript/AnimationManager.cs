using System;
using UnityEngine;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;


public class AnimationManager
{
	private List<BaseAnimation> _amList;
	//private Hashtable _hashtable = null ;
	private Animation _animation = null;
	private String _playerName = "";
	private String _curAnimation = "";
	private PlayerAnimationInfo _info = null ;
	
	//call back function delegate
	public delegate void CallBackHandler();
		
	public AnimationManager ( string playername , Animation animation, PlayerAnimationInfo info )
	{
		_animation = animation;
		if ( _animation )
		{
			_playerName = playername;
			_info = info;
			
			start();
		}
	}
	
	public void start()
	{
		Hashtable talbe = _info.animations;
		foreach ( DictionaryEntry de in talbe )
		{
			AnimationProperty property = _info.getAnimationProperty( de.Key );
			if ( property != null )
			{
				_animation[de.Value].wrapMode = property.mode;
				_animation[de.Value].layer    = property.layer;
				_animation[de.Value].weight   = property.weight;
				
			}
		}
	}
	
	
	/*
	private void init( PlayerAnimationInfo info )
	{
		_amList = new List<BaseAnimation>();
		if ( info.hasHandler("runHandler"))  	  _amList.Add( createInstance( info.getHandler("runHandler") ) );
		if ( info.hasHandler("attackHandler"))    _amList.Add( createInstance( info.getHandler("attackHandler") ) );
		if ( info.hasHandler("idleHandler"))      _amList.Add( createInstance( info.getHandler("idleHandler") ) );
		if ( info.hasHandler("jumpHandler"))      _amList.Add( createInstance( info.getHandler("jumpHandler") ) );
		if ( info.hasHandler("shortcutHandler"))  _amList.Add( createInstance( info.getHandler("shortcutHandler") ) );
		if ( info.hasHandler("otherHandler"))  	  _amList.Add( createInstance( info.getHandler("otherHandler") ) );
		
		for ( int i = 0; i < _amList.Count ; i ++ )
		{
			(_amList[i] as BaseAnimation).start(_animation, info );
		}
	}
	
	private BaseAnimation createInstance( Type type )
	{
		return Activator.CreateInstance( type ) as BaseAnimation;
	}
	*/
	
	public String getCurrentAniamtion()
	{
		return _curAnimation;
	}
	
	
	public object getPlayerAnimationState( string stateName )
	{
		return _info.getAnimationState( stateName );
	}
	
	public void setPlayerAnimationState( string stateName, object obj )
	{
		_info.setAnimationState( stateName, obj );
	}
	
	//播放动作
	public void play( string animationName, bool isCrossFade )
	{
		string id = _info.getAniamtionID( animationName );
		if ( id == "" )
		{
			Debug.Log( "Function: play --  the player '" + _playerName + "' didn't have animation " + animationName );
			return;
		}
		
		_curAnimation = animationName;
		if ( isCrossFade )
		{
			_animation.CrossFade( id );
		}
		else
		{
			_animation.Play( id );			
		}
	}
	
	//播放动作
	public IEnumerator play( string animationName, bool isCrossFade, float waitSecond, CallBackHandler handler )
	{
		string id = _info.getAniamtionID( animationName );
		if ( id == "" )
		{
			Debug.Log( "Function: play --  the player '" + _playerName + "' didn't have animation " + animationName );
			yield break;
		}
		
		_curAnimation = animationName;
		if ( isCrossFade )
		{
			_animation.CrossFade( id );
		}
		else
		{
			_animation.Play( id );			
		}
		
		yield return new WaitForSeconds( _animation[ id ].length + waitSecond );
		handler();
	}
	
	
	//停止播放
	public void stop( string animationName )
	{
		string id = _info.getAniamtionID( animationName );
		if ( id == "" )
		{
			Debug.Log( "Function: play --  the player '" + _playerName + "' didn't have animation " + animationName );
			return;
		}
		
		_animation.Stop( id );
	}	
}


