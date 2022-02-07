﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject ControlsImg;
    public bool showCont = false;

   public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void Controls()
    {
        Debug.Log("Displaying Controls...");
        showCont = !showCont;
        ControlsImg.SetActive(showCont);
    }
}
