/*
 * 由SharpDevelop创建。
 * 用户： SK
 * 日期: 2012/7/28
 * 时间: 15:53
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using UnityEngine;
using System.Collections;

public class HpMpBarUI : MonoBehaviour {

	UISlicedSprite hpSprite;
	UISlicedSprite mpSprite;
	
	private float oriHpSpriteWidth;
	private float oriMpSpriteWidth;
	
	void Start () {
		Messenger<int,int>.AddListener(RoleStatus.EVENT_UPDATE_HP, OnUpdateHP);
		Messenger<int,int>.AddListener(RoleStatus.EVENT_UPDATE_MP, OnUpdateMP);
		
		hpSprite = transform.Find("SlicedSprite (hp)").GetComponent<UISlicedSprite>();
		mpSprite = transform.Find("SlicedSprite (mp)").GetComponent<UISlicedSprite>();
		
		oriHpSpriteWidth = hpSprite.transform.localScale.x;
		oriMpSpriteWidth = mpSprite.transform.localScale.x;
	}
	
	private void OnUpdateHP(int curHP, int maxHP){
		Vector3 scale = hpSprite.transform.localScale;
		float percent = (float)curHP/(float)maxHP;
		scale.x = oriHpSpriteWidth*percent;
		hpSprite.transform.localScale = scale;		
	}

	private void OnUpdateMP(int curMP, int maxMP){
		Vector3 scale = mpSprite.transform.localScale;
		float percent = (float)curMP/(float)maxMP;
		scale.x = oriMpSpriteWidth*percent;
		mpSprite.transform.localScale = scale;		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
