using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMovement : MonoBehaviour {

	public float moveSpeed;
	public float ceiling;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (0, 10, 0) * Time.deltaTime * moveSpeed);
		transform.Rotate (new Vector3 (0, 0, 0.1f) * Mathf.Sin (10*Time.deltaTime));
		if (transform.position.y > ceiling) {
			Destroy (this.gameObject);
		}
	}
}
