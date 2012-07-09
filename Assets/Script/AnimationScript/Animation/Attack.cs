using System;
using UnityEngine;

public class Attack : IBaseAnimation
{
	private const string ANIMATION_NAME = "1013";
	
	private static Attack _instance;
	public static Attack getSingleton()
	{
		if ( _instance == null )
		{
			_instance = new Attack();
		}
		return _instance;
	}
	
	private Attack(){}
	
	//播放animationclip
	public  void play( Animation am, object args )
	{
		realPlay( am );
	}
	
	public void realPlay( Animation am )
	{
		am[ ANIMATION_NAME ].weight   = 100;
		am[ ANIMATION_NAME ].layer    = AnimationLayer.NORMAL;
		am[ ANIMATION_NAME ].wrapMode = WrapMode.Once;
		am.CrossFade( ANIMATION_NAME );
	}
	
	//设置动作相应
	public void setAnimationEvent( Animation am, AnimationEvent e )
	{
		
	}
	
	//get animationclip time 
	public float animationTime( Animation am ){ return 0.0f; }
		
		
	//get animationclip time by normalaize
	public float animationTimeNormalize( Animation am){ return 0.0f; }
}


