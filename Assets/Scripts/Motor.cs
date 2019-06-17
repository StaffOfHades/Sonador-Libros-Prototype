using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour {

	public float moveSpeed = 5.0f;
	public float drag = 0.5f;
	public float terminalRotationSpeed = 25.0f;
	public VirtualJoystick moveJoystick;

	private Rigidbody controller;
	private Transform camTransform;

	// Use this for initialization
	void Start () {
		controller = GetComponent<Rigidbody> ();
		controller.maxAngularVelocity = terminalRotationSpeed;
		controller.drag = drag;
		camTransform = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
		// DEBUG MOVEMENT FOR COMPUTER
		Vector3 dir = Vector3.zero;
		dir.x = Input.GetAxis ("Horizontal");
		dir.z = Input.GetAxis ("Vertical");
		if (dir.magnitude > 1) {
			dir.Normalize ();
		}
		//

		if (moveJoystick.InputDirection != Vector3.zero) {
			dir = moveJoystick.InputDirection;
		}

		// Rotate Direction in accordance with camera
		Vector3 rotateDir = camTransform.TransformDirection(dir);
		rotateDir.y = 0;
		rotateDir = rotateDir.normalized * dir.magnitude;

		controller.AddForce (rotateDir * moveSpeed);
	}
}
