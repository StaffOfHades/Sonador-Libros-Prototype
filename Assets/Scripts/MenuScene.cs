using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuScene : MonoBehaviour 
{
	private CanvasGroup fadeGroup;
	private float fadeInSpeed = 0.33f;

	public RectTransform menuContainer;
	public Transform levelPanel;

	public Transform colorPanel;
	public Transform trailPanel;

	private Vector3 desiredMenuPosition;

	private const float CAMERA_TRANSITION_SPEED = 3.0f;

	private Transform cameraTransform;
	private Transform targetTransform;


	private void Start()
	{
		fadeGroup = FindObjectOfType<CanvasGroup> ();
		fadeGroup.alpha = 1;

		// Add button on-click events to shop buttons
		InitShop();

		// Add buttons on click events to levels
		InitLevel();

		//Button to map
		InitMap();
	}//end Start

	private void Update(){
		// Fade-in
		fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeInSpeed;
		// Menu navigation (Smooth)
		menuContainer.anchoredPosition3D= Vector3.Lerp(menuContainer.anchoredPosition3D, desiredMenuPosition, 0.1f);

		// To map scene
		if (targetTransform != null) {
			cameraTransform.rotation = Quaternion.Slerp (
				cameraTransform.rotation,
				targetTransform.rotation,
				CAMERA_TRANSITION_SPEED * Time.deltaTime
			);
		}
	}//end Update

	private void InitShop(){
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

	}//end InitShop

	private void InitLevel(){
		//Make sure we've assigned the references
		if (levelPanel == null )
			Debug.Log ("Did not asign the level panel in the inspector");

		//For every children transform under levelpanel, find the button and add on click
		int i = 0;
		foreach (Transform t in levelPanel) {
			int currentIndex = i;

			Button b = t.GetComponent<Button> ();
			//b.onClick.AddListener (() => OnLevelSelect (currentIndex));

			i++;
		}
	}//end InitLevel

	private void InitMap(){
		//Make sure we've assigned the references
		if (levelPanel == null )
			Debug.Log ("Did not asign the level panel in the inspector");

		//For every children transform under levelpanel, find the button and add on click
		int i = 0;
		foreach (Transform t in levelPanel) {
			int currentIndex = i;

			Button b = t.GetComponent<Button> ();
			b.onClick.AddListener (() => OnLevelSelect (currentIndex));

			i++;
		}
	}

	private void NavigateTo(int menuIndex){
		switch (menuIndex) {
		// 0 && default case = Main Menu
		default:
		case 0:
			desiredMenuPosition = Vector3.zero;
			break;
		// 1 = Play Menu
		case 1:
			desiredMenuPosition = Vector3.right * 2390;
			break;
		// 2 = Shop Menu
		case 2:
			desiredMenuPosition = Vector3.left * 2390;
			break;
		// 3 = Map
		case 3:
			SceneManager.LoadScene ("MainMap");
			break;
		}//end switch

	}//end NavigateTo

	//-----------------
	// Buttons
	//-----------------
	public void OnBackClick(){
		NavigateTo (0);
		Debug.Log ("Back button has been clicked");
	}

	public void OnPlayClick(){
		NavigateTo (1);
		Debug.Log ("Play button has been clicked");
	}

	public void OnShopClick(){
		NavigateTo (2);
		Debug.Log ("Shop button has been clicked");
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
		
}//end MenuScene
