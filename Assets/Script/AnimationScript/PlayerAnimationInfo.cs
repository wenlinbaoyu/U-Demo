using System;
using System.Collections;
using UnityEngine;

public class PlayerAnimationInfo
{
	private int _playerId;
	private Hashtable _animationIndex = null;
	private Hashtable _animationState = null;
	//private Hashtable _animationProperty = null;
	private Hashtable _animationHandler = null;
	private bool _isPlayer = false;

	public PlayerAnimationInfo ( int id , bool isPlayer )
	{
		_playerId = id;
		_isPlayer = isPlayer;
		
		init();
		initAnimationState();
	}
	
	public int id
	{
		get{ return _playerId;}
	}
	
	public bool isPlayer
	{
		get{ return _isPlayer;}
	}	
	
	public Hashtable animations
	{
		get{ return _animationIndex;}
	}
	
	public string getAniamtionID( string name )
	{
		if ( _animationIndex == null ) return "";
		if ( _animationIndex.ContainsKey(name) )
		{
			return (string)_animationIndex[name];
		}
		else
		{
			return "";
		}
	}
	
	public void setAllHander( Type run, Type attack, Type idle, Type jump , Type shortcut, Type other )
	{
		_animationHandler = new Hashtable();
		
		if ( run != null ) 		_animationHandler.Add( "runHandler", run );
		if ( attack != null ) 	_animationHandler.Add( "attackHandler", attack );
		if ( idle != null ) 	_animationHandler.Add( "idleHandler", idle );
		if ( jump != null ) 	_animationHandler.Add( "jumpHandler", jump );
		if ( shortcut != null ) _animationHandler.Add( "shortcutHandler", shortcut );
		if ( other != null ) 	_animationHandler.Add( "otherHandler", other );
	}	
	
	public bool hasHandler( string handlername )
	{
		if ( _animationHandler == null ) return false;
		return ( _animationHandler.ContainsKey(handlername));
	}
	
	public Type getHandler( string handlername )
	{
		if ( _animationHandler == null ) return null;
		return _animationHandler[handlername] as Type;
	}
	
	/*
	public AnimationProperty getAnimationProperty( string name )
	{
		if ( _animationProperty == null ) return null;
		if ( _animationProperty.ContainsKey(name) )
		{
			return _animationProperty[name] as AnimationProperty;
		}
		else
		{
			return null;
		}
	}
	*/
	
	public object getAnimationState( string state )
	{
		if ( !_animationState.ContainsKey(state) ) return null;
		return _animationState[state];
	}
	
	public void setAnimationState( string state, object obj )
	{
		if ( !_animationState.ContainsKey(state) ) return;
		_animationState[state] = obj;
	}
	
	private void initAnimationState()
	{
		_animationState = new Hashtable();
		
		_animationState.Add( "isTab", false );
		
		_animationState.Add( "isGround", true);
		
		_animationState.Add( "jumpState", JumpType.JUMP_NULL );
		
		_animationState.Add( "attackNum", 0);
	}
	
