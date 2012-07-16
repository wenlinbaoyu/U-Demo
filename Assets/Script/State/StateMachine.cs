using System;
using UnityEngine;

public class StateMachine<T> where T : class
{
	
	//获取实例
	private T _owner;
	
	//前一状态
	private State<T> _previousState = null;
	
	//当前状态
	private State<T> _currentState = null;
	
	//全局状态
	private State<T> _globalState = null;
	
	
	public StateMachine( T owner )
	{
		if ( owner  == null )
		{
			Debug.LogError("<StateMachine::changState> : owner do not null" );
			return;
		}
		_owner = owner;
		
		
		_previousState = null;
		_currentState  = null;
		_globalState   = null;
	}
	
	//初始化FSM
	public void setCurrentState( State<T> state )  { _currentState  = state ;}
	public void setGlobalState( State<T> state )   { _globalState   = state ;}
	public void setPreviousState( State<T> state ) { _previousState = state ;}
	
	
	//get state
	public State<T> getCurrentState() { return _currentState ;}
	public State<T> getGlobalState()  { return _globalState ;}
	public State<T> getPreviousState() { return _previousState ;}
	
	
	//UpdateFunction
	public void update()
	{
		if( _globalState != null )  _globalState.Execute( _owner );
		
		if( _currentState != null ) _currentState.Execute( _owner );
	}
	
	
	//Change State
	public void changeState( State<T> newState )
	{
		if( newState == null)
		{
			Debug.LogError("<StateMachine::changState> : want to chang a null state" );
			return;
		}
		
		//mark current state , and we can revert to this state again
		_previousState = _currentState;
		
		//Exit current state
		_currentState.Exit( _owner );
		
		_currentState = newState;
		
		_currentState.Enter( _owner );
	}
	
	//revert to previous state
	public void revertToPrevoisState()
	{
		if ( _previousState != null )
		{
			changeState( _previousState );		
		}
	}
}


