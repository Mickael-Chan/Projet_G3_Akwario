﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public EventSystem eventButton;
    public GameObject buttonSelected;

    private void OnEnable()
    {
        eventButton.SetSelectedGameObject(buttonSelected);
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();

    }


}