using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Animation))]
[RequireComponent (typeof(CharacterController))]
[RequireComponent (typeof(EventManager))]
abstract public class BaseController : MonoBehaviour 
{
	[HideInInspector]
	public CharacterController ccontroller = null;	
	
	[HideInInspector]
	public EventManager eventMgr = null;
	
	//动作管理
	[HideInInspector]
	public AnimationManager mgr = null;
	
	
	//状态机
	[HideInInspector]
	public StateMachine< BaseController > stateMachine = null;		
	
	
	abstract public void DirectionTurn();
	
	abstract public void Move( float x , float z );
	
	abstract public void Down();
	
	abstract public void Jump();
}

