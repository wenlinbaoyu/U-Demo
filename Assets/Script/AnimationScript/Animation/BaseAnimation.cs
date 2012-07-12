using System;
using UnityEditor;
using UnityEngine;

//所有动作的基类
public class BaseAnimation
{
	protected Animation _am = null;
	protected PlayerAnimationInfo _info = null;
	
	//method of start
	virtual public void start(Animation am, PlayerAnimationInfo info )
	{
		_am   = am;
		_info = info;
	}
	
	//method of update
	virtual public void update(){}
	
	//设置动作相应
    virtual public void setAnimationEvent( string animationName, AnimationEvent e )
	{
		AnimationUtility.SetAnimationEvents( _am[animationName].clip, new AnimationEvent[]{e});
	}
	
	//get animationclip time 
	virtual public float animationTime(){ return 0.0f;}
	
	//get animationclip time 
	virtual public float animationTime( string animationName ){ return 0.0f;}
}


