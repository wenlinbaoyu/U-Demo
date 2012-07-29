using System;

public class AnimationControllerEvent : CommentEvent
{
	//commone animation event 
	public const string EVENT_ANIMATION_FINISH = "EVENT_ANIMATION_FINISH";
	
	BaseController _controller = null;
	
	public AnimationControllerEvent (string eventType , BaseController controller ): base(eventType)
	{
		_controller = controller;
	}
	
	public BaseController getController()
	{
		return _controller;
	}
}

