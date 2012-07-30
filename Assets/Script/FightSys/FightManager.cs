using UnityEngine;
using System.Collections;

[RequireComponent (typeof(RoleStatus))]
public class FightManager : MonoBehaviour 
{
	public AttackManager attackMgr = null;
	public DamageManager demageMgr = null;
	
	private RoleStatus _status = null;
	private EventManager _eventMsg = null;
	private BaseController _controller = null;
	// Use this for initialization
	void Start () {}
	
	public void init( BaseController controller )
	{
		_eventMsg = GetComponent<EventManager>();
		_status   = GetComponent<RoleStatus>();
		_controller = controller;
		
		attackMgr = new AttackManager( _eventMsg );
		
		demageMgr = new DamageManager( _eventMsg, _status, _controller);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ( attackMgr != null ) attackMgr.Update();
		if ( demageMgr != null ) demageMgr.Update();
	}
	
	// Update 
	void OnTriggerEnter ( Collider collider )
	{
		//Debug.Log( this.gameObject.name + "test player OnTriggerEnter ");
		
		if ( collider.tag == "WeaponTag")
		{
			if ( _controller == null ) return ;
			
			
			//if player is death , then do nothng and return
			if ( _status != null && _status.roleStatue == RoleStatus.Status.STATUE_DEAD) return;
			
			WeaponScript ws = collider.GetComponent<WeaponScript>();
			AttackManager amgr = ws.getPlayerAttackMgr();
			amgr.addDamageList( demageMgr );
		}
	}	
}
