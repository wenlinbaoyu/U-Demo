using System;
using UnityEngine;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;


public class AnimationManager
{
	private Hashtable _amList;
	//private Hashtable _hashtable = null ;
	//private Animation _animation = null;
	private String _playerName = "";
	//private String _curAnimation = "";
	private PlayerAnimationInfo _info = null ;
	
	//call back function delegate
	public delegate void CallBackHandler();
	public delegate void CallBackHandlerWithParam( object obj );
	
	public AnimationManager ( BaseController controller, PlayerAnimationInfo info )
	{
		//_animation = mono.animation;
		_playerName = controller.gameObject.name;
		_info = info;
		init( controller , info);
	}
	
	/*
	public void start()
	{
		Hashtable talbe = _info.animations;
		foreach ( DictionaryEntry de in talbe )
		{
			AnimationProperty property = _info.getAnimationProperty((string)(de.Key));
			if ( property != null )
			{
				_animation[(string)(de.Value)].wrapMode = property.mode;
				_animation[(string)(de.Value)].layer    = property.layer;
				_animation[(string)(de.Value)].weight   = property.weight;
				
			}
		}
	}
	*/
	
	
	private void init( BaseController controller, PlayerAnimationInfo info )
	{
		_amList = new Hashtable();
		if ( info.hasHandler("runHandler"))  	  _amList.Add("runHandler",  createInstance( info.getHandler("runHandler") ) );
		if ( info.hasHandler("attackHandler"))    _amList.Add("attackHandler", createInstance( info.getHandler("attackHandler") ) );
		if ( info.hasHandler("idleHandler"))      _amList.Add("idleHandler", createInstance( info.getHandler("idleHandler") ) );
		if ( info.hasHandler("jumpHandler"))      _amList.Add("jumpHandler", createInstance( info.getHandler("jumpHandler") ) );
		if ( info.hasHandler("shortcutHandler"))  _amList.Add("shortcutHandler", createInstance( info.getHandler("shortcutHandler") ) );
		if ( info.hasHandler("otherHandler"))  	  _amList.Add("otherHandler",  createInstance( info.getHandler("otherHandler") ) );
		
		foreach ( DictionaryEntry de in _amList )
		{
			(de.Value as BaseAnimation).start( controller, info );
		}
	}
	
	private BaseAnimation createInstance( Type type )
	{
		return Activator.CreateInstance( type ) as BaseAnimation;
	}
	
	
	public object getPlayerAnimationState( string stateName )
	{
		return _info.getAnimationState( stateName );
	}
	
	public void setPlayerAnimationState( string stateName, object obj )
	{
		_info.setAnimationState( stateName, obj );
	}
	
	public void enter( string name )
	{
		( _amList[name] as BaseAnimation ).enter();
	}
	
	public void update( string name )
	{
		( _amList[name] as BaseAnimation ).update();
	}

	public void exit( string name )
	{
		( _amList[name] as BaseAnimation ).exit();
	}
}



