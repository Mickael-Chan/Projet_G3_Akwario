using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcolyteGiverScript : MonoBehaviour
{
    private GameObject player;
    private GameObject tmp;
    public GameControls player_Controls;
    public GameObject acolyte;
    public GameObject acolyteMaterial;

    private int random_Index;
    private int list_Size;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player_Controls = new GameControls();
        player_Controls.Enable();
        random_Index = Random.Range(0, player.GetComponent<PlayerScript>().powerListRemain.Count);
        list_Size = player.GetComponent<PlayerScript>().powerListRemain.Count;
    }

    private void Update()
    {
        if (list_Size != player.GetComponent<PlayerScript>().powerListRemain.Count)
        {
            random_Index = Random.Range(0, player.GetComponent<PlayerScript>().powerListRemain.Count);
            list_Size = player.GetComponent<PlayerScript>().powerListRemain.Count;
        }
        
        acolyteMaterial.GetComponent<MeshRenderer>().material.color = player.GetComponent<PlayerScript>().powerListRemain[random_Index].color;

        if (tmp != null)
        {
            Power_Give();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tmp = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tmp = null;
        }
    }

    void Power_Give()
    {
        if (player_Controls.Gameplay.Interact.triggered)
        {
            player.GetComponent<PlayerScript>().powerList.Add(player.GetComponent<PlayerScript>().powerListRemain[random_Index]);
            player.GetComponent<PlayerScript>().powerListRemain.RemoveAt(random_Index);
            Destroy(acolyte.gameObject);
            Destroy(this.gameObject);
        }
    }
}
