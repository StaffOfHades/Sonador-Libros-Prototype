using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopFoodUI : MonoBehaviour {
	
	public void OnClickYes(){
		SceneManager.LoadScene ("ShopFoodBuy");
	}

	public void OnClickNo(){
		SceneManager.LoadScene ("MainMap");
	}

	public void OnClickExit(){
		SceneManager.LoadScene ("MainMap");
	}

	public void OnClickReturn(){
		SceneManager.LoadScene ("ShopFoodMenu");
	}

}//end ShopFoodUI
