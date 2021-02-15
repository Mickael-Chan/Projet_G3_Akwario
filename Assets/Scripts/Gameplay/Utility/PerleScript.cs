using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerleScript : MonoBehaviour
{
    public int pearlValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().playerPearl += pearlValue;
            Destroy(this.gameObject);
        }
    }
}
