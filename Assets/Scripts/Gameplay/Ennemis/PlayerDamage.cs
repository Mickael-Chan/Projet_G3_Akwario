using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int damageDeal;

    private PlayerScript player;

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            player = collision.transform.GetComponent<PlayerScript>();
            if (player.playerIsInvincible == false)
            {
                player.playerPv -= damageDeal;
            }
            

        }
    }

    
}
