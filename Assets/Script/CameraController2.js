#pragma strict

var target : Transform;
var xSpeed = 250.0;
var ySpeed = 120.0;

var yMinLimit = -20;
var yMaxLimit = 80;

var initDis:float = 20;
var minDis:float = 3.0;
var maxDis:float = 50.0;

var wheelSpeed = 5;

static var x = 0.0;
static var y = 0.0;

public  var distance:double = 10.0;
private var position:Vector3;
private var rotation:Quaternion;
private var tagetOffsetPosition:Vector3;
function Start () 
{
	x = 0;
	y = 30;
	
	tagetOffsetPosition = target.position + Vector3(0, 0.05, 0);
	transform.rotation = Quaternion.Euler(y, x, 0);
	transform.position = Quaternion.Euler(y, x, 0) * Vector3(0.0, 0.0, -initDis) + tagetOffsetPosition;
}

function Update () 
{
    if (target) 
    {
       //不清楚调用Distance函数计算出来target与camera之间的距离会变化
	   //distance = Vector3.Distance(target.position,transform.position);
	   tagetOffsetPosition = target.position + Vector3(0, 5, 0);
	   if(Input.GetMouseButton(1))
	   {
		    x += Input.GetAxis("Mouse X") * xSpeed * 0.02;
		    y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02;
		   
		    y = ClampAngle(y, yMinLimit, yMaxLimit);
  	   }   
  
	   distance -= Input.GetAxis("Mouse ScrollWheel")*wheelSpeed;//获取鼠标中建响应
	   distance = Mathf.Clamp(distance,minDis,maxDis);//距离取最大值和最小值
	  
	   rotation = Quaternion.Euler(y, x, 0);
	   position = rotation * Vector3(0.0, 0.0, -distance) + tagetOffsetPosition;
	   
	   transform.rotation = rotation;
	   transform.position = position;
  
	}
}

static function ClampAngle (angle : float, min : float, max : float) {
	if (angle < -360)
	   angle += 360;
	if (angle > 360)
	   angle -= 360;
	return Mathf.Clamp (angle, min, max);
} 

