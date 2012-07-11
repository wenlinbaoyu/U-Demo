using System;
using UnityEngine;

//所有动作的基类
public interface IBaseAnimation
{
	//播放animationclip
	void play( Animation am, object args );
	
	//method of update
	void update();
	
	//设置动作相应
    void setAnimationEvent( Animation am, AnimationEvent e );
	
	//get animationclip time 
	float animationTime( Animation am );
}


