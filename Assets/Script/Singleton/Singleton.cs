using System;

public class Singleton< T > where T : new()
{
	private static T _instance;
	public Singleton (){}
	
	public static T getSingleton()
	{
		if ( _instance == null )
		{
			_instance = new T();
		}
		return _instance;
	}
}


