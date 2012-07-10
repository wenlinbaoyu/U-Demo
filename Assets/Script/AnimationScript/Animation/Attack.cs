using System;
using UnityEngine;

public class Attack : AniamtionContainer, IBaseAnimation
{	
	//播放animationclip
	override public void start( AID aid )
	{
 		string[] array = (string[])aid.getArray("subanimationNumber");

		for ( int i = 0; i < array.Length ; i ++ )
		{
			SubAniamtion subAm = new SubAniamtion( array[i] );
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


