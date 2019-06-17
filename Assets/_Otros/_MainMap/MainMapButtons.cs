using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMapButtons : MonoBehaviour {

	public void OnClickCasa(){
		SceneManager.LoadScene ("LivingRoom");
	}

	public void OnClickTiendaComida(){
		SceneManager.LoadScene ("ShopFoodMenu");
	}

	public void OnClickMemorama(){
		SceneManager.LoadScene ("Memorama");
	}

	public void OnClickTrivia(){
		SceneManager.LoadScene ("Persistent");
	}

}//end MainMapButtons