	private void init()
	{
		_animationIndex = new Hashtable();
		_animationProperty = new Hashtable();
	
		//animation number		
		//1 待机*  id:1001
		_animationIndex.Add("idle", "1001");
		//_animationProperty.Add("idle", new AnimationProperty(WrapMode.Loop, AnimationLayer.LOWEST, 100));
		
		
		//2 走路*            21-53     	id:1002
		//_animationIndex.Add("idle", "1001");
		
		//3 跑步-正* (拿剑)  54-74     	id:1003
		_animationIndex.Add("run", "1003");
		//_animationProperty.Add("run", new AnimationProperty(WrapMode.Loop, AnimationLayer.LOWEST, 100));
		
		//4 跑步-左*(拿剑)   75-95     	id:1004
		_animationIndex.Add("run_left", "1004");
		//_animationProperty.Add("run_left", new AnimationProperty(WrapMode.Loop, AnimationLayer.LOWEST, 100));
		
		//5 跑步-右*(拿剑)   96-116   	id:1005
		_animationIndex.Add("run_right", "1005");
		//_animationProperty.Add("run_right", new AnimationProperty(WrapMode.Loop, AnimationLayer.LOWEST, 100));
		
		//6 待机 ( 收剑待机) 547-577	id:1006
		_animationIndex.Add("idle_tab", "1006");
		//_animationProperty.Add("idle_tab", new AnimationProperty(WrapMode.Loop, AnimationLayer.LOWEST, 100));
		
		//7 走路             117-149	id:1007 
		_animationIndex.Add("walk", "1007");
		//_animationProperty.Add("walk", new AnimationProperty(WrapMode.Loop, AnimationLayer.LOWEST, 100));
		
		//8 跑步-正(收剑)    150-170	id:1008
		_animationIndex.Add("run_tab", "1008");
		//_animationProperty.Add("run_tab", new AnimationProperty(WrapMode.Loop, AnimationLayer.LOWEST, 100));
		
		//9 跑步-左(收剑)    171-191	id:1009
		_animationIndex.Add("run_left_tab", "1009");
		//_animationProperty.Add("run_left_tab", new AnimationProperty(WrapMode.Loop, AnimationLayer.LOWEST, 100));
		
		//10 跑步-右(收剑)   192-212	id:1010
		_animationIndex.Add("run_right_tab", "1010");
		//_animationProperty.Add("run_right_tab", new AnimationProperty(WrapMode.Loop, AnimationLayer.LOWEST, 100));
		
		//11 收起武器~       250-270	id:1011
		_animationIndex.Add("shoujian", "1011");
		//_animationProperty.Add("shoujian", new AnimationProperty(WrapMode.Once, AnimationLayer.NORMAL, 100));
				
		//12 拔出武器~       270-290	id:1012
		_animationIndex.Add("bajian", "1012");
		//_animationProperty.Add("bajian", new AnimationProperty(WrapMode.Once, AnimationLayer.NORMAL, 100));
		
		//13 受击~           291-307	id:1013
		_animationIndex.Add("hit", "1013");		
		//14 死亡~           308-368	id:1014
		_animationIndex.Add("dead", "1014");
		
		//15 普通攻击（单击）*   369-404	  id:1015
		_animationIndex.Add("attack", "1015");
		//_animationProperty.Add("attack", new AnimationProperty(WrapMode.Once, AnimationLayer.NORMAL, 100));
		
		_animationIndex.Add("attack_shou", "10151");
		//_animationProperty.Add("attack_shou", new AnimationProperty(WrapMode.Once, AnimationLayer.NORMAL, 100));
		
		//16 连续攻击（连击两次）*   405-427  id:1016
		_animationIndex.Add("attack_double", "1016");
		//_animationProperty.Add("attack_double", new AnimationProperty(WrapMode.Once, AnimationLayer.NORMAL, 100));
		
		_animationIndex.Add("attack_double_shou", "10161");
		//_animationProperty.Add("attack_double_shou", new AnimationProperty(WrapMode.Once, AnimationLayer.NORMAL, 100));
		
		//17 甩剑攻击 *      428-495	id:1017
		_animationIndex.Add("sp_1", "1017");
		//18 旋转攻击 *      496-546      id:1018
		_animationIndex.Add("sp_2", "1018");
		
		//19 跳跃 - 预动作   213-222	id:1019
		_animationIndex.Add("jump_begin", "1019");
		//_animationProperty.Add("jump_begin", new AnimationProperty(WrapMode.Once, AnimationLayer.NORMAL, 100));
		
		//20 跳跃 - 离地到最高点    222-229	id:1020
		_animationIndex.Add("jump_up", "1020");
		//_animationProperty.Add("jump_up", new AnimationProperty(WrapMode.Once, AnimationLayer.NORMAL, 100));
		
		//21 跳跃 - 落下     	229-233		id:1021
		_animationIndex.Add("jump_down", "1021");
		//_animationProperty.Add("jump_down", new AnimationProperty(WrapMode.ClampForever, AnimationLayer.NORMAL, 100));
		
		//22 跳跃 - 着地回到待机    233-249	id:1022
		_animationIndex.Add("fall", "1022");
		//_animationProperty.Add("fall", new AnimationProperty(WrapMode.Once, AnimationLayer.NORMAL, 100));
	}
}

/*
public class AnimationProperty
{
	public WrapMode mode;
	public int layer;
	public int weight;
	
	public AnimationProperty ( WrapMode mode, int layer,  int weight )
	{
		this.mode  = mode;
		this.layer = layer;
		this.weight = weight;
	}
}
*/


public class JumpType
{
	public static int JUMP_BEGIN = 1;
	public static int JUMP_UP    = 2;
	public static int JUMP_DOWN  = 3;
	public static int JUMP_FALL  = 4;
	public static int JUMP_NULL  = 5;
}