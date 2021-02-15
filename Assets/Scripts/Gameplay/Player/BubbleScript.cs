using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    public float bubble_Speed;

    private GameObject player;
    private bool shootDirection;
    private Rigidbody bubbleRb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bubbleRb = transform.GetComponent<Rigidbody>();
        shootDirection = player.GetComponent<PlayerScript>().playerDirection;

        if (shootDirection)
        {
            bubbleRb.velocity = (Vector3.right * 10);
        }
        else
        {
            bubbleRb.velocity = (Vector3.left * 10);
        }
    }



    private void Update()
    {
        if (shootDirection)
        {
            bubbleRb.AddForce(Vector3.right * bubble_Speed * Time.deltaTime);
        }
        else
        {
            bubbleRb.AddForce(Vector3.left * bubble_Speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {
            Destroy(collision.gameObject);
        }
        if (!collision.transform.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        
    }
}
