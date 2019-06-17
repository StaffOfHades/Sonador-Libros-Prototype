using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldRabbitScript : MonoBehaviour {

	public float moveSpeed = 5.0f;
	public float drag = 0.5f;
	public float terminalRotationSpeed = 25.0f;
	public VirtualJoystick cameraJoystick;
	public VirtualJoystick moveJoystick;
	public Rigidbody body;

	private Animator anim;
	private Transform camTransform;

	void Awake() {
		body.transform.Rotate (new Vector3(0,GameManager.Data.MapCharRot,0));
		body.transform.position = new Vector3(GameManager.Data.MapCharPos.x, 1f, GameManager.Data.MapCharPos.y);
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
		body.maxAngularVelocity = terminalRotationSpeed;
		body.drag = drag;
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
		rotateDir = rotateDir.normalized * dir.magnitude;
		if (rotateDir.y > 0.5) {
			body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		} else {
			body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
		}

		body.AddForce (rotateDir * moveSpeed);

		if (Input.GetKeyDown (KeyCode.Q)) {
			body.transform.Rotate (Vector3.down * 90);
		} else if (Input.GetKeyDown (KeyCode.E)) {
			body.transform.Rotate (Vector3.up * 90);
		}

		/*
		if (dir != Vector3.zero && cameraJoystick.InputDirection.x != 0) {
			if (cameraJoystick.InputDirection.x < 0 ) {
				body.transform.Rotate(Vector3.down * cameraJoystick.InputDirection.x);
			} else {
				body.transform.Rotate(Vector3.up * cameraJoystick.InputDirection.x);
			}
		}
		*/

		Vector3 force = new Vector3(1.0f, 0.0f, 0.0f);

		//body.isKinematic = true;
		anim.SetFloat ("Velocity", body.velocity.magnitude);

		//GameManager.Data.MapCharPos = new Vector2(body.position.x, body.position.z);
	}

	public void RotateBody() {
		body.transform.Rotate (Vector3.up * 90);
	}
}
