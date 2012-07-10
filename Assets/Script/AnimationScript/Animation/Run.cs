using System;
using UnityEngine;


public class Run : IBaseAnimation
{
	private const string ANIMATION_NAME = "1003";
	private const string ANIMATION_NAME_TAB = "1008";
	private static Run _instance;
	
	private Run(){}		
	public static Run getSingleton()
	{
		if ( _instance == null )
		{
			_instance = new Run();
		}
		return _instance;
	}
	  
	
	//播放animationclip
	public  void play( Animation am, object args )
	{
		string animationName = "";
		bool tab = (bool)args;
		if ( tab )
		{
			animationName = ANIMATION_NAME_TAB;
		}
		else
		{
			animationName = ANIMATION_NAME;
		}
		am[ animationName ].layer    = AnimationLayer.LOWEST;
		am[ animationName ].weight   = 100;
		am[ animationName ].wrapMode = WrapMode.Loop;
		am.CrossFade( animationName );
	}
	
	//设置动作相应
	public void setAnimationEvent(Animation am,  AnimationEvent e ){}
	
	//get animationclip time 
	public float animationTime( Animation am ){ return 0.0f; }
		
}


