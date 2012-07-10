using System;
using UnityEngine;


public class Idle : IBaseAnimation
{	
	private const string ANIMATION_NAME = "1001";
	private const string ANIAMTION_NAME_TBA = "1006";
	private static Idle _instance;
	public static Idle getSingleton()
	{
		if ( _instance == null )
		{
			_instance = new Idle();
		}
		return _instance;
	}
	
	private Idle(){}
	
	//播放animationclip
	public void play( Animation am, object args )
	{
		bool tab = (bool)args;
		string animationName = "";
		if ( tab )
		{
			animationName = ANIAMTION_NAME_TBA;
		}
		else
		{
			animationName = ANIMATION_NAME;
		}
		
		am[ animationName ].layer  = AnimationLayer.LOWEST;
		am[ animationName ].weight = 100;
		am[ animationName ].wrapMode = WrapMode.Loop;
		am.CrossFade( animationName );
	}
	
	//设置动作相应
	public void setAnimationEvent( Animation am, AnimationEvent e ){}
	
	//get animationclip time 
	public float animationTime( Animation am )
	{ return am[ ANIMATION_NAME ].time; }
		
		
	//get animationclip time by normalaize
	public float animationTimeNormalize( Animation am )
	{ return am[ ANIMATION_NAME ].normalizedTime; }
}


