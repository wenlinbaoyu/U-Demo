using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour 
{
	private Transform _topTrasnform = null;
	
	// Use this for initialization
	void Start () 
	{
		_topTrasnform = getTopTransform();
		Debug.Log( this.gameObject.name );
	}
	
	private Transform getTopTransform()
	{
		Transform tf = transform;
		while( tf != null )
		{
			tf = tf.parent;
		}
		return tf;
	}
	
	
	
}
