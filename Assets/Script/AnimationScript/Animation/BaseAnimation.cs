using System;
using UnityEditor;
using UnityEngine;

//所有动作的基类
public class BaseAnimation
{
	protected BaseController _controller = null;
	protected Animation _am = null;
	protected PlayerAnimationInfo _info = null;
	
	//method of start
	virtual public void start(BaseController controller, PlayerAnimationInfo info )
	{
		_controller = controller;
		_am   = controller.animation;
		_info = info;
	}
	
	virtual public void enter(){}
	
	virtual public void exit(){}
	
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


