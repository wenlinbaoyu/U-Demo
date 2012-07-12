using System;
using System.Collections;

public class PlayerAnimationInfo
{


	private int _playerId;
	private Hashtable _aniamtionIndex = null;
	private Hashtable _animationHandler = null;
	
	public PlayerAnimationState curState;
	public bool isGround = true;
	public bool isTab = false;
	private bool _isPlayer = false;

	public PlayerAnimationInfo ( int id , bool isPlayer )
	{
		_playerId = id;
		_isPlayer = isPlayer;
		init(); 
	}
	
	public string getAniamtionID( string name )
	{
		if ( _aniamtionIndex == null ) return "";
		return (string)_aniamtionIndex[name];
	}
	
	public int id
	{
		get{ return _playerId;}
	}
	
	public bool isPlayer
	{
		get{ return _isPlayer;}
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
		return ( _animationHandler[handlername] != null );
	}
	
	public Type getHandler( string handlername )
	{
		if ( _animationHandler == null ) return null;
		return _animationHandler[handlername] as Type;
	}
	
	
	private void init()
	{
		_aniamtionIndex = new Hashtable();
		
		//animation number		
		//1 待机*  id:1001
		_aniamtionIndex.Add("idle", "1001");
		//2 走路*            21-53     	id:1002
		//_aniamtionIndex.Add("idle", "1001");		
		//3 跑步-正* (拿剑)  54-74     	id:1003
		_aniamtionIndex.Add("run", "1003");
		//4 跑步-左*(拿剑)   75-95     	id:1004
		_aniamtionIndex.Add("run_left", "1004");		
		//5 跑步-右*(拿剑)   96-116   	id:1005
		_aniamtionIndex.Add("run_right", "1005");		
		//6 待机 ( 收剑待机) 547-577	id:1006
		_aniamtionIndex.Add("idle_tab", "1006");
		//7 走路             117-149	id:1007 
		_aniamtionIndex.Add("walk", "1007");		
		//8 跑步-正(收剑)    150-170	id:1008
		_aniamtionIndex.Add("run_tab", "1008");		
		//9 跑步-左(收剑)    171-191	id:1009
		_aniamtionIndex.Add("run_left_tab", "1009");		
		//10 跑步-右(收剑)   192-212	id:1010
		_aniamtionIndex.Add("run_right_tab", "1010");		
		//11 收起武器~       250-270	id:1011
		_aniamtionIndex.Add("shoujian", "1011");				
		//12 拔出武器~       270-290	id:1012
		_aniamtionIndex.Add("bajian", "1012");		
		//13 受击~           291-307	id:1013
		_aniamtionIndex.Add("hit", "1013");		
		//14 死亡~           308-368	id:1014
		_aniamtionIndex.Add("dead", "1014");
		//15 普通攻击（单击）*   369-404	  id:1015
		_aniamtionIndex.Add("attack", "1015");
		_aniamtionIndex.Add("attack_shou", "10151");
		
		//16 连续攻击（连击两次）*   405-427  id:1016
		_aniamtionIndex.Add("attack_double", "1016");
		_aniamtionIndex.Add("attack_double_shou", "10161");
		//17 甩剑攻击 *      428-495	id:1017
		_aniamtionIndex.Add("sp_1", "1017");
		//18 旋转攻击 *      496-546      id:1018
		_aniamtionIndex.Add("sp_2", "1018");
		//19 跳跃 - 预动作   213-222	id:1019
		_aniamtionIndex.Add("jump_begin", "1019");
		//20 跳跃 - 离地到最高点    222-229	id:1020
		_aniamtionIndex.Add("jump_up", "1020");
		//21 跳跃 - 落下     	229-233		id:1021
		_aniamtionIndex.Add("jump_down", "1021");
		//22 跳跃 - 着地回到待机    233-249	id:1022
		_aniamtionIndex.Add("fall", "1022");
		//
		
		//set animation state
		curState = PlayerAnimationState.IDLE;
	}
}

