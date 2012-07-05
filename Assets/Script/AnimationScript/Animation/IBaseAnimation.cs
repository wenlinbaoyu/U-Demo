using System;
using UnityEngine;

//所有动作的基类
public interface IBaseAnimation
{
	//播放animationclip
	void play( Animation am );
	
	//真正播放的函数， 这个函数不应该由外部调用， 
	//而是又继承IBaseAniamtion的派生类之间的
	void realPlay( Animation am );
		
	//设置动作相应
    void setAnimationEvent( Animation am, AnimationEvent e );
	
	//get animationclip time 
	float animationTime( Animation am );
	
	//get animationclip time by normalaize
    float animationTimeNormalize( Animation am );
}


