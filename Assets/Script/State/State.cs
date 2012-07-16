using System;

public class State<T> where T : class
{
	virtual public void Enter( T obj ){}
	virtual public void Execute( T obj ){}
	virtual public void Exit( T obj ){}
}


