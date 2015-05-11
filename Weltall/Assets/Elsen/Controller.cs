﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Base controller class, foundation for every ship controller class
 **/
public class Controller : MonoBehaviour {

	public Camera attachedCamera;


    public int      controlIndex;   //!< Index [0,3] in control of the local ship instance.
    public string	accelerate,     //!< Axis name used to accelerate (or brake) the ship
                    custom,         //!< Axis name used to issue a custom command
					horizontalAxis, //!< Axis name used to query the horizontal axis of the local joystick
                    verticalAxis,   //!< Axis name used to query the vertical axis of the local joystick
                    otherAxis;      //!< Axis name used to query the rotational axis of the local joystick (if supported)


    private Dictionary<System.Type, object> attachments = new Dictionary<System.Type,object>();

    /**
     * Attaches the specified item. Only one item of each type is allowed per Controller instance
     **/
    public void Attach<T>(T item)
    {
        attachments.Add(item.GetType(), item);
    }

    /**
     * Retrieves an attachment from the local Controller instance via its type.
     * Use HasAttachment() to check its presence where necessary
     **/
    public T GetAttachment<T>()
    {
        return (T)attachments[typeof(T)];
    }

    /**
     * Checks whether or not a specific object type is attached to the local Controller instance
     **/
    public bool HasAttachment<T>()
    {
        return attachments.ContainsKey(typeof(T));
    }



    /**
     * Called automatically to assemble all joystick axes from the specified control index
     **/
	public void AssignCameraAndControl(Camera camera, int controlIndex)
	{
        horizontalAxis = "Horizontal" + controlIndex;
        verticalAxis = "Vertical" + controlIndex;
        accelerate = "Accelerate" + controlIndex;
        otherAxis = "Other" + controlIndex;

		attachedCamera = camera;
        this.controlIndex = controlIndex;
		OnAssignCameraAndControl();
	}


    /**
     * Called once a new camera and control index have been assigned to the local ship
     * All local member variables have been initialized when this method is called
     **/
	protected virtual void OnAssignCameraAndControl()
	{}


	/**
     * Local Start() method. Make sure that any inheriting class calls this method inside its own Start() method
     **/
	protected void Start ()
    {
        

        Rigidbody body = GetComponent<Rigidbody>();
        if (body)
        {
            body.angularDrag = Level.angularDrag;
            body.drag = Level.drag;
            body.useGravity = true;
            body.mass = 10000f;
            //Debug.Log("Set drag to " + body.angularDrag);
        }
        else
            Debug.LogWarning("Ship body '" + name + "' does not have a RigidBody component attached");


        if (Level.overrideDriveColor)
        {
            ParticleSystem[] systems = GetComponentsInChildren<ParticleSystem>();
            if (systems != null)
            {
                foreach (ParticleSystem sys in systems)
                {
                    sys.startColor = Level.driveColor;
                }
            }
        }
	}
	
}
