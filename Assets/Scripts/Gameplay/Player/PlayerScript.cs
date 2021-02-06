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

    #region Player Attributes

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
    public float fallMultiplier;
    public float lowJumpMultiplier;
    public Animator playerAnimator;

    private int playerPvTmp;
    private int playerJumpCount;
    private bool playerIsGrounded;
    private bool playerIsJumping;

    private float JumpTimeCounter;
    private float JumpTime = 0.35f;

    #endregion

    #region Raycast

    private RaycastHit obstacleRayHit;
    private bool obstacleIsHit;
    private Vector3 rayBox;
    private RaycastHit ennemisRayHit;
    private bool ennemisIsHit;
    private RaycastHit obstaclesVRayHit;
    private bool obstaclesVisHit;

    #endregion

    #region Inventory
    [Header("Inventory")]
    public int playerPearl;
    #endregion

    #region Shot
    [Header("Shot")]
    public GameObject playerProjectile;
    public Transform playerSight;
    #endregion

    #region Damage Attributes
    public float damagePushTime;
    public bool playerIsAttacked;
    #endregion

    #region Power Attributes

    [Header("Power List")]
    public string power01;
    public string power02;
    public int power01Index;
    public int power02Index;
    public Power powerDashAttribute;
    public Power powerJumpAttribute;
    public Power powerBumpAttribute;
    public List<Power> powerListRemain = new List<Power>();
    public List<Power> powerList = new List<Power>();

    [Header("Power 01")]
    public float power_01_Cooldown_Time;
    public float power01Cooldown = 0;

    [Header("Power 02")]
    public float power_02_Cooldown_Time;
    public float power02Cooldown = 0;

    #endregion

    #region Obstacles Checker
    [Header("Obstacle Check")]
    public Transform playerGroundCheck;
    public LayerMask playerGroundMask;

    private bool playerIsBlocked;
    #endregion

    #region Game Controller
    public GameControls gameController;
    #endregion

    #region Power Attributes
    [Header("Dash Attribues")]
    public float playerBaseDashTime;
    public float playerDashSpeed;

    private float playerDashTime;
    private bool isDashing;

    [Header("Jump Attribues")]
    public float powerJumpForce;


    [Header("Bump Attribues")]
    public float bumpTime;
    public float bumpMaxDistance;

    #endregion

    #region JSON
    private JsonParametersPlayer playerfileJson;
    #endregion


    private void Start()
    {
        // Initialization

        playerRB = this.GetComponent<Rigidbody>();
        playerJumpCount = 1;
        rayBox = new Vector3(transform.localScale.x / 10, transform.localScale.y / 2.1f, transform.localScale.z / 2);
        playerDirection = true;

        // Initialization Controller

        gameController = new GameControls();
        gameController.Enable();
        //gameController.Gameplay.Jump.performed += ctx => PlayerJump();
        gameController.Gameplay.Base_Attack.performed += ctx => BaseAttack();

        // Initialization Power

        powerListRemain.Add(powerDashAttribute);
        powerListRemain.Add(powerJumpAttribute);
        powerListRemain.Add(powerBumpAttribute);

        // Initialization Json

        playerfileJson = new JsonParametersPlayer();
        playerfileJson = playerfileJson.OuvertureJson("JsonPlayer");

        /*playerPv = playerfileJson.playerPv;
        playerSpeed = playerfileJson.playerSpeed;
        playerMaxSpeed = playerfileJson.playerMaxSpeed;
        playerJumpHeight = playerfileJson.playerJumpHeight;*/

        playerPvTmp = playerPv;
    }

    private void Update()
    {
        // Player Invincibility

        if (playerPv != playerPvTmp)
        {
            StartCoroutine(Damage_Push(damagePushTime));
            StartCoroutine(Invincibility(playerInvincibleTime));
            playerDashTime = damagePushTime;
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
            isDashing = false;

        }
        else if (playerDashTime > 0)
        {
            playerDashTime -= Time.deltaTime;
            isDashing = true;
        }

        // Power switch

        if (gameController.Gameplay.Power_Switch.triggered)
        {
            if (gameController.Gameplay.Power_Switch.ReadValue<float>() > 0 && powerList.Count > 0)
            {

                if (power01Index + 1 == power02Index)
                {
                    if ((power01Index + 2) < powerList.Count)
                    {
                        power01Index += 2;
                    }
                    else if (power02Index == 0)
                    {
                        power01Index = 1;
                    }
                    else
                    {
                        power01Index = 0;
                    }
                }
                else
                {
                    if ((power01Index + 1) < powerList.Count)
                    {
                        power01Index++;
                    }
                    else if (power02Index == 0)
                    {
                        power01Index = 1;
                    }
                    else
                    {
                        power01Index = 0;
                    }
                }
            }
            else if (gameController.Gameplay.Power_Switch.ReadValue<float>() < 0 && powerList.Count > 1)
            {

                if (power02Index + 1 == power01Index)
                {
                    if ((power02Index + 2) < powerList.Count)
                    {
                        power02Index += 2;
                    }
                    else if (power01Index == 0)
                    {
                        power02Index = 1;
                    }
                    else
                    {
                        power02Index = 0;
                    }
                }
                else
                {
                    if ((power02Index + 1) < powerList.Count)
                    {
                        power02Index++;
                    }
                    else if (power01Index == 0)
                    {
                        power02Index = 1;
                    }
                    else
                    {
                        power02Index = 0;
                    }
                }
            }

        }

        // Power 01

        if (gameController.Gameplay.Power_01.triggered && power01Cooldown == 0 && powerList.Count > 0)
        {
            if (power01 == "Dash")
            {
                Power_Dash();

            }
            if (power01 == "Jump")
            {
                Power_Jump();
            }
            if (power01 == "Bump")
            {
                Power_Bump();
            }
            power01Cooldown = power_01_Cooldown_Time;
        }

        // Power 02

        if (gameController.Gameplay.Power_02.triggered && power02Cooldown == 0 && powerList.Count > 1)
        {
            if (power02 == "Dash")
            {
                Power_Dash();
            }
            if (power02 == "Jump")
            {
                Power_Jump();
            }
            if (power02 == "Bump")
            {
                Power_Bump();
            }
            power02Cooldown = power_02_Cooldown_Time;
        }

        // Power 01 CD

        if (power01Cooldown < 0)
        {
            power01Cooldown = 0;
        }
        else if (power01Cooldown > 0)
        {
            power01Cooldown -= Time.deltaTime;
        }

        // Power 02 CD 

        if (power02Cooldown < 0)
        {
            power02Cooldown = 0;

        }
        else if (power02Cooldown > 0)
        {
            power02Cooldown -= Time.deltaTime;
        }

        // Obstacle/ Ennemis  Checker

        if (playerDirection)
        {
            obstacleIsHit = Physics.BoxCast(this.transform.position, rayBox, Vector3.right, out obstacleRayHit, Quaternion.identity, 10f, playerGroundMask);
            ennemisIsHit = Physics.Raycast(this.transform.position, Vector3.right, out ennemisRayHit, bumpMaxDistance);
        }
        else
        {
            obstacleIsHit = Physics.BoxCast(this.transform.position, rayBox, Vector3.left, out obstacleRayHit, Quaternion.identity, 10f, playerGroundMask);
            ennemisIsHit = Physics.Raycast(this.transform.position, Vector3.left, out ennemisRayHit, bumpMaxDistance);
        }

        if (!playerIsGrounded)
        {
            if (obstacleIsHit && (Mathf.Abs(obstacleRayHit.point.x - this.transform.position.x) < 5f))
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


        obstaclesVisHit = Physics.Raycast(playerSight.transform.position, Vector3.down, out obstaclesVRayHit, 0.5f);

        if (obstaclesVisHit && obstaclesVRayHit.transform.CompareTag("Ground") && playerIsBlocked)
        {
            StartCoroutine(UnBlocker(1f));
        }

        if (Mathf.Abs(playerRB.velocity.x) > 0)
        {
            playerAnimator.SetBool("Walk", true);

        }
        else if (Mathf.Abs(playerRB.velocity.x) == 0)
        {
            playerAnimator.SetBool("Walk", false);
        }

        if (playerJumpCount == 0)
        {
            playerAnimator.SetBool("Jump", true);
        }
        else if (playerJumpCount == 1)
        {
            playerAnimator.SetBool("Jump", false);
        }
        playerAnimator.SetFloat("Speed", Mathf.Abs(gameController.Gameplay.Move.ReadValue<float>()) + 1);

        if (playerIsGrounded && Input.GetButtonDown("Jump"))
        {
            playerIsJumping = true;
            JumpTimeCounter = JumpTime;
            playerRB.velocity = new Vector3(playerRB.velocity.x, 10, 0);

        }

        if (Input.GetButton("Jump") && playerIsJumping)
        {
            if (JumpTimeCounter > 0)
            {
                playerRB.velocity = new Vector3(playerRB.velocity.x, 10, 0);
                JumpTimeCounter -= Time.deltaTime;

            }
            else
            {
                playerIsJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            playerIsJumping = false;
        }


    }

    private void OnDrawGizmos()
    {
        if (obstacleIsHit)
        {
            if (obstacleRayHit.transform.CompareTag("Ground"))
            {
                if (Mathf.Abs(obstacleRayHit.point.x - this.transform.position.x) < 5f)
                {
                    Gizmos.color = Color.red;
                }
                else
                {
                    Gizmos.color = Color.green;
                }
            }


            if (playerDirection)
            {
                Gizmos.DrawRay(transform.position, Vector3.right * obstacleRayHit.distance);
                Gizmos.DrawWireCube(transform.position + Vector3.right * obstacleRayHit.distance, new Vector3(transform.localScale.x / 5f, transform.localScale.y, transform.localScale.z));
            }
            else
            {
                Gizmos.DrawRay(transform.position, Vector3.left * obstacleRayHit.distance);
                Gizmos.DrawWireCube(transform.position + Vector3.left * obstacleRayHit.distance, new Vector3(transform.localScale.x / 5f, transform.localScale.y, transform.localScale.z));
            }

        }

        /*if (ennemisIsHit)
        {
            Gizmos.color = Color.green;

            if (playerDirection)
            {
                Gizmos.DrawRay(transform.position, Vector3.right * ennemisRayHit.distance);

            }
            else
            {
                Gizmos.DrawRay(transform.position, Vector3.left * ennemisRayHit.distance);

            }
        }*/
        //Debug.Log(playerRB.velocity.x);
    }

    public void FixedUpdate()
    {
        // Jump

        if (playerRB.velocity.y < 0)
        {
            playerRB.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (playerRB.velocity.y > 0 && gameController.Gameplay.Jump.enabled)
        {
            playerRB.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }




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


        if (gameController.Gameplay.Move.ReadValue<float>() < 0 && playerDirection)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            playerDirection = false;
        }
        else if (gameController.Gameplay.Move.ReadValue<float>() > 0 && !playerDirection)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerDirection = true;
        }

        // Player Dash

        if (playerDashTime > 0)
        {
            if (playerDirection && playerIsAttacked)
            {
                playerRB.velocity = (Vector3.left * playerDashSpeed * Time.deltaTime);
            }
            else if (!playerDirection && playerIsAttacked)
            {
                playerRB.velocity = (Vector3.right * playerDashSpeed * Time.deltaTime);
            }
            else if (playerDirection && !playerIsAttacked)
            {
                playerRB.velocity = (Vector3.right * playerDashSpeed * Time.deltaTime);
            }
            else if (!playerDirection && !playerIsAttacked)
            {
                playerRB.velocity = (Vector3.left * playerDashSpeed * Time.deltaTime);
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
        if (collision.transform.CompareTag("Wall") && isDashing)
        {
            Destroy(collision.gameObject);
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
        }
    }


    IEnumerator Invincibility(float time)
    {
        playerIsInvincible = true;
        yield return new WaitForSeconds(time);
        playerIsInvincible = false;
    }
    IEnumerator Damage_Push(float time)
    {
        playerIsAttacked = true;
        yield return new WaitForSeconds(time);
        playerIsAttacked = false;
    }

    IEnumerator UnBlocker(float time)
    {
        if (playerDirection)
        {
            playerRB.AddForce(Vector3.left * 3000);
        }
        else
        {
            playerRB.AddForce(Vector3.right * 3000);
        }
        yield return new WaitForSeconds(time);
    }



    public void Power_Dash()
    {
        playerDashTime = playerBaseDashTime;
    }

    public void Power_Jump()
    {
        playerRB.velocity = new Vector3(playerRB.velocity.x, 0, 0);
        playerRB.AddForce(Vector3.up * playerJumpHeight, ForceMode.Impulse);
    }

    public void Power_Bump()
    {

        if (ennemisIsHit && ennemisRayHit.transform.CompareTag("Ennemis"))
        {
            ennemisRayHit.transform.GetComponent<EnnemisScript>().ennemisPushTime = bumpTime;
        }

    }
}
