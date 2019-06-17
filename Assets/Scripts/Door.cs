using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

	public GameObject target;
	public string scene;
	public float x;
	public float z;
	public float rotation;
		
	void OnTriggerEnter (Collider col) {
		if (col.gameObject == target) {
			GameManager.Data.MapCharPos = GameManager.Data.MapCharPos + new Vector2(x,z);
			SceneManager.LoadScene (scene);
		}
	}

	public void BackToMap() {
		SceneManager.LoadScene ("MainMap");
	}

}
