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
	
	public IBaseAnimation getAnimation( AID aid )
	{
		return _table[ aid.id ] as IBaseAnimation ;
	}
	
	private void initAnimation() 
	{
		/****
		 * 
		 * 所有的动作都在再这里注册
		 * 
		 */
		_table = new Hashtable();
		_table.Add("attack", Attack.getSingleton());
		_table.Add("jump", Jump.getSingleton());
		_table.Add("run", Run.getSingleton());
		_table.Add("idle", Idle.getSingleton());
	}
}


