using UnityEngine;
using System.Collections;


public class RoleStatus : MonoBehaviour 
{
	public const string EVENT_UPDATE_HP = "EVENT_UPDATE_HP";
	public const string EVENT_UPDATE_MP = "EVENT_UPDATE_MP";

	public enum Status
	{
		//正常
		STATUS_NOMORL = 0,
		// 中毒
		STATUS_POISON = 1,
		//死亡
		STATUE_DEAD = 2,
	}
	
	[HideInInspector]
	public enum PlayerType
	{
		PLAYER ,
		PLAYER_OTHER,
		NPC,
		ENEMY,
		ROLE_UNKNOWN,
	}
	
	//当前角色是否主角
	[HideInInspector]
	public PlayerType playerType = PlayerType.ROLE_UNKNOWN;
	
	//当前状态
	[HideInInspector]
	public Status roleStatue = Status.STATUS_NOMORL;

	//最大血量
	[HideInInspector]
	public int maxHP = 100;
	
	//最大魔法值
	[HideInInspector]
	public int maxMP = 100;
	
	//当前血量
	[HideInInspector]
	public int curHP = 100;
	
	//当前魔法值
	[HideInInspector]
	public int curMP = 100;
	
	//是否死亡 
	[HideInInspector]
	public bool isDead = false;
	
	//调整当前魔法值
	public void AddjustCurrentHP(int adj){
		curHP += adj;
		
		if (curHP < 0){
			curHP = 0;
		}
		
		if (curHP > maxHP){
			curHP = maxHP;
		}
		Messenger<int,int>.Broadcast(EVENT_UPDATE_HP, curHP, maxHP);
	}
	
	//调整当前魔法值
	public void AddjustCurrentMP(int adj){
		curMP += adj;
		
		if (curMP < 0){
			curMP = 0;
		}
		
		if (curMP > maxMP){
			curMP = maxMP;
		}
		Messenger<int,int>.Broadcast(EVENT_UPDATE_MP, curMP, maxMP);
	}	
}
