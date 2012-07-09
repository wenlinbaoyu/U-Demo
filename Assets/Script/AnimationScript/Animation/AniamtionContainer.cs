using System;
using System.Collections.Generic;

/// <summary>
/// Aniamtion container. 
/// </summary>
/// 
public class AniamtionContainer
{
	private List<IBaseAnimation> _amList;
	
	
	virtual public void start( AID aid ){}
	virtual protected void playerList(){}
	
	protected AniamtionContainer()
	{
		_amList = new List<IBaseAnimation>();
	}
	
	protected void Clear()
	{
		_amList.Clear();
	}
	
	protected int length()
	{
		return _amList.Count;
	}
	
	protected IBaseAnimation getAnimation( int index )
	{
		if ( _amList == null ) return null;
		return _amList[index];
	}
	
	protected void addAniamtion( IBaseAnimation am )
	{
		if ( _amList != null )
		{
			_amList.Add( am );
		}
	}
	
	protected void removeAniamtion( IBaseAnimation am )
	{}
}

