using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int damageDeal;

    private PlayerScript player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerScript>();
            if (player.playerIsInvincible == false)
            {
                if (player.transform.position.x >= transform.position.x)
                {
                    player.playerAttackedDirection = true;
                }
                else if (player.transform.position.x < transform.position.x)

                {
                    player.playerAttackedDirection = false;
                }
                player.playerPv -= damageDeal;
            }
        }
    }


}
