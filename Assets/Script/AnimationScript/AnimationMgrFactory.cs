using System;
using UnityEngine;

/****
 * 
 * AnimationManager的工厂类
 * 
 */

public class AnimationMgrFactory : Singleton<AnimationMgrFactory>
{
	//private AnimationMgrFactory (){}
	public AnimationManager getManager( string playername, Animation animation, PlayerAnimationInfo info )
	{
		AnimationManager mgr = new AnimationManager( playername, animation, info );
		return mgr;
	}
}


