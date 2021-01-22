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

    // Ennemis Static

    [HideInInspector]
    public GameObject oursinShape;

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
  

}
