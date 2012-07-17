using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Animation))]
[RequireComponent (typeof(CharacterController))]
public class MainPlayerController : MonoBehaviour 
{
	//内部私有参数
	private Camera mainCamera = null;
	private Transform mainCameraTransform = null;
	
	[HideInInspector]
	public CharacterController ccontroller = null;
	
	private const float groundedDistance = 0.26f;
	public float groundedCheckOffset = -0.23f;
	
	private const float inputThreshold = 0.01f, groundDrag = 5.0f, directionalJumpFactor = 0.7f;
	private bool grounded = false;

	private Vector3 moveDirection = Vector3.zero;
	private float jumpHeight = 0.0f;
	
	//动作管理
	[HideInInspector]
	public AnimationManager mgr = null;
	
	//状态机
	[HideInInspector]
	public StateMachine< MainPlayerController > stateMachine;
	
	//info
	private PlayerAnimationInfo _info = null;
	
	//外部参数
	//走路的速度
	public  float speed = 0.2f;
	//旋转的速度
	public  float trunspeed = 0.0f;
		
	public float gravity = 2.0f;
	
    void Awake()
	{
		//主摄像机
		mainCamera = Camera.main;
		mainCameraTransform = mainCamera.transform;
	}
	
    void Start () 
	{	
		//get CharacterController component
		ccontroller = GetComponent<CharacterController>();
		
		//create player info
		_info = new PlayerAnimationInfo( 1, true );
		_info.setAllHander(typeof(Run), 
						   typeof(Attack), 
						   typeof(Idle), 
						   typeof(Jump), 
			  			   null, 
						   typeof(OtherAnimation));
		
		//get animation manager
		mgr = AnimationMgrFactory.getSingleton().getManager( this.gameObject.name, 
															 this.gameObject.animation,
															  _info );
		Debug.Log( mgr );
		if ( mgr == null )
		{
			Debug.LogError (  this.gameObject.name  + "cann't get some AnimationManager ");
		}
		
		stateMachine = new StateMachine< MainPlayerController >( this );
		Debug.Log( stateMachine );
		if ( stateMachine == null )
		{
			Debug.LogError ( this.gameObject.name   + "cann't get some StateMachine ");
		}
		else
		{
			stateMachine.setCurrentState( IdleState.getIntance() );
		}
	}
	
	void Update () 
	{	
		if ( stateMachine != null)
		{
			stateMachine.update();
		}
		
		/*
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
		
		
		
		ccontroller.Move( moveDirection );
		*/
		//Vector3 movement = rigibodyTransform.forward ;

	}
	
	/*
	void BodyJump( CommentEvent e )
	{
		upfroce = 50;
		EventManager.getSingleton().removeEventListener("Player_JumpUp",  BodyJump );
	}
	*/	
	
	
	void FixedUpdate()
	{
		/*
		grounded = ccontroller.isGrounded;
		_info.isGround = grounded;
	
		if (grounded)
		{
			//rigidbody.drag = groundDrag;
			if ( isMoveKeyDown())
			{
				if ( _info.curState != PlayerAnimationState.ATTACK &&
					 _info.curState != PlayerAnimationState.JUMP )
				{
					_info.curState = PlayerAnimationState.RUN;					
				}
			}
			else if ( Input.GetButtonDown("Jump"))
			{
				EventManager.getSingleton().addEventListener("Player_JumpUp",  BodyJump );
			}
			else
			{
				if ( _info.curState != PlayerAnimationState.ATTACK &&
					 _info.curState != PlayerAnimationState.JUMP )
				{
					_info.curState = PlayerAnimationState.IDLE;				
				}
				
			}
		}
		else
		{
			
			//rigidbody.drag = 0.0f; 
		}
		*/
	}
	
	
	void OnDrawGizmos()
	{
		Gizmos.color = grounded ? Color.blue : Color.red;
		Gizmos.DrawLine ( transform.position + transform.up * -groundedCheckOffset,
		      transform.position + transform.up * -(groundedCheckOffset + groundedDistance));
	}
	
	public void DirectionTurn()
	{
		if ( Input.GetButton("Vertical") || Input.GetButton("Horizontal") )
		{	
			Quaternion mainCameraRotation = Camera.main.transform.rotation;
		
			float vertical_value   = Input.GetAxis("Vertical");
			float horizontal_value = Input.GetAxis("Horizontal");
			float x = Mathf.Abs( horizontal_value );
			float z = Mathf.Abs( vertical_value );
			
			bool is_click = false; //是否按前后键
			float y_angel = mainCameraRotation.eulerAngles.y;
		
			if ( Input.GetButton("Vertical") )
			{
				if ( vertical_value < 0)
				{
					y_angel  = ClampAngle( y_angel - 180, -360, 360);
				}
				is_click = true;
			}
			
			if ( Input.GetButton("Horizontal") )
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
				}
			}
			
			Quaternion rotation = Quaternion.Euler(0, ClampAngle( y_angel, -360, 360), 0);	
			transform.rotation = Quaternion.Slerp(  transform.rotation, rotation, Time.deltaTime * 10.0f );	
		}
	}
	
	public void Move( float x , float z )
	{
		moveDirection.x = x;
		moveDirection.z = z;
		moveDirection = transform.TransformDirection(moveDirection);
		
		if ( ccontroller.isGrounded )
		{
			//moveDirection *= Time.deltaTime* speed;
			moveDirection.x *=  speed;
			moveDirection.z *=  speed;
		}
	
		moveDirection.y -= gravity * Time.deltaTime;
		ccontroller.Move( moveDirection * Time.deltaTime );
	}
	
	
	public void Jump()
	{
		moveDirection.y = 6.0f;
	}
	
	public bool isMoveKeyDown()
	{
		return (isMoveLeftAndRight() || isMoveForAndBack());
	}
	
	public bool isMoveLeftAndRight()
	{
		return ( Input.GetKey( KeyCode.A) || Input.GetKey( KeyCode.D));
	}
	
	public bool isMoveForAndBack()
	{
		return ( Input.GetKey( KeyCode.S) || Input.GetKey( KeyCode.W));		
	}
	
	public void swap( ref float num1, ref float num2 )
	{
		float temp = num1;
		num2 = num1;
		num1 = temp;	
	}
	
	public float ClampAngle( float angle , float min , float max ) 
	{
		if (angle < -360)	angle += 360;
		if (angle > 360) 	angle -= 360;
		return Mathf.Clamp (angle, min, max);
	}
}
