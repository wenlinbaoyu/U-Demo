using System;
using UnityEngine;

public class Shoujian : AniamtionContainer, IBaseAnimation
{
	//private bool _isPlaying = false;
	override public void start( AID aid )
	{
 		string[] array = (string[])aid.getArray("subanimationNumber");
		for ( int i = 0; i < array.Length ; i ++ )
		{
			SubAniamtion subAm = new SubAniamtion( array[i] );			
			subAm.setNextHandler( this.nextAnimation );
			addAniamtion( subAm );
		}
	}
	
	
	//播放animationclip
	public void play( Animation am, object args )
	{
		this.playeList( am ); 
	}
	
	//设置动作相应
	public void setAnimationEvent( Animation am, AnimationEvent e ){}
	
	//get animationclip time 
	public float animationTime( Animation am ){ return 0.0f; }
		
	//get animationclip time by normalaize
	public float animationTimeNormalize( Animation am ){ return 0.0f; }
}


