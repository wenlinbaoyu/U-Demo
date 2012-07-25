/*
 * 由SharpDevelop创建。
 * 用户： SK
 * 日期: 2012/7/25
 * 时间: 15:50
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using UnityEngine;
using System.Collections;

public class WeaponTrailAnimation
{
	public WeaponTrail weaponTrial;
	
	private float currentStateTime = 0;
	private float animationFadeTime = 0.15f;
	protected float t = 0.033f;
	protected float m = 0;
	private float tempT = 0;
	public bool gatherDeltaTimeAutomatically = true; // ** You may want to set the deltaTime yourself for personal slow motion effects
	protected float animationIncrement = 0.003f; // ** This sets the number of time the controller samples the animation for the weapon trails
	
	public WeaponTrailAnimation()
	{
	}
	
	public void SetDeltaTime (float deltaTime)
	{
		t = deltaTime; // ** This is for forcing the deltaTime of the Animation Controller for personal slow motion effects
	}
	
	public void LateUpdate(){
		if (gatherDeltaTimeAutomatically){
			t = Mathf.Clamp (Time.deltaTime, 0, 0.066f);
		}
		// 
		RunAnimations ();
	}
	
	void RunAnimations ()
	{
		//
		if (t > 0) {
			
			// ** The Animation Controller also turns the character
			// ** This is very important for smooth trails... Otherwise each frame the trail will jump to wherever the new rotation causes it to be
			// ** This could be taken further and make the animation controller move the character as well... You might want to do this if you have a character that moves very quickly
			//
			//
			//
			while (tempT < t) {
				
				//
				// ** This loop runs slowly through the animation at very small increments
				// ** a bit expensive, but necessary to achieve smoother than framerate weapon trails
				//
				tempT += animationIncrement;
				// ** steps forward by a small increment
				//
				
				if (weaponTrial.time > 0){
					weaponTrial.Itterate(Time.time - t + tempT);
				}else{
					weaponTrial.ClearTrail();
				}

			}
			//
			// ** End of loop
			//
			tempT -= t;
			//
			// ** Sets the position and rotation to what they were originally
			// ** Finally creates the meshes for the WeaponTrails (one per frame)
			//
			if (weaponTrial.time > 0){
				weaponTrial.UpdateTrail(Time.time, t);
			}
		}
	}
}
