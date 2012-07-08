using System;
using System.Collections.Generic;

/// <summary>
/// Aniamtion container. 
/// </summary>
/// 
public class AniamtionContainer
{
	private List<IBaseAnimation> _amList;
	
	
	virtual public void start( AID aid );
	
	public AniamtionContainer()
	{
		_amList = new List<IBaseAnimation>();
	}
	
	public void Clear()
	{
		_amList.Clear();
	}
	
	void addAniamtion( IBaseAnimation am )
	{
		if ( _amList != null )
		{
			_amList.Add( am );
		}
	}
	
	void removeAniamtion( IBaseAnimation am )
	{}
}

