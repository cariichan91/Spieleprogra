using UnityEngine;
using System.Collections;  

public class PleaseMove : MonoBehaviour {
	
	protected ConstantForce force;
	protected GameObject rbThruster; 
	protected GameObject lbThruster; 
	protected Rigidbody rb; 

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody> (); 
		//rbThruster = rb.GetComponent();
		rbThruster = GameObject.FindGameObjectWithTag ("RightBackThruster");
		lbThruster = GameObject.FindGameObjectWithTag ("LeftBackThruster");
		rbThruster.SetActive(true);
		lbThruster.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			//rb.AddRelativeForce (new Vector3(0, 0, -10));
			//this.transform.Translate(new Vector3(0, 0, -2));

			//rbThruster.SendMessage("Update");
			//lbThruster.SendMessage("Update");

		}

		if (Input.GetKey (KeyCode.S)) {
			this.transform.Translate (new Vector3(0, 0, 2));
		}

	}
	

}
