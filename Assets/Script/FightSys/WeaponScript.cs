using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour 
{
	private Transform _topTrasnform = null;
	
	// Use this for initialization
	void Start () 
	{
		_topTrasnform = getTopTransform();
		
		MainPlayerController control = _topTrasnform.GetComponent<MainPlayerController>();
		control.weaponTransform = transform;
		
		Debug.Log( this.gameObject.name );
	}
	
	private Transform getTopTransform()
	{
		Transform tf = transform;
		while( tf.parent != null )
		{
			tf = tf.parent;
		}
		return tf;
	}
	
	public AttackManager getPlayerAttackMgr( )
	{
		if ( _topTrasnform != null )
		{
			FightManager com = _topTrasnform.GetComponent<FightManager>();
			return com.attackMgr;
		}
		
		return null;
	}
	
	public DamageManager getPlayerDamageMgr( )
	{
		FightManager com = _topTrasnform.GetComponent<FightManager>();
		return com.demageMgr;
	}	
}
