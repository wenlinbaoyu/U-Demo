using UnityEngine;
using System.Collections;

public class RoleStatus : MonoBehaviour 
{
	public enum Status
	{
		//正常
		STATUS_NOMORL = 0,
		// 中毒
		STATUS_POISON = 1, 
	}

	[HideInInspector]
	public const int MAX_HP = 100;
	
	[HideInInspector]
	public const int MAX_MP = 100;
	
	//当前状态
	[HideInInspector]
	public Status roleStatue = Status.STATUS_NOMORL;
	
	//当前血量
	[HideInInspector]
	public int _curHP = MAX_HP;
	
	//当前魔法值
	[HideInInspector]
	public int _curMP = MAX_MP;
	
	//是否死亡 
	[HideInInspector]
	public bool isDead = false;
	
}
