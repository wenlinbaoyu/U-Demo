using System;
using UnityEngine;
using System.Collections;
using System.Reflection;
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
		Type type = _table[ aid.id ] as Type;
		if ( type.BaseType == typeof(AniamtionContainer))
		{
			object am = Activator.CreateInstance( type );
			if ( am == null ) return null;
			( am as AniamtionContainer ).start( aid );
			return am as IBaseAnimation;
		}
		else
		{
			MethodInfo method = type.GetMethod( "getSingleton", BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Instance|BindingFlags.Static);
			if ( method == null ) return null;
			
			try
			{
				return ( method.Invoke( null, null ) as IBaseAnimation ); 				
			}
			catch( Exception )
			{
				Debug.LogError(" get method error ");
				return null;
			}
		}
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
		_table.Add("run", 	 typeof(Run));
		_table.Add("idle", 	 typeof(Idle));
		_table.Add("jump", 	 typeof(Jump));
		_table.Add("shoujian", typeof(Shoujian));
		_table.Add("bajian",   typeof(Bajian));
		
	}
}


