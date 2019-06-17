using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeScene : MonoBehaviour {
	public RectTransform homeContainer;
	private Vector3 desiredMenuPosition;
	private const float CAMERA_TRANSITION_SPEED = 3.0f;
	private Transform cameraTransform;
	private Transform targetTransform;

	//Kitchen
	//public Transform levelPanel;
	// BedRoom
	public Transform colorPanel;
	public Transform trailPanel;

	// Fading effect
	private CanvasGroup fadeGroup;
	private float fadeInSpeed = 0.33f;

	// ---------------------------------------------------------------------
	// ---- functions
	// ---------------------------------------------------------------------
	private void Start() {
		fadeGroup = FindObjectOfType<CanvasGroup> ();
		fadeGroup.alpha = 1;

		InitKitchen();
		InitBedRoom();
		InitMap();
	}//end Start

	private void Update(){
		// Fade-in
		fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeInSpeed;
		// Menu navigation (Smooth)
		homeContainer.anchoredPosition3D= Vector3.Lerp(homeContainer.anchoredPosition3D, desiredMenuPosition, 0.1f);

		// To map scene
		if (targetTransform != null) {
			cameraTransform.rotation = Quaternion.Slerp (
				cameraTransform.rotation,
				targetTransform.rotation,
				CAMERA_TRANSITION_SPEED * Time.deltaTime
			);
		}
	}//end Update

	private void InitBedRoom(){
		//Make sure we've assigned the references
		if (colorPanel == null || trailPanel == null)
			Debug.Log ("Did not asign the color/trail panel in the inspector");

		//For every children transform under color panel, find the button and add on click
		int i = 0;
		foreach (Transform t in colorPanel) {
			int currentIndex = i;

			Button b = t.GetComponent<Button> ();
			b.onClick.AddListener (() => OnColorSelect (currentIndex));

			i++;
		}

		//Reset index;
		i = 0;
		// Same for trail panel
		foreach (Transform t in trailPanel) {
			int currentIndex = i;

			Button b = t.GetComponent<Button> ();
			b.onClick.AddListener (() => OnTrailSelect (currentIndex));

			i++;
		}

	}//end GoToBedRoom

	private void InitKitchen(){
		//Make sure we've assigned the references
		//if (levelPanel == null )
		//	Debug.Log ("Did not asign the level panel in the inspector");

		//For every children transform under levelpanel, find the button and add on click
		//int i = 0;
		//foreach (Transform t in levelPanel) {
		//	int currentIndex = i;

		//	Button b = t.GetComponent<Button> ();
		//	b.onClick.AddListener (() => OnLevelSelect (currentIndex));
		//	i++;
		//}
	}//end GoToKitchen

	private void InitMap(){
		//Make sure we've assigned the references

	}

	private void NavigateTo(int roomIndex){
		switch (roomIndex) {
		default:
		case 0:
			desiredMenuPosition = Vector3.zero; // living room
			break;
		case 1:
			desiredMenuPosition = Vector3.right * 1280; // kitchen
			break;
		case 2:
			desiredMenuPosition = Vector3.left * 1280; // bedroom
			break;
		case 3:
			SceneManager.LoadScene ("MainMap"); // map
			break;
		}//end switch
	}//end NavigateTo

	// ---------------------------------------------------------------------
	// ---- buttons
	// ---------------------------------------------------------------------
	public void OnLivingRoomClick(){
		NavigateTo (0);
		Debug.Log ("LivingRoom button has been clicked");
	}

	public void OnKitchenClick(){
		NavigateTo (1);
		Debug.Log ("Kitchen button has been clicked");
	}

	public void OnBedroomClick(){
		NavigateTo (2);
		Debug.Log ("Bedroom button has been clicked");
	}

	public void OnMapClick(){
		NavigateTo (3);
		Debug.Log("Map button has been clicked");
	}






	private void OnColorSelect(int currentIndex){
		Debug.Log ("Selecting color button: " + currentIndex);
	}

	private void OnTrailSelect(int currentIndex){
		Debug.Log ("Selecting trail button: " + currentIndex);
	}

	private void OnLevelSelect(int currentIndex){
		Debug.Log ("Selecting level: " + currentIndex);
	}

	public void OnColorBuySet(){
		Debug.Log ("Buy/Set color");
	}
	public void OnTrailBuySet(){
		Debug.Log ("Buy/Set trail");
	}

}//end HomeScene

