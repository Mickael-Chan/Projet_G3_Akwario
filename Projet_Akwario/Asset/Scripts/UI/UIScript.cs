using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    // Player Script

    private PlayerScript player;

    // Life 

    [Header("Life Bar")]
    public Image[] heartList;

    private int playerPv;
    private int playerPvMax;

    // Pearl

    [Header("Pearl Display")]
    public TMP_Text playerPearl;

    // Menu Pause

    [Header("Menu Pause")]
    public GameObject menuPausePanel;

    // Menu Dead

    [Header("Menu Mort")]
    public GameObject deadPanel;

 

    private void Start()
    {
        // Initialization

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();

    }

    private void Update()
    {
        if (player != null)
        {
            // Life MAJ

            playerPv = player.playerPv;
            playerPvMax = player.playerPvMax;

            if (playerPv > playerPvMax)
            {
                playerPv = playerPvMax;
            }

            for (int i = 0; i < heartList.Length; i++)
            {
                if (i < playerPv)
                {
                    heartList[i].color = Color.white;
                }
                else
                {
                    heartList[i].color = Color.black;
                }

                if (i < playerPvMax)
                {
                    heartList[i].enabled = true;
                }
                else
                {
                    heartList[i].enabled = false;
                }
            }

            // Pearl Maj

            playerPearl.text = (": " + player.playerPearl);

            if (player.playerIsDead)
            {
                deadPanel.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && player.playerIsDead == false)
        {
            MenuPauseActivator();
        }
        
    }

    public void MenuPauseActivator()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            menuPausePanel.SetActive(!menuPausePanel.activeSelf);
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
            
        }
        
    }

}
