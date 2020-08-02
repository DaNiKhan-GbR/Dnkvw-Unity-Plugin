﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{    
    // Update is called once per frame
    void Update()
    {       
       
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(SceneManager.GetActiveScene().name == "Room")
                SceneManager.LoadScene(sceneName: "SampleScene");
            else
                SceneManager.LoadScene(sceneName: "Room");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
