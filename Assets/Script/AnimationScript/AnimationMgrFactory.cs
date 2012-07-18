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
	public AnimationManager getManager( MonoBehaviour mono, PlayerAnimationInfo info )
	{
		AnimationManager mgr = new AnimationManager( mono, info );
		return mgr;
	}
}


