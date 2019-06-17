using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OldPreloader : MonoBehaviour {
    private CanvasGroup fadeGroup;
    private float loadTime;
    private float minimumLogoTime = 3.0f; //Minimum time of that scene

    private void Start()
    {
        //Grab the only CanvasGroup in the scene
        fadeGroup = FindObjectOfType<CanvasGroup>();

        //Start with a white screen;
        fadeGroup.alpha = 1;

        //Pre load the game
        // $$

        //Get a timestamp of the completion time
        if (Time.time < minimumLogoTime)

            loadTime = minimumLogoTime;
        else
            loadTime = Time.time;
    }//end Start

    private void Update()
    {
        //Fade in
        if (Time.time < minimumLogoTime)
        {
            fadeGroup.alpha = 1 - Time.time;
        }
        //Fade out
        if (Time.time > minimumLogoTime && loadTime != 0)
        {
            fadeGroup.alpha = Time.time - minimumLogoTime;
            if (fadeGroup.alpha >= 1)
            {
				SceneManager.LoadScene ("Menu");
            }
        }
    }//end Update

}//end Preloader


