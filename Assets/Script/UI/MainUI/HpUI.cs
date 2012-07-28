using UnityEngine;
using System.Collections;

public class HpUI : MonoBehaviour {

	// Use this for initialization
	UISlicedSprite hpSprite;
	
	void Start () {
		hpSprite = GetComponent<UISlicedSprite>();
		
		Vector3 scale = hpSprite.transform.localScale;
		scale.x = 100;
		hpSprite.transform.localScale = scale;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
