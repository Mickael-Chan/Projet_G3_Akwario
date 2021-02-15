using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformScript : MonoBehaviour
{
    public BoxCollider plateformCollider;
    private PlayerScript player;
    private Transform playerTransform;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        plateformCollider = GetComponent<BoxCollider>();    
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(player.playerRB.velocity.x) > 0)
        {
            if ((playerTransform.position.y > transform.position.y))
            {
                plateformCollider.size = new Vector3(Mathf.Clamp(Mathf.Abs(player.playerRB.velocity.x), 1, 1.05f), plateformCollider.size.y, plateformCollider.size.z);
            }
            else
            {
                plateformCollider.size = new Vector3(1, plateformCollider.size.y, plateformCollider.size.z);
            }

            
        }
    }
}
