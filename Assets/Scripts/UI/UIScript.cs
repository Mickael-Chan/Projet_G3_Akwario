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

    // Bubblies

    [Header("Bubblies Display")]
    public Image bubbly01Display;
    public Image bubbly02Display;
    public TMP_Text power01CDDisplay;
    public TMP_Text power02CDDisplay;

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
        power01CDDisplay.text = Mathf.Round(player.power01Cooldown).ToString();
        power02CDDisplay.text = Mathf.Round(player.power02Cooldown).ToString();

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

            // Bubblies Maj

            if (player.powerList.Count == 0)
            {
                bubbly01Display.enabled = false;
                bubbly02Display.enabled = false;
                power01CDDisplay.enabled = false;
                power02CDDisplay.enabled = false;
            }
            if (player.powerList.Count > 0)
            {
                bubbly01Display.enabled = true;
                player.power01 = player.powerList[player.power01Index].name;
                bubbly01Display.sprite = player.powerList[player.power01Index].image;
                if (player.power01Cooldown > 0)
                {
                    power01CDDisplay.enabled = true;
                }
                else
                {
                    power01CDDisplay.enabled = false;
                }
            }
            if (player.powerList.Count > 1)
            {
                bubbly02Display.enabled = true;
                player.power02 = player.powerList[player.power02Index].name;
                bubbly02Display.sprite = player.powerList[player.power02Index].image;
                if (player.power02Cooldown > 0)
                {
                    power02CDDisplay.enabled = true;
                }
                else
                {
                    power02CDDisplay.enabled = false;
                }
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
