using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class playerController : MonoBehaviour 
{
	
	//public custom_inputs inputManager;
	
	//内部私有参数
	private Camera mainCamera = null;
	private Transform mainCameraTransform = null;
	private Transform rigibodyTransform = null;
	
	
	private const float groundedDistance = 0.26f;
	public float groundedCheckOffset = -0.23f;
	
	private const float inputThreshold = 0.01f,
	groundDrag = 5.0f,
	directionalJumpFactor = 0.7f;
	
	private bool grounded = false;
	
	private Quaternion rotation  = Quaternion.identity;	

	//动作管理
	private AnimationManager _mgr = null;
	
	//外部参数
	//走路的速度
	public  float speed = 0.2f;
	//旋转的速度
	public  float trunspeed = 0.0f;
	
	public float jumpSpeed = 2.0f;
	
	
    void Awake()
	{
		//主摄像机
		mainCamera = Camera.main;
		mainCameraTransform = mainCamera.transform;
	}
	
    void Start () 
	{	
		//获取动作管理器;
		_mgr = AnimationMgrFactory.getSingleton().getManager( this.gameObject.name, this.gameObject.animation );
		
		Debug.Log( _mgr );
		if ( _mgr == null )
		{
			Debug.LogError ( " this.gameObject.name cann't get some AnimationManager ");
		}

		rigibodyTransform  = rigidbody.transform;
		rigidbody.freezeRotation = true;
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
		
		if( isMoveKeyDown())
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
		
		//Vector3 movement = rigibodyTransform.forward ;
		

	}
	
	
	void FixedUpdate()
	{
		grounded = Physics.Raycast (
			rigidbody.transform.position + rigidbody.transform.up * -groundedCheckOffset,
			rigidbody.transform.up * -1,
			groundedDistance,
			-1
		);
		
		if (grounded){
			rigidbody.drag = groundDrag;
			
			if (Input.GetButton ("Jump"))
			{
				rigidbody.AddForce(
					jumpSpeed * rigibodyTransform.up + rigidbody.velocity.normalized * directionalJumpFactor,
					ForceMode.VelocityChange
				);
				
				_mgr.play( new AID("jump") );
			}
			else if ( isMoveKeyDown())
			{
				_mgr.play( new AID("run") );
				Vector3 moveDirection = new Vector3( Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
				rigidbody.AddForce( moveDirection.normalized * speed ,ForceMode.VelocityChange );
			}	
			else if(Input.GetButton("Fire1"))
			{
				_mgr.play( new AID("attack") );
			}
			else if(Input.GetKeyDown(KeyCode.Alpha2))
			{
				
			}
			else if(Input.GetKeyDown(KeyCode.Alpha3))
			{

			}
			else if(Input.GetKeyDown(KeyCode.Alpha4))
			{
			}
			else
			{
				_mgr.play( new AID("idle") );
			}
		}
		else
		{ 
			rigidbody.drag = 0.0f; 
		}
	}
	
	
	void OnDrawGizmos()
	{
		Gizmos.color = grounded ? Color.blue : Color.red;
		Gizmos.DrawLine ( rigidbody.transform.position + rigidbody.transform.up * -groundedCheckOffset,
			rigidbody.transform.position + rigidbody.transform.up * -(groundedCheckOffset + groundedDistance));
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
