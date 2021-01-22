using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.InputSystem;

public class JsonParametersPlayer
{
    public int playerPv;
    public float playerSpeed;
    public float playerMaxSpeed;
    public float playerJumpHeight;
    

    public JsonParametersPlayer OuvertureJson(string fileName)
    {
        string path = Application.streamingAssetsPath + "/" + fileName + ".json";
        JsonParametersPlayer fileJson;
        string JSonString = File.ReadAllText(path);
        fileJson = JsonUtility.FromJson<JsonParametersPlayer>(JSonString);
        return fileJson;
    }

}


public class PlayerScript : MonoBehaviour
{

    // Basic Attributes

    [Header("Player Attributes")]

    public int playerPv;
    public int playerPvMax;
    public float playerInvincibleTime;
    public bool playerIsInvincible;
    public float playerSpeed;
    public float playerMaxSpeed;
    public float playerJumpHeight;
    public Rigidbody playerRB;
    public bool playerDirection = true;
    public bool playerIsDead;

    private int playerPvTmp;
    private int playerJumpCount;
    private bool playerIsGrounded;
    
    // Raycast

    private RaycastHit rayHit;
    private bool isHit;
    private Vector3 rayBox;

    // Inventory

    [Header("Inventory")]
    public int playerPearl;

    // Shoot

    [Header("Shot")]
    public GameObject playerProjectile;
    public Transform playerSight;

    // Power List

    [Header("Power List")]
    public Power powerDashAttribute;
    public Power powerJumpAttribute;
    public Power powerBumpAttribute;
    public List<Power> powerListRemain = new List<Power>();

    // Obstacles Checker
    [Header("Obstacle Check")]
    public Transform playerGroundCheck;
    public LayerMask playerGroundMask;
    private bool playerIsBlocked;

    // Controller

    public GameControls gameController;

    // Damage

    [HideInInspector]
    public bool playerIsAttacked;

    // Dash

    [Header("Dash Attribues")]
    public float playerBaseDashTime;
    public float playerDashSpeed;

    private float playerDashTime;

    // Json

    private JsonParametersPlayer playerfileJson;

    private void Start()
    {
        // Initialization

        playerRB = this.GetComponent<Rigidbody>();
        playerJumpCount = 1;
        rayBox = new Vector3(transform.localScale.x / 10, transform.localScale.y / 2f, transform.localScale.z / 2);

        // Initialization Controller

        gameController = new GameControls();
        gameController.Enable();
        gameController.Gameplay.Jump.performed += ctx => PlayerJump();
        gameController.Gameplay.Base_Attack.performed += ctx => BaseAttack();

        // Initialization Power

        powerListRemain.Add(powerDashAttribute);
        powerListRemain.Add(powerJumpAttribute);
        powerListRemain.Add(powerBumpAttribute);

        // Initialization Json

        playerfileJson = new JsonParametersPlayer();
        playerfileJson = playerfileJson.OuvertureJson("JsonPlayer");

        playerPv = playerfileJson.playerPv;
        playerSpeed = playerfileJson.playerSpeed;
        playerMaxSpeed = playerfileJson.playerMaxSpeed;
        playerJumpHeight = playerfileJson.playerJumpHeight;
        playerPvTmp = playerPv;
    }

