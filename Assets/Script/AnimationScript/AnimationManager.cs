using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AnimationManager
{
	private Hashtable _hashtable = null ;
	private Animation _animation = null;
	private String _playerName = "";
	
	public AnimationManager ( string playername , Animation animation )
	{
		_animation = GameObject.Find( playername ).animation;
		
		if ( _animation )
		{
			_playerName = playername;
			
			_hashtable = new Hashtable(); 	
		}
	}
	
	
	//获取动作
	private IBaseAnimation getAnimation( AID aid )
	{
		IBaseAnimation am = _hashtable[ aid.id ] as IBaseAnimation;
		if ( am == null )
		{
			am = loadAM( aid );
		}
		
		return am;
	}
	
	
	//加载动作
	private IBaseAnimation loadAM( AID aid )
	{
		IBaseAnimation animation = null;
		if ( aid != null )
		{
			animation = AnimationKeyValue.getSingleton().getAnimation( aid ) as IBaseAnimation;
			if ( animation != null )
			{
				_hashtable.Add( aid.id,  animation);
			}
			else
			{
				Debug.Log( " the animation '" + aid.id + "' do not registered" );
				return null;
			}
		}
		return animation;
	}
	
	//播放动作
	public void play( AID aid )
	{
		IBaseAnimation am = getAnimation( aid );		
		if ( am != null &&  _animation != null)
		{
			am.play( _animation );
		}
		else
		{
			Debug.Log( "Function: play --  the player '" + _playerName + "' didn't have animation " + aid.id );
		}
	}
	

	
	//设置动作时间
	public void animationClipEvent( AID aid, AnimationEvent ae )
	{
		IBaseAnimation am = getAnimation( aid );
		
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
		IBaseAnimation am = getAnimation( aid );
		
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
	

	public float animationClipNormalize( AID aid )
	{
		IBaseAnimation am = getAnimation( aid );
		if ( am != null ){
			return am.animationTimeNormalize( _animation );
		}
		else
		{
			Debug.Log( "Function: animationClipNormalize --  the player '" + _playerName + "' didn't have animation " + aid.id );
			return 0.0f;
		}
	}


}


