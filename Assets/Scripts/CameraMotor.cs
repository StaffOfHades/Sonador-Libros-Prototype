using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

	public Transform lookAt;
	public VirtualJoystick cameraJoystick;
	public VirtualJoystick moveJoystick;

	private float distance = 5.0f;
	private float smoothSpeed = 7.5f;
	private float yOffset = 3.5f;
	private Vector3 desiredPosition;
	private Vector3 offest;
	private bool invert = false;
	private int invert2 = 0;

	void Awake() {
		offest = new Vector3 (0, yOffset, -1f * distance);
		offest = Quaternion.Euler (0, GameManager.Data.MapCharRot, 0) * offest;
		desiredPosition = lookAt.position + offest;
		transform.position = Vector3.Lerp (transform.position, desiredPosition, Time.deltaTime);
		transform.LookAt (lookAt.position + Vector3.up);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			SlideCamera (false);
		} else if (Input.GetKeyDown (KeyCode.E)) {
			SlideCamera (true);
		}
	}

	void FixedUpdate() {
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

		Vector3 dirCamera = Vector3.zero;

		if (	moveJoystick.InputDirection == Vector3.zero &&
				cameraJoystick.InputDirection != Vector3.zero) {
			dirCamera = cameraJoystick.InputDirection;
			dirCamera.y = dirCamera.z * 3;
			dirCamera.z = 0;
			dirCamera.x = dirCamera.x * 5;


			if (invert2 == 0 || invert2 == 1) {
				dirCamera.x = dirCamera.x * -1;
			}

			if (invert) {
				dirCamera.z = dirCamera.x;
				dirCamera.x = 0;
			}
		}

		desiredPosition = lookAt.position + offest + dirCamera;
		transform.position = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		transform.LookAt (lookAt.position + Vector3.up);
	}

	public void SlideCamera() {
		SlideCamera(true);
	}

	public void SlideCamera(bool left) {
		float y = left ? 90 : -90;
		offest = Quaternion.Euler (0, y, 0) * offest;
		invert = !invert;
		invert2 = invert2 + (left ? -1 : 1);
		if (invert2 > 3) {
			invert2 = 0;
		} else  if (invert2 < 0) {
			invert2 = 3;
		}
		Debug.Log(invert2);
	}
}
