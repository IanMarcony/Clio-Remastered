﻿using UnityEngine;
using System.Collections;

public class CamTarget : MonoBehaviour 
{
	public Transform target;
	float camSpeed = 5.0f;
	Vector3 lerpPos;
	void Start()
	{
		ASCLBasicController abc = Transform.FindObjectOfType(typeof(ASCLBasicController)) as ASCLBasicController;
		target=abc.transform;
	}
	void LateUpdate() 
	{
		//transform.position = target.position;
		lerpPos = (target.position-transform.position)* Time.unscaledDeltaTime * camSpeed;
		transform.position += lerpPos;
		Vector3 tempForward = transform.position + Camera.main.transform.forward*5.0f;
		tempForward.y = transform.position.y;
		tempForward = (tempForward - transform.position).normalized;
		transform.rotation = Quaternion.LookRotation(tempForward);
	}
}
