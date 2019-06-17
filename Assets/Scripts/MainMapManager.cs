using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DigitalRubyShared;

public class MainMapManager : MonoBehaviour {

	public GameObject pauseMenu;
	public GameObject pauseButton;

	private SwipeGestureRecognizer swipeGesture;
	private LongPressGestureRecognizer longPressGesture;

	private readonly List<Vector3> swipeLines = new List<Vector3>();

	public void ToMenu() {
		SceneManager.LoadScene ("MainMenu");
	}

	public void ToHome() {
		SceneManager.LoadScene ("LivingRoom");
	}

	public void TogglePauseMenu() {
		pauseMenu.SetActive (!pauseMenu.activeSelf);
		pauseButton.SetActive (!pauseButton.activeSelf);
	}

	private void HandleSwipe(float endX, float endY) {
		Vector2 start = new Vector2(swipeGesture.StartFocusX, swipeGesture.StartFocusY);
		Vector3 startWorld = Camera.main.ScreenToWorldPoint(start);
		Vector3 endWorld = Camera.main.ScreenToWorldPoint(new Vector2(endX, endY));
		float distance = Vector3.Distance(startWorld, endWorld);
		startWorld.z = endWorld.z = 0.0f;

		swipeLines.Add(startWorld);
		swipeLines.Add(endWorld);

		if (swipeLines.Count > 4) {
			swipeLines.RemoveRange(0, swipeLines.Count - 4);
		}

		RaycastHit2D[] collisions = Physics2D.CircleCastAll(startWorld, 10.0f, (endWorld - startWorld).normalized, distance);

		if (collisions.Length != 0) {
			Debug.Log("Raycast hits: " + collisions.Length + ", start: " + startWorld + ", end: " + endWorld + ", distance: " + distance);

			Vector3 origin = Camera.main.ScreenToWorldPoint(Vector3.zero);
			Vector3 end = Camera.main.ScreenToWorldPoint(new Vector3(swipeGesture.VelocityX, swipeGesture.VelocityY, Camera.main.nearClipPlane));
			Vector3 velocity = (end - origin);
			Vector2 force = velocity * 500.0f;

			foreach (RaycastHit2D h in collisions) {
				h.rigidbody.AddForceAtPosition(force, h.point);
			}
		} else {
			//Debug.Log("Raycast hit, start: " + startWorld + ", end: " + endWorld + ", distance: " + distance);
		}
	}

	private void SwipeGestureCallback(GestureRecognizer gesture) {
		if (gesture.State == GestureRecognizerState.Ended) {
			HandleSwipe(gesture.FocusX, gesture.FocusY);
			Debug.Log("Swiped from " + gesture.StartFocusX + "," + gesture.StartFocusY + " to " + gesture.FocusX + "," + gesture.FocusY +"; velocity: " +swipeGesture.VelocityX +", " + swipeGesture.VelocityY);
		}
	}

	private void CreateSwipeGesture() {
		swipeGesture = new SwipeGestureRecognizer();
		swipeGesture.Direction = SwipeGestureRecognizerDirection.Any;
		swipeGesture.StateUpdated += SwipeGestureCallback;
		swipeGesture.DirectionThreshold = 1.0f; // allow a swipe, regardless of slope
		FingersScript.Instance.AddGesture(swipeGesture);
	}

	private void LongPressGestureCallback(GestureRecognizer gesture) {
		if (gesture.State == GestureRecognizerState.Began) {
			Debug.Log("Long press began: " + gesture.FocusX + ", " + gesture.FocusY);
			Debug.Log("Begin Drag");
		} else if (gesture.State == GestureRecognizerState.Executing) {
			Debug.Log("Long press moved: " + gesture.FocusX + ", " + gesture.FocusY);
			Debug.Log("Drag To");
		} else if (gesture.State == GestureRecognizerState.Ended) {
			Debug.Log("Long press end: " + gesture.FocusX + ", " + gesture.FocusY + ", delta: " + gesture.DeltaX + ", " + gesture.DeltaY);
			Debug.Log("End Drag");
		}
	}

	private void CreateLongPressGesture() {
		longPressGesture = new LongPressGestureRecognizer();
		longPressGesture.MaximumNumberOfTouchesToTrack = 1;
		longPressGesture.StateUpdated += LongPressGestureCallback;
		FingersScript.Instance.AddGesture(longPressGesture);
	}

	// Use this for initialization
	void Start () {
		pauseMenu.SetActive (false);
		CreateSwipeGesture();
		CreateLongPressGesture();

		longPressGesture.AllowSimultaneousExecution(swipeGesture);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
}