﻿using UnityEngine;
using System.Collections;

public class PlayerManager_3: MonoBehaviour {
	private Animator animator;
	void Awake()
	{
		//得到Animator组件
		animator = GetComponent<Animator>();
	}
	void Update () 
	{
			//得到Joystick水平轴向输入的值
			float v = Input.GetAxis("Vertical");
			//得到Joystick水平轴向输入的值
			float h = Input.GetAxis("Horizontal");
			//将该值传递至animator的Speed参数
			animator.SetFloat("Speed", h*h+v*v);
			//将该值传递至animator的Direction参数
			animator.SetFloat("Direction", h, 0.25f, Time.deltaTime);	


			//得到Animator中序号为0的layer，也就是Base Layer的状态信息
			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);		
			if (stateInfo.shortNameHash == Animator.StringToHash("Run"))
			{
				//Base Layer为Run状态，当检测到按下开火按钮，设置Jump为true
				if (Input.GetButton("Fire1")) animator.SetBool("Jump", true);                
			}
			else
			{
				//当Base Layer为其他状态时,设置Jump为false
				animator.SetBool("Jump", false);                
			}
	}
}