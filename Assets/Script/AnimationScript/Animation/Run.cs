using System;
using UnityEngine;


public class Run : IBaseAnimation
{
	private const string ANIMATION_NAME = "1003";
	
	private static Run _instance;
	public static Run getSingleton()
	{
		if ( _instance == null )
		{
			_instance = new Run();
		}
		return _instance;
	}
	
	private Run(){}	
	
	
	//播放animationclip
	public  void play( Animation am, object args )
	{
		realPlay( am );
	}
	
	public void realPlay( Animation am )
	{
		am[ ANIMATION_NAME ].layer    = AnimationLayer.LOWEST;
		am[ ANIMATION_NAME ].weight   = 100;
		am[ ANIMATION_NAME ].wrapMode = WrapMode.Loop;
		am.CrossFade( ANIMATION_NAME );
	}	
	
	//设置动作相应
	public void setAnimationEvent(Animation am,  AnimationEvent e ){}
	
	//get animationclip time 
	public float animationTime( Animation am ){ return 0.0f; }
		
	//get animationclip time by normalaize
	public float animationTimeNormalize( Animation am ){ return 0.0f; }
}


