using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class House : MonoBehaviour {

	public GameObject target;

	void OnTriggerEnter (Collider col) {
		Debug.Log (col.gameObject.tag);
		if (col.gameObject == target) {
			SceneManager.LoadScene ("Menu");
		}
	}
}
