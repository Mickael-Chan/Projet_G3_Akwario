using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScript : MonoBehaviour
{
    public GameObject victoryPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            victoryPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
