﻿using UnityEngine;
using System.Collections;

public class T2Controller : Controller {



	public float idealDistance = 50.0f,
					idealYOffset = 10.0f;
	
	// Use this for initialization
	protected new void Start () {
        base.Start();

	}


	protected override void OnAssignCameraAndControl()
	{ 
		float w = attachedCamera.rect.width/4,
			h = attachedCamera.rect.height / 4;
		Rect pos = new Rect(attachedCamera.rect.center.x-w/2,attachedCamera.rect.min.y,w,h);

		//if (shipTransform != null)
		this.GetComponentInChildren<Camera>().rect = pos;
        this.GetComponentInChildren<Camera>().enabled = attachedCamera.enabled;
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (attachedCamera != null)
		{
			Vector3 delta = transform.position - attachedCamera.transform.position;

			Vector3 idealLocation =
				//shipTransform.position - shipTransform.forward * idealDistance + shipTransform.up * idealYOffset;
                transform.position - delta.normalized * idealDistance;
			//(delta - target.up * Vector3.Dot(delta, target.up)).normalized * idealDistance + target.up * idealYOffset;
			Vector3 deltaToIdeal = idealLocation - attachedCamera.transform.position;
			attachedCamera.transform.transform.position += deltaToIdeal * (1.0f - Mathf.Pow(0.02f, Time.deltaTime));
            attachedCamera.transform.LookAt(transform.position);

		}
	}
}