    private void Update()
    {
        // Player Invincibility

        if (playerPv < playerPvTmp)
        {
            StartCoroutine(Invincibility(playerInvincibleTime));
            playerDashTime = 0.2f;
            playerPvTmp = playerPv;
        }

        // Player Dead

        if (playerPv == 0)
        {
            playerIsDead = true;
            gameController.Disable();
            this.gameObject.SetActive(false);
        }

        // Player Dash

        if (playerDashTime < 0)
        {
            playerDashTime = 0;

        }
        else if (playerDashTime > 0)
        {
            playerDashTime -= Time.deltaTime;
        }

        // Obstacle Checker

        if (playerDirection)
        {
            isHit = Physics.BoxCast(this.transform.position, rayBox, Vector3.right, out rayHit, Quaternion.identity, 10f);
        }
        else
        {
            isHit = Physics.BoxCast(this.transform.position, rayBox, Vector3.left, out rayHit, Quaternion.identity, 10f);
        }

        if (!playerIsGrounded)
        {
            if (isHit && (Mathf.Abs(rayHit.point.x - this.transform.position.x) < 1.5f))
            {
                playerIsBlocked = true;
            }
            else
            {
                playerIsBlocked = false;
            }
        }

        if (playerIsGrounded)
        {
            playerIsBlocked = false;
            playerJumpCount = 1;
        }
        else
        {
            playerJumpCount = 0;
        }


        if (!playerIsBlocked)
        {

            if (gameController.Gameplay.Move.ReadValue<float>() != 0)
            {
                playerRB.velocity = new Vector3(playerMaxSpeed * gameController.Gameplay.Move.ReadValue<float>(), playerRB.velocity.y, 0);
            }

            playerRB.AddForce(Vector3.right * gameController.Gameplay.Move.ReadValue<float>() * playerSpeed);
        }
    }

    private void OnDrawGizmos()
    {
        if (isHit)
        {
            if (rayHit.transform.CompareTag("Ground"))
            {
                if (Mathf.Abs(rayHit.point.x - this.transform.position.x) < 1.5f)
                {
                    Gizmos.color = Color.green;
                }
                else
                {
                    Gizmos.color = Color.blue;
                }
            }
            else
            {
                Gizmos.color = Color.red;
            }

            if (playerDirection)
            {
                Gizmos.DrawRay(transform.position, Vector3.right * rayHit.distance);
                Gizmos.DrawWireCube(transform.position + Vector3.right * rayHit.distance, new Vector3(transform.localScale.x / 5, transform.localScale.y, transform.localScale.z));
            }
            else
            {
                Gizmos.DrawRay(transform.position, Vector3.left * rayHit.distance);
                Gizmos.DrawWireCube(transform.position + Vector3.left * rayHit.distance, new Vector3(transform.localScale.x / 5, transform.localScale.y, transform.localScale.z));
            }
   
        }
        
    }

    public void FixedUpdate()
    {
        // PLayer Movement 

        playerIsGrounded = Physics.CheckSphere(playerGroundCheck.position, 0.1f, playerGroundMask);





        if (Mathf.Abs(playerRB.velocity.x) > playerMaxSpeed)
        {
            if (playerRB.velocity.x > 0)
            {
                playerRB.velocity = new Vector3(playerMaxSpeed, playerRB.velocity.y, 0);
            }
            else if (playerRB.velocity.x < 0)
            {
                playerRB.velocity = new Vector3(-playerMaxSpeed, playerRB.velocity.y, 0);
            }
        }



        // Player Rotation

        if (gameController.Gameplay.Move.ReadValue<float>() < 0 && transform.rotation.y == 0)
        {
            transform.Rotate(new Vector3(0, -180, 0));
            playerDirection = false;
        }
        else if (gameController.Gameplay.Move.ReadValue<float>() > 0 && transform.rotation.y < 0)
        {
            transform.Rotate(new Vector3(0, 180, 0));
            playerDirection = true;
        }



        // Player Dash

        if (playerDashTime > 0)
        {
            if (playerDirection)
            {
                playerRB.velocity = (Vector3.left * playerDashSpeed * Time.deltaTime);
            }
            else if (!playerDirection)
            {
                playerRB.velocity = (Vector3.right * playerDashSpeed * Time.deltaTime);
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            if (collision.transform.position.y < this.transform.position.y)
            {
                playerJumpCount = 1;


            }
        }
    }


    public void BaseAttack()
    {
        Destroy(Instantiate(playerProjectile, playerSight.position, Quaternion.identity), 3);
    }


    public void PlayerJump()
    {
        if (playerJumpCount == 1)
        {
            playerJumpCount = 0;
            playerRB.AddForce(Vector3.up * playerJumpHeight, ForceMode.Impulse);

            //Debug.Log("Je saute");
        }
    }


    IEnumerator Invincibility(float time)
    {
        playerIsInvincible = true;
        yield return new WaitForSeconds(time);
        playerIsInvincible = false;
    }




}
