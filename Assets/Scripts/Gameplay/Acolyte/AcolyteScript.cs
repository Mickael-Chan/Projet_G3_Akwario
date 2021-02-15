using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcolyteScript : MonoBehaviour
{
    public GameObject acolyte01;
    public GameObject acolyte01Shape;
    public GameObject acolyte02;
    public GameObject acolyte02Shape;
    public float acolyteSpeed;
    private GameObject player;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {


        if (player.activeSelf != false)
        {


            if (player.GetComponent<PlayerScript>().powerList.Count > 0)
            {

                acolyte01.gameObject.SetActive(true);
                acolyte01Shape.GetComponent<Renderer>().material.color = player.GetComponent<PlayerScript>().powerList[player.GetComponent<PlayerScript>().power01Index].color;

            }

            if (player.GetComponent<PlayerScript>().powerList.Count > 1)
            {
                acolyte02.gameObject.SetActive(true);
                acolyte02Shape.GetComponent<Renderer>().material.color = player.GetComponent<PlayerScript>().powerList[player.GetComponent<PlayerScript>().power02Index].color;
            }


        }
        else
        {
            acolyte01.gameObject.SetActive(false);
            acolyte02.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position + new Vector3(0, 2f, 0), acolyteSpeed * Time.deltaTime);
    }
}
