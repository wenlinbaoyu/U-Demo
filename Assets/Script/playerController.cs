using UnityEngine;
using System.Collections;


[RequireComponent (typeof(Animation))]
[RequireComponent (typeof(ProxyAnimationEvent))]
public class playerController : MonoBehaviour 
{
	
	//public custom_inputs inputManager;
	
	//内部私有参数
	private Camera mainCamera = null;
	private Transform mainCameraTransform = null;
	//private Transform rigibodyTransform = null;
	
	private CharacterController _controller = null;
	private const float groundedDistance = 0.26f;
	public float groundedCheckOffset = -0.23f;
	
	private const float inputThreshold = 0.01f, groundDrag = 5.0f, directionalJumpFactor = 0.7f;
	//private bool isTab = false;
	private bool grounded = false;
	
	private Quaternion rotation  = Quaternion.identity;	

	//动作管理
	private AnimationManager _mgr = null;
	
	private float upfroce = 0.0f;
	//info
	private PlayerAnimationInfo _info = null;
	//外部参数
	//走路的速度
	public  float speed = 0.2f;
	//旋转的速度
	public  float trunspeed = 0.0f;
	
	public float jumpSpeed = 2.0f;
	
	public float gravity = 2.0f;
	
    void Awake()
	{
		//主摄像机
		mainCamera = Camera.main;
		mainCameraTransform = mainCamera.transform;
	}
	
    void Start () 
	{	
		//create player info
		_info = new PlayerAnimationInfo( 1, true );
		_info.setAllHander(typeof(Run), typeof(Attack), typeof(Idle), typeof(Jump), null, null );
		
		//get animation manager
		_mgr = AnimationMgrFactory.getSingleton().getManager( this.gameObject.name, 
															  this.gameObject.animation,
															  _info );
		
		Debug.Log( _mgr );
		if ( _mgr == null )
		{
			Debug.LogError ( " this.gameObject.name cann't get some AnimationManager ");
		}
		
		
		_controller = GetComponent<CharacterController>();
	}
	
	void OnGUI()
	{}
	
	
	void Update () 
	{	
		bool turnDirection = false;
		Quaternion mainCameraRotation = mainCameraTransform.rotation;
	
		float vertical_value   = Input.GetAxis("Vertical");
		float horizontal_value = Input.GetAxis("Horizontal");
		float x = Mathf.Abs( horizontal_value );
		float z = Mathf.Abs( vertical_value );
		
		if( isMoveKeyDown() && _info.curState == PlayerAnimationState.RUN )
		{
			bool is_click = false; //是否按前后键
			float y_angel = mainCameraRotation.eulerAngles.y;
		
			if ( isMoveForAndBack() )
			{
				if ( vertical_value < 0)
				{
					y_angel  = ClampAngle( y_angel - 180, -360, 360);
				}
				is_click = true;
			}
			
			if ( isMoveLeftAndRight() )
			{
				if ( is_click )
				{
					//向前方向
					if( vertical_value > 0)
					{
						y_angel = y_angel + (horizontal_value > 0 ? 1 : -1)*45;
					}
					
					//向后方向
					else
					{
						y_angel = y_angel - (horizontal_value > 0 ? 1 : -1)*45;
					}
				}
				else
				{
					y_angel = y_angel + (horizontal_value > 0 ? 1 : -1)* 90;
					swap( ref x, ref z );
				}
			}
			turnDirection = true;
			rotation = Quaternion.Euler(0, ClampAngle( y_angel, -360, 360), 0);	
		}
		else
		{
			z = 0;
		}
				
		if ( mainCamera != null && turnDirection )
		{
			transform.rotation = Quaternion.Slerp(  transform.rotation, rotation, Time.time * trunspeed);		
		}

		Vector3 moveDirection = new Vector3(0, 0, z);
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= Time.deltaTime* speed;
	
		if ( upfroce > 0.0f )
		{
			moveDirection.y += (upfroce - gravity) * Time.deltaTime;
			upfroce = upfroce - gravity;
		}
		else
		{
			moveDirection.y -= gravity * Time.deltaTime;
		}
		
		
		
		_controller.Move( moveDirection );
		
		//Vector3 movement = rigibodyTransform.forward ;
		_mgr.update();
	}
	
	void BodyJump( CommentEvent e )
	{
		upfroce = 50;
		EventManager.getSingleton().removeEventListener("Player_JumpUp",  BodyJump );
	}	
	
	
	void FixedUpdate()
	{
		grounded = _controller.isGrounded;
		_info.isGround = grounded;
	
		if (grounded)
		{
			//rigidbody.drag = groundDrag;
			if ( isMoveKeyDown())
			{
				if ( _info.curState != PlayerAnimationState.ATTACK &&
					 _info.curState != PlayerAnimationState.JUMP)
					_info.curState = PlayerAnimationState.RUN;
				//Vector3 moveDirection = new Vector3( Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
				//rigidbody.AddForce( moveDirection.normalized * speed ,ForceMode.VelocityChange );
			}
			else if (Input.GetButtonDown("Jump"))
			{
				EventManager.getSingleton().addEventListener("Player_JumpUp",  BodyJump );
			}
			else
			{
				if ( _info.curState != PlayerAnimationState.ATTACK &&
					 _info.curState != PlayerAnimationState.JUMP)
				{
					_info.curState = PlayerAnimationState.IDLE;				
				}
				
			}
		}
		else
		{
			
			//rigidbody.drag = 0.0f; 
		}
	}
	
	
	void OnDrawGizmos()
	{
		//Gizmos.color = grounded ? Color.blue : Color.red;
		//Gizmos.DrawLine ( rigidbody.transform.position + rigidbody.transform.up * -groundedCheckOffset,
		//	rigidbody.transform.position + rigidbody.transform.up * -(groundedCheckOffset + groundedDistance));
	}
	
	private bool isMoveKeyDown()
	{
		return (isMoveLeftAndRight() || isMoveForAndBack());
	}
	
	private bool isMoveLeftAndRight()
	{
		return ( Input.GetKey( KeyCode.A) || Input.GetKey( KeyCode.D));
	}
	
	private bool isMoveForAndBack()
	{
		return ( Input.GetKey( KeyCode.S) || Input.GetKey( KeyCode.W));		
	}
	
	private void swap( ref float num1, ref float num2 )
	{
		float temp = num1;
		num2 = num1;
		num1 = temp;	
	}
	
	private float ClampAngle( float angle , float min , float max ) 
	{
		if (angle < -360)	angle += 360;
		if (angle > 360) 	angle -= 360;
		return Mathf.Clamp (angle, min, max);
	}
}
