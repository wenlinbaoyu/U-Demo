using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackManager 
{
	//be hit player list
	private List< DamageManager > _attackDamageList = null;
	
	private EventManager _eventMsg = null;
	
	//is hit somebody
	private bool isAttack = false;
	
	// Use this for initialization
	public AttackManager ( EventManager mgr ) 
	{
		_attackDamageList = new List<DamageManager>();
		_attackDamageList.Clear();
		
		_eventMsg = mgr;		
		//regist attack event
		_eventMsg.AddListener( EventManager.EVENT_ATTACK , attackHandler );		
		//regist stop attack eventd
		_eventMsg.AddListener( EventManager.EVENT_STOP_ATTACK , stopAttackHandler );
	}
	
	// Update is called once per frame
	public void Update () 
	{
		if ( isAttack )
		{
			while ( _attackDamageList.Count > 0 )
			{
				DamageManager dm = _attackDamageList[0] as DamageManager;
				dm.applyDamage();
				
				//delete frist item
				_attackDamageList.RemoveAt( 0 );
			}				
		}
	}
	
	
	public void addDamageList( DamageManager mgr )
	{
		if ( mgr == null ) return; 
		_attackDamageList.Add( mgr );
	}
	
	//attack call back function
	private void attackHandler()
	{
		isAttack = true;
	}
	
	//stop attack call back function
	private void stopAttackHandler()
	{
		isAttack = false;
		///_attackDamageList.Clear();
	}
	
}
