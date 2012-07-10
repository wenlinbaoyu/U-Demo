using System;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Aniamtion container. 
/// </summary>
/// 
public class AniamtionContainer
{
	protected Animation _am = null;
	protected List<IBaseAnimation> _amList;
	protected int _curAnimation = 0;
	
	virtual public void start( AID aid ){}
	//virtual protected void playerList(){}
	
	public AniamtionContainer()
	{
		_amList = new List<IBaseAnimation>();
	}
	
	virtual protected void Clear()
	{
		_amList.Clear();
	}
	
	virtual protected int length()
	{
		return _amList.Count;
	}
	
	virtual protected IBaseAnimation getAnimation( int index )
	{
		if ( _amList == null ) return null;
		if ( index >= _amList.Count) return null;
		return _amList[index];
	}
	
	virtual protected IBaseAnimation getFristAniamtoin()
	{
		_curAnimation = 0;
		return ( getAnimation(_curAnimation) );
	}
	
	virtual protected IBaseAnimation getNextAnimation()
	{
		return ( getAnimation(++_curAnimation));
	}
	
	virtual protected int curAnimation
	{
		get
		{
			return _curAnimation;
		}
		set
		{
			_curAnimation = value;
		}
	}
	
	virtual protected void addAniamtion( IBaseAnimation am )
	{
		if ( _amList != null )
		{
			_amList.Add( am );
		}
	}
	
	virtual protected void removeAniamtion( IBaseAnimation am )
	{
		_amList.Remove( am );
	}
	
	
	virtual protected void playeList( Animation am )
	{
		_am = am;
		IBaseAnimation subAnimation = getFristAniamtoin();
		if ( subAnimation == null )
		{
			EventManager.getSingleton().sendMsg( "EndAniamtonContainer" );
		}
		else
		{
			subAnimation.play( _am , null);
		}
	}
	
	virtual protected void nextAnimation()
	{
		IBaseAnimation subAnimation = getNextAnimation();
		if ( subAnimation == null )
		{
			EventManager.getSingleton().sendMsg( "EndAniamtonContainer" );
		}
		else
		{
			subAnimation.play( _am , null);
		}
	}	
}

