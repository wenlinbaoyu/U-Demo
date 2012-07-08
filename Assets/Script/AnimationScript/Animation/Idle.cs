using System;
using UnityEngine;


public class Idle : Singleton<Idle>, IBaseAnimation
{
	private const string ANIMATION_NAME = "1001";
	
	//播放animationclip
	public void play( Animation am, object args )
	{
		realPlay( am );
	}
	
	private void realPlay( Animation am )
	{
		am[ ANIMATION_NAME ].layer  = AnimationLayer.LOWEST;
		am[ ANIMATION_NAME ].weight = 100;
		am[ ANIMATION_NAME ].wrapMode = WrapMode.Loop;
		am.CrossFade( ANIMATION_NAME );
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


