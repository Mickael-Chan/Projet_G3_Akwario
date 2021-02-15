﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public void PlayGame (int index)
    {
        SceneManager.LoadScene(index);     
    }

    public void QuitGame ()
    {
        Application.Quit();
    }


}
