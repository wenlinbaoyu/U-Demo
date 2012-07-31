using System;
using UnityEngine;

//AI Base Class
public class AI
{
	public enum Situation
	{
		AI_SITUATION_HEIGH , 
		AI_SITUATION_NORMAL,
		AI_SITUATION_LOWER ,
		AI_SITUATION_NULL ,
	}
	
	//the target object
	protected  GameObject _target = null ;
	
	public AI (){}
	
	//search for enemy
	virtual public bool search( GameObject obj ) { return false; }
	
	//judge situation from targe object 
	virtual public Situation GetSituation( GameObject obj){ return AI_SITUATION_NULL; }
	
}

