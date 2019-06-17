﻿using Firebase.Unity.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestingInitializor : MonoBehaviour, FirebaseManager.OnFinishConnectionCallback {

	public void ConnectionFinished(FirebaseManager.CallbackResult result, string message) {
		switch(result) {
			case FirebaseManager.CallbackResult.Canceled:
			case FirebaseManager.CallbackResult.Faulted:
				Debug.LogError(message);
				break;
			default:
				Debug.Log("Sucessfully logged on");
				SceneManager.LoadScene ("LivingRoom");
				break;
		}
	}

	protected virtual void Start() {
		FirebaseManager.LoginPlayer("mau.graci@gmail.com", "Mau1214*#", this);
	}

}

