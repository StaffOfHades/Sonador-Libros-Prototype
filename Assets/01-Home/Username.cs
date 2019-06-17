using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Username : MonoBehaviour, FirebaseManager.OnFinishConnectionCallback {

	public Text username;

	public void ConnectionFinished(FirebaseManager.CallbackResult result, string message) {
		switch(result) {
			case FirebaseManager.CallbackResult.Canceled:
			case FirebaseManager.CallbackResult.Faulted:
				Debug.LogError(message);
				break;
			default:
				username.text = message;
				break;
		}
	}

	// Use this for initialization
	void Start () {
		FirebaseManager.GetUsername(this);
	}

}
