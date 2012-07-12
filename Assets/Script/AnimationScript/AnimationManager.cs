using System;
using UnityEngine;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;


public class AnimationManager
{
	private List<BaseAnimation> _amList;
	private Hashtable _hashtable = null ;
	private Animation _animation = null;
	private String _playerName = "";
	
	/*
	private BaseAnimation attack = null;
	private BaseAnimation run = null;
	private BaseAnimation idle = null;
	private BaseAnimation jump = null;
	private BaseAnimation other = null;
	private BaseAnimation shortcut = null;
	*/
	 
	public AnimationManager ( string playername , Animation animation, PlayerAnimationInfo info )
	{
		_animation = animation;
		if ( _animation )
		{
			_playerName = playername;
			_hashtable = new Hashtable(); 
			init( info );
		}

	}
	
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
	
	
	
	/*
	//获取动作
	private BaseAnimation getAnimation( AID aid )
	{
		BaseAnimation am = _hashtable[ aid.id ] as BaseAnimation;
		if ( am == null )
		{
			am = loadAM( aid );
		}
		return am;
	}
	*/
	
	/*
	//加载动作
	private BaseAnimation loadAM( AID aid )
	{
		BaseAnimation baseAM = null;
		if ( aid != null )
		{
			baseAM = AnimationKeyValue.getSingleton().getAnimation( aid );
			if ( baseAM != null )
			{
				_hashtable.Add( aid.id,  baseAM );				
			}
			else
			{
				Debug.Log( " the animation '" + aid.id + "' do not registered" );
				return null;
			}
		}
		return baseAM;
	}
	*/
	
	/*
	//播放动作
	public void play( AID aid )
	{
		BaseAnimation am = getAnimation( aid );		
		if ( am != null &&  _animation != null)
		{
			am.play( _animation, prama );
		}
		else
		{
			Debug.Log( "Function: play --  the player '" + _playerName + "' didn't have animation " + aid.id );
		}
	}
	*/
	
	public void update()
	{
		if ( _amList == null ) return ;
		for ( int i = 0; i < _amList.Count ; i++ )
		{
			(_amList[i] as BaseAnimation ).update();
		}
	}

	
	
	/*
	//设置动作时间
	public void animationClipEvent( AID aid, AnimationEvent ae )
	{
		BaseAnimation am = getAnimation( aid );
		
		if ( am != null )
		{
			am.setAnimationEvent( _animation, ae );
		}
		else
		{
			Debug.Log( "Function: animationClipEvent --  the player '" + _playerName + "' didn't have animation " + aid.id );
		}
	}
	
	//动作时间
	public float animationClipTime( AID aid )
	{
		BaseAnimation am = getAnimation( aid );
		
		if ( am != null )
		{
			return am.animationTime( _animation );
		}
		else
		{
			Debug.Log( "Function: animationClipTime --  the player '" + _playerName + "' didn't have animation " + aid.id );
			return 0.0f;
		}
	}
	
	*/
}


