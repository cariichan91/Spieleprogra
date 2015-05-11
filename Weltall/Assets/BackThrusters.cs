using UnityEngine;
using System.Collections;

public class BackThrusters : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			this.transform.Translate (new Vector3 (0, 0, -2));
			Debug.Log ("Active");
			
		} else {
			this.gameObject.SetActive (false);
		}
	}
}
