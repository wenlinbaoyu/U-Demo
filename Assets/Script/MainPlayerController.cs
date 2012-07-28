using UnityEngine;
using System.Collections;


public class MainPlayerController : BaseController 
{
	private const float groundedDistance = 0.26f;
	private const float inputThreshold = 0.01f;
	private const float groundDrag = 5.0f;
	private const float directionalJumpFactor = 0.7f;
	
	
	//内部私有参数
	private Camera mainCamera = null;
	private Transform mainCameraTransform = null;
	private bool grounded = false;
	private Vector3 moveDirection = Vector3.zero;
	private float jumpHeight = 6.0f;
	private PlayerAnimationInfo _info = null;
		
	//走路的速度
	public float speed = 0.2f;
	//旋转的速度
	public float trunspeed = 0.0f;
	//重力
	public float gravity = 2.0f;
	//
	public float groundedCheckOffset = -0.23f;	
	
	public WeaponTrail weaponTrial;
	
	private WeaponTrailAnimation weaponTrailAnimation;
	
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
		
		//init event manager
		eventMgr = GetComponent<EventManager>();
		Debug.Log( eventMgr );
		if ( eventMgr == null )
		{
			Debug.LogError ( this.gameObject.name   + "cann't get some event manager ");
		}		
		
		
		//create player animation info
		_info = new PlayerAnimationInfo( 1, true );
		_info.setAllHander(typeof(Run), 
						   typeof(Attack), 
						   typeof(Idle), 
						   typeof(Jump), 
			  			   null, 
						   typeof(OtherAnimation));
		
		//get animation manager
		mgr = AnimationMgrFactory.getSingleton().getManager( this,  _info );
		Debug.Log( mgr );
		if ( mgr == null )
		{
			Debug.LogError (  this.gameObject.name  + "cann't get some AnimationManager ");
		}
		
		//state machine
		stateMachine = new StateMachine< BaseController >( this );
		Debug.Log( stateMachine );
		if ( stateMachine == null )
		{
			Debug.LogError ( this.gameObject.name   + "cann't get some StateMachine ");
		}
		else
		{
			stateMachine.setGlobalState( GlobalState.getInstance());
			stateMachine.setCurrentState( IdleState.getIntance() );
		}
		
		

		
		weaponTrial.SetTime(0.0f, 0, 1);
		
		weaponTrailAnimation = new WeaponTrailAnimation();
		weaponTrailAnimation.weaponTrial = weaponTrial;
	}
	
    protected float t = 0.033f;
	protected float timeScale = 1; // This is here for personal time distortion... like freeze spells that slow enemies... (changing this affects the animation rate)
    
	void Update () 
	{	
		if ( stateMachine != null)
		{
			stateMachine.update();
		}
		
		if (Input.GetKeyDown(KeyCode.J)){
			Debug.Log("fadeOut");
			weaponTrial.FadeOut(0.5f);  // Fades the trail in				
		}if (Input.GetKeyDown(KeyCode.K)){
			Debug.Log("clearTrail");
			weaponTrial.ClearTrail();
		}else if(Input.GetMouseButton(0)){
			weaponTrial.SetTime(2.1f, 0, 1);
			//Debug.Log("fadeIn");
			weaponTrial.StartTrail(0.5f, 0.4f);  // Fades the trail in
		}
		
		t = Mathf.Clamp (Time.deltaTime * timeScale, 0, 0.066f);
		//
		
		if ( weaponTrailAnimation != null )
		{
			weaponTrailAnimation.SetDeltaTime (t); // Sets the delta time that the animationController uses.
		}
	}
	
	
	void OnTriggerEnter ( Collider collider )
	{
		Debug.Log("main player OnTriggerEnter ");
		Debug.Log("name : " + collider.name );
	}		
	
	void OnDrawGizmos()
	{
		/*
		Gizmos.color = grounded ? Color.blue : Color.red;
		Gizmos.DrawLine ( transform.position + transform.up * -groundedCheckOffset,
		      transform.position + transform.up * -(groundedCheckOffset + groundedDistance));
		*/
	}
	
	protected virtual void LateUpdate ()
	{
		weaponTrailAnimation.LateUpdate();
	}	
	
	override public void DirectionTurn()
	{
		if ( Input.GetButton("Vertical") || Input.GetButton("Horizontal") )
		{	
			Quaternion mainCameraRotation = Camera.main.transform.rotation;
		
			float vertical_value   = Input.GetAxis("Vertical");
			float horizontal_value = Input.GetAxis("Horizontal");
			//float x = Mathf.Abs( horizontal_value );
			//float z = Mathf.Abs( vertical_value );
			
			bool is_click = false;
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
	
	override public void Move( float x , float z )
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
	
		
		ccontroller.Move( moveDirection * Time.deltaTime );
	}
	
	override public void Down()
	{
		moveDirection.y -= gravity * Time.deltaTime;
	}
	
	override public void Jump()
	{
		moveDirection.y = jumpHeight;
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
