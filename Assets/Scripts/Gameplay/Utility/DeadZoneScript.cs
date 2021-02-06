using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if  (other.CompareTag("Ennemis"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().playerPv = 0;
        }
    }
}
