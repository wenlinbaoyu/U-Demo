using UnityEngine;
using System.Collections;

public class MainUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
	
	void Awake(){
		Application.LoadLevel(1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}