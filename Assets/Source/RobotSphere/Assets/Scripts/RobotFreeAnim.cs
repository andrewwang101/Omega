﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFreeAnim : MonoBehaviour {

	Vector3 rot = Vector3.zero;
	float rotSpeed = 40f;
	Animator anim;

	public CharacterController controller;
	public float speed = 12f;
	public float gravity = 9.81f;
	public float jumpheight = 3f;

	Vector3 velocity;

	// Use this for initialization
	void Awake()
	{
		anim = gameObject.GetComponent<Animator>();
		//gameObject.transform.eulerAngles = rot;
	}

	// Update is called once per frame
	void Update()
	{
		CheckKey();
		gameObject.transform.eulerAngles = rot;
	}

	void CheckKey()
	{
		// Walk Left
		if (Input.GetKey(KeyCode.A))
		{
			anim.SetBool("Walk_Anim", true);
			Vector3 move = transform.right * 1f;
			controller.Move(move * speed * Time.deltaTime);

		}
		else if (Input.GetKeyUp(KeyCode.A))
		{
			anim.SetBool("Walk_Anim", false);
		}
		
		//Walk Right
		if (Input.GetKey(KeyCode.D))
		{
			anim.SetBool("Walk_Anim", true);
		}
		else if (Input.GetKeyUp(KeyCode.D))
		{
			anim.SetBool("Walk_Anim", false);
		}
		/*
		// Rotate Left
		if (Input.GetKey(KeyCode.A))
		{
			rot[1] -= rotSpeed * Time.fixedDeltaTime;
		}

		// Rotate Right
		if (Input.GetKey(KeyCode.D))
		{
			rot[1] += rotSpeed * Time.fixedDeltaTime;
		}*/

		// Roll
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (anim.GetBool("Roll_Anim"))
			{
				anim.SetBool("Roll_Anim", false);
			}
			else
			{
				anim.SetBool("Roll_Anim", true);
			}
		}

		// Close
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			if (!anim.GetBool("Open_Anim"))
			{
				anim.SetBool("Open_Anim", true);
			}
			else
			{
				anim.SetBool("Open_Anim", false);
			}
		}
	}

}