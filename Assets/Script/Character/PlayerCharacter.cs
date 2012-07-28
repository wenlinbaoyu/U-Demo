/// <summary>
/// PlayerCharacter.cs
/// Oct 20, 2010
/// 
/// This script controls the users ingame character.
/// 
/// Make sure this script is attached to the character prefab
/// </summary>

using UnityEngine;
using System.Collections.Generic;

public class PlayerCharacter : BaseCharacter {

	public override void Awake()
	{
		base.Awake();
	}	
	
	void Update() {
		Messenger<int, int>.Broadcast("player health update", 80, 100, MessengerMode.DONT_REQUIRE_LISTENER);
	}

	public void Start() {
	}
}
