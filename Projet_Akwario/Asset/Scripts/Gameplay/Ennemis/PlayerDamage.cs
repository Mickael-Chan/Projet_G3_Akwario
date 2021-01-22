using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int damageDeal;

    private PlayerScript player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") && !player.playerIsInvincible)
        {
            player.GetComponent<PlayerScript>().playerPv -= damageDeal;
        }
    }
}
