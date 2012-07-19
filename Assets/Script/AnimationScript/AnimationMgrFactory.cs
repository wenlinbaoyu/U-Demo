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
	public AnimationManager getManager( BaseController controller, PlayerAnimationInfo info )
	{
		AnimationManager mgr = new AnimationManager( controller, info );
		return mgr;
	}
}


