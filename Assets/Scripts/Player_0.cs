using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Player_0 : MonoBehaviour
{

    // The Rewired player id of this character
    public int playerId = 0;

    // The movement speed of this character
    public float moveSpeed = 3.0f;
    // The Force of a jump 
    public float jumpForce = 3.0f;

    [SerializeField] private bool isMouseControl;

    //var For Inputs
    private Player player; // The Rewired Player*
    private Vector3 moveVector;
    private Vector3 aimVector;
    private bool jump;
    private bool attack;

    //Rigidbody
    private Rigidbody2D rb;

    //var for Jump
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float checkGroundRadius;
    [SerializeField] private LayerMask whatIsGround;
    private float jumpTimeCounter;
    [SerializeField] private float jumpTime;
    [SerializeField] private bool isJumping;

    //var for Attack
    [SerializeField] private GameObject attackPos;
    [SerializeField] private float attackRadius;
    [SerializeField] private float attackReach;
    [SerializeField] private float attackCooldown;
    [SerializeField] private LayerMask enemyLayers;

    private void Start()
    {
        // Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
        player = ReInput.players.GetPlayer(playerId);

        rb = GetComponent<Rigidbody2D>();

        //set the pos for the arrow/attackpos
        attackPos.transform.localPosition = new Vector3(attackReach, 0);
    }

    private void Update()
    {
        //Check if grounded
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkGroundRadius, whatIsGround);

        GetInput();
        ProcessInput();
    }

    private void GetInput()
    {
        // Get the input from the Rewired Player. All controllers that the Player owns will contribute, so it doesn't matter
        // whether the input is coming from a joystick, the keyboard, mouse, or a custom controller.

        moveVector.x = player.GetAxis("Mouvement Horizontal"); // get input by name or action id
        //moveVector.y = player.GetAxis("Mouvement Vertical");

        aimVector.x = player.GetAxis("Aim Horizontal");
        aimVector.y = player.GetAxis("Aim Vertical");

        jump = player.GetButton("Jump");
        attack = player.GetButtonDown("Attack");
    }

    private void ProcessInput()
    {
        // Process movement
        if (moveVector.x != 0.0f || moveVector.y != 0.0f)
        {
            rb.velocity = new Vector2(moveVector.x * moveSpeed, rb.velocity.y);
        }

        // Process Jump
        if (jump && isGrounded)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = new Vector2(rb.velocity.x, 1 * jumpForce);
        }
        
        if (jump && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 1 * jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (!jump)
        {
            isJumping = false;
        }

        //Process Attack
        if (attack)
        {
            Debug.Log("attack");
            Collider2D[] hitEnnemies = Physics2D.OverlapCircleAll(attackPos.transform.position, attackRadius, enemyLayers);

            foreach (Collider2D enemy in hitEnnemies)
            {
                Debug.Log("We hit " + enemy.name);
            }
        }

        //Process Aim
        if (aimVector.x > 0.01f || aimVector.y > 0.01f || aimVector.x < -0.01f || aimVector.y < -0.01f)
        {
            float aimAngle;

            if (isMouseControl)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 playerToMouse = new Vector3( mousePos.x - transform.position.x, mousePos.y - transform.position.y);
                aimVector = playerToMouse.normalized;
            }

            aimAngle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg;
            attackPos.transform.localPosition = new Vector3( attackReach * Mathf.Cos(aimAngle * Mathf.Deg2Rad), attackReach * Mathf.Sin(aimAngle * Mathf.Deg2Rad));
            attackPos.transform.eulerAngles = new Vector3(0, 0, aimAngle);
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPos == null)
        {
            return;
        }

        //Attack Radius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.transform.position, attackRadius);

        //Attack Reach
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackReach);
    }
    private void OnDrawGizmos()
    {


        Gizmos.DrawLine(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        //Gizmos.DrawWireSphere(Camera.main.ScreenToWorldPoint(Input.mousePosition), 1);
    }
}
