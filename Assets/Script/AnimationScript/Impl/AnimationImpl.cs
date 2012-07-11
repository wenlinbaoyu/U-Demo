using System;
using UnityEngine;

public class AnimationImpl : Singleton<AnimationImpl>
{
	public AnimationImpl (){}
	
	public List<SubAniamtion> getAnimationList( AID aid )
	{
		string [] number = (string [])aid.getArray("subanimationNumber");
		
		if ( number != null )
		{
			for
		}
	}
}

