using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{    
    public int camSpeed;
    public float camY;
    public float camZ;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {

        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(player.position.x, player.position.y + camY, camZ), camSpeed * Time.deltaTime);
    }
}
