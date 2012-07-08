using System;
using UnityEngine;

public class Jump : AniamtionContainer, IBaseAnimation
{
	//private const string ANIMATION_NAME = "1019";
	public Jump(){}
	
	public void start( AID aid )
	{
		//addAniamtion( new Jump_sub( "1019"));
		//addAniamtion( new Jump_sub( "1020"));
		//addAniamtion( new Jump_sub( "1021"));
		//addAniamtion( new Jump_sub( "1022"));
	}
	
	//播放animationclip
	public  void play( Animation am, object args )
	{
		realPlay( am );
	}
	
	public void realPlay( Animation am )
	{
		//am[ ANIMATION_NAME ].weight   = 100;
		//am[ ANIMATION_NAME ].layer    = AnimationLayer.NORMAL;
		//am[ ANIMATION_NAME ].wrapMode = WrapMode.Once;
		//am.CrossFade( ANIMATION_NAME );
	}
	
	//设置动作相应
	public void setAnimationEvent( Animation am, AnimationEvent e )
	{
		
	}
	
	//get animationclip time 
	public float animationTime( Animation am ){ return 0.0f; }
		
		
	//get animationclip time by normalaize
	public float animationTimeNormalize( Animation am ){ return 0.0f; }
	
	public void addAniamtion( IBaseAnimation am )
	{
		
	}
	
	public void removeAniamtion( IBaseAnimation am )
	{
		
	}
}


public class Jump_sub : IBaseAnimation
{
	private string _aType;
	public Jump_sub( AID aid  )
	{
		//_aType = aType;
		///am[ _aType ].weight   = weight;
		//am[ _aType ].layer    = layer;
		//am[ _aType ].wrapMode = wrapMode;
	}
	
	//播放animationclip 
	public  void play( Animation am, object args )
	{
		realPlay( am );
	}
	
	public void realPlay( Animation am )
	{
		am.CrossFade( _aType );
	}
	
	//设置动作相应
	public void setAnimationEvent( Animation am, AnimationEvent e ){}
	
	//get animationclip time 
	public float animationTime( Animation am ){ return 0.0f; }
		
	//get animationclip time by normalaize
	public float animationTimeNormalize( Animation am ){ return 0.0f; }
	
}
