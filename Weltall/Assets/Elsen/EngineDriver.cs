﻿using UnityEngine;
using System.Collections;

public class EngineDriver : MonoBehaviour {


	public float	maxLifetime = 0.5f,
					maxForce = -500000f;

	protected ParticleSystem sys;
	protected ConstantForce force;
	protected string axis;
	// Use this for initialization
	void Start ()
	{
		sys = this.GetComponent<ParticleSystem>(); 
		force = this.GetComponent<ConstantForce>();
	}


	protected virtual string FetchAxis(Controller controller)
	{
		return controller.accelerate;
	}


	private string FetchAxis0()
	{
        Controller ctrl = GetComponentInParent<Controller>();
        if (ctrl != null)
            return FetchAxis(ctrl);
        return null;
	}


	protected virtual float Filter(float f)
	{
		return Mathf.Max(f,0f); //thruster logic
	}

	// Update is called once per frame
	void Update()
	{
		Debug.Log ("Update");

		//bool enabled = Input.GetKey(key);

		if (axis == null || axis.Length == 0)
			axis = FetchAxis0();

		
		{
			float f = 0f;
			if (axis != null && axis.Length > 0)
			{ 
				//Debug.Log(axis);
				Debug.Log("Filtering");
				f = Filter(Input.GetAxis(axis));
			}
			if (sys != null)
			{
				sys.enableEmission = f != 0f;
				sys.startLifetime = f * maxLifetime;
				Debug.Log ("System lives");
			}

			if (force != null)
			{
				force.relativeForce = new Vector3(0,0,maxForce * f);
				Debug.Log("Force used!");
			}
		}
	}
}
