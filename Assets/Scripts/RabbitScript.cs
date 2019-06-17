using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitScript : MonoBehaviour {

	public float moveSpeed = 5.0f;
	public float drag = 0.5f;
	public float terminalRotationSpeed = 25.0f;
	public VirtualJoystick cameraJoystick;
	public VirtualJoystick moveJoystick;
	public Rigidbody body;

	private Animator anim;
	private Transform camTransform;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		camTransform = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		// DEBUG MOVEMENT FOR COMPUTER
		Vector3 dir = Vector3.zero;
		dir.x = Input.GetAxis ("Horizontal");
		dir.z = Input.GetAxis ("Vertical");

		if (moveJoystick.InputDirection != Vector3.zero) {
			dir = moveJoystick.InputDirection;
		}

		if (Input.GetKeyDown (KeyCode.Q)) {
			body.transform.Rotate (Vector3.down * 90);
		} else if (Input.GetKeyDown (KeyCode.E)) {
			body.transform.Rotate (Vector3.up * 90);
		}

		float rotVec = dir.x * Time.deltaTime * terminalRotationSpeed;
		float movVec = dir.z * Time.deltaTime * moveSpeed;

		body.transform.Rotate(0, rotVec, 0);
		body.transform.Translate(0, 0, movVec);

		//GameManager.Data.MapCharPos = new Vector2(body.position.x, body.position.z);
	}

	public void RotateBody() {
		body.transform.Rotate (Vector3.up * 90);
	}

}