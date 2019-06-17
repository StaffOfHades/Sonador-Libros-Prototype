using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButtons : MonoBehaviour {

	public void OnClickKitchen(){
		SceneManager.LoadScene ("Kitchen");
	}
		
	public void OnClickBedRoom(){
		SceneManager.LoadScene ("BedRoom");
	}

	public void OnClickLivingRoom(){
		SceneManager.LoadScene ("LivingRoom");
	}

	public void OnClickMap(){
		SceneManager.LoadScene ("MainMap");
	}


}//end HomeButtons
