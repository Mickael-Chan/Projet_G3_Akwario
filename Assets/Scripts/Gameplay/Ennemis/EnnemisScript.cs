using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemisScript : MonoBehaviour
{
    // Ennemis List

    public enum ennemisList
    {
        oursin,
        poissonLanterne,
        crevette
    }

    public ennemisList ennemisSelected;

    // Static Ennemis 

    [HideInInspector]
    public GameObject oursinShape;


    // Moving Ennemis 
    [HideInInspector]
    public float ennemisPushTime;
    [HideInInspector]
    public float ennemisPushSpeed;

    private PlayerScript player;
    private Rigidbody ennemisRB;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        ennemisRB = GetComponent<Rigidbody>();
    }



    public void OnTriggerEnter(Collider other)
    {
        switch (ennemisSelected)
        {
            case ennemisList.oursin:
                {
                    if (other.CompareTag("Player"))
                    {
                        oursinShape.transform.localScale = new Vector3(2, 2, 2);
                    }
                    break;
                }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        switch (ennemisSelected)
        {
            case ennemisList.oursin:
                {
                    if (other.CompareTag("Player"))
                    {
                        oursinShape.transform.localScale = new Vector3(1, 1, 1);
                    }
                    break;
                }
        }
    }

    private void Update()
    {
        switch (ennemisSelected)
        {

            case ennemisList.poissonLanterne:
                {
                    if (ennemisPushTime < 0)
                    {
                        ennemisPushTime = 0;
                        ennemisRB.velocity = (new Vector3(0 , ennemisRB.velocity.y, 0f));
                    }
                    else if (ennemisPushTime > 0)
                    {
                        ennemisPushTime -= Time.deltaTime;
                    }

                }
                break;
        }

    }

    private void FixedUpdate()
    {
        switch (ennemisSelected)
        {

            case ennemisList.poissonLanterne:
                {
                    if (ennemisPushTime > 0)
                    {
                        if (player.playerDirection)
                        {
                            ennemisRB.velocity = (Vector3.right * ennemisPushSpeed * Time.deltaTime);
                        }
                        else
                        {
                            ennemisRB.velocity = (Vector3.left * ennemisPushSpeed * Time.deltaTime);
                        }
                    }



                }
                break;
        }

    }

}
