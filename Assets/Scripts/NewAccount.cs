﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewAccount : MonoBehaviour, FirebaseManager.OnFinishConnectionCallback {

	public InputField email, username, pwd;

	public void ConnectionFinished(FirebaseManager.CallbackResult result, string message) {
		switch(result) {
			case FirebaseManager.CallbackResult.Canceled:
			case FirebaseManager.CallbackResult.Faulted:
				Debug.LogError(message);
				break;
			default:
				SceneManager.LoadScene ("LivingRoom");
				break;
		}
	}

	public void OnNewAccount() {
		FirebaseManager.CreateNewPlayer(email.text, username.text, pwd.text, this);
	}
		
}
