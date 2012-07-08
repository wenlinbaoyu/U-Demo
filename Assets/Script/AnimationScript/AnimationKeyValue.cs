using System;
using System.Collections;
using System.Collections.Generic;


public class AnimationKeyValue : Singleton<AnimationKeyValue>
{
	private Hashtable _table = null;
	public AnimationKeyValue ()
	{
		initAnimation();
	}
	
	public Type getAnimation( AID aid )
	{
		return _table[ aid.id ] as Type ;
	}
	
	private void initAnimation() 
	{
		/****
		 * 
		 * 所有的动作都在这里注册
		 * 
		 */
		
		
		_table = new Hashtable();
		_table.Add("attack", typeof(Attack));
		_table.Add("jump", 	 typeof(Jump));
		_table.Add("run", 	 typeof(Run));
		_table.Add("idle", 	 typeof(Idle));
	}
}


