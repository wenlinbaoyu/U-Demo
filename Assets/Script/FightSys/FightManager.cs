using UnityEngine;
using System.Collections;

[RequireComponent (typeof(RoleStatus))]
public class FightManager : MonoBehaviour 
{
	public AttackManager attackMgr = null;
	public DamageManager demageMgr = null;
	
	private RoleStatus _status = null;
	private EventManager _eventMsg = null;
	
	// Use this for initialization
	void Start () 
	{
		_eventMsg = GetComponent<EventManager>();
		_status   = GetComponent<RoleStatus>();
		
		attackMgr = new AttackManager( _eventMsg );
		
		demageMgr = new DamageManager( _eventMsg, _status);
	}
	
	// Update is called once per frame
	void Update () 
	{
		attackMgr.Update();
		demageMgr.Update();
	}
	
	// Update 
	void OnTriggerEnter ( Collider collider )
	{
		Debug.Log("test player OnTriggerEnter ");
		
		if ( collider.tag == "WeaponTag")
		{
			WeaponScript ws = collider.GetComponent<WeaponScript>();
			AttackManager amgr = ws.getPlayerAttackMgr();
			amgr.addDamageList( demageMgr );
		}
	}	
}
