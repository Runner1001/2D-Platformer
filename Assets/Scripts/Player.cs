using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event Action<int> OnHealthChange; 

    [SerializeField] private int playerNumber;
    [SerializeField] private int maxHealth;
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpVelocity = 20;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float radius;
    [SerializeField] private int maxJumps;
    [SerializeField] private float climbingVelocity;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask climbLayer;

    private Rigidbody2D rb;
    private Animator anim;
    private float horizontal;
    private float vertical;
    private bool isGrounded;
    private Collider2D hit;
    private Vector2 startPosition;
    private int jumpsLeft;
    private float fallTimer;
    private bool isClimbing;
    private float defaultGravity;
    private int currentHealth;
    private string playerHorizontal;
    private string playerVertical;
    private string playerJumpButton;

    public int PlayerNumber { get { return playerNumber; } }
    public int Direction { get; private set; }

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();  
        anim = GetComponent<Animator>();   
        startPosition = transform.position;  
        jumpsLeft = maxJumps;  
        defaultGravity = rb.gravityScale;
        currentHealth = maxHealth; 
        OnHealthChange?.Invoke(currentHealth); 
        playerHorizontal = $"P{playerNumber}Horizontal";
        playerVertical = $"P{playerNumber}Vertical";
        playerJumpButton = $"P{playerNumber}Jump";
        Direction = 1;
    }

    

    void Update() 
    {
        horizontal = Input.GetAxisRaw(playerHorizontal); 
        vertical = Input.GetAxisRaw(playerVertical);

        CheckGround();

        Movement();
        Jump();
        Climbing();
        UpdateAnimator();
        UpdateSprite();

    }

    private void CheckGround() 
    {
        hit = Physics2D.OverlapCircle(feetPos.position, radius, groundLayer);                                                                                                                                                                                                                        

        isGrounded = hit != null; 
    }

    private void Movement()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); 
    }

    private void Jump()
    {
        if (Input.GetButtonDown(playerJumpButton) && jumpsLeft > 0 && !isClimbing) 
        {
            jumpsLeft--; 
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity); 
            fallTimer = 0;
        }

        if (isGrounded && fallTimer > 0.05) 
        {
            fallTimer = 0;  
            jumpsLeft = maxJumps; 
        }
        else
        {
            fallTimer += Time.deltaTime; 
        }
    }

    private void UpdateAnimator() 
    {
        bool isWalking = horizontal != 0; 

        anim.SetBool("IsWalking", isWalking); 
        anim.SetBool("IsGrounded", isGrounded); 
        anim.SetBool("IsClimbing", isClimbing);
    }

    private void UpdateSprite() 
    {
        if (horizontal != 0)
        {
            if (horizontal < 0)
            {
                Direction = -1;
                transform.localScale = new Vector3(Direction, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                Direction = 1;
                transform.localScale = new Vector3(Direction, transform.localScale.y, transform.localScale.z);
            }
        }
    }

    public void TakeHit(int damage) 
    {
        if(currentHealth > 1) 
        {
            currentHealth -= damage; 
            OnHealthChange?.Invoke(currentHealth); 

            var lastCheckpoint = CheckpointManager.Instance.GetLastCheckpoint(); 
            if (lastCheckpoint != null) 
            {
                transform.position = lastCheckpoint.transform.position; 
            }
            else
            {
                transform.position = startPosition; 
            }
        }
        else
        {
            OnDie(); 
        }
    }

    private void OnDie()
    {
        transform.position = startPosition; 
        currentHealth = maxHealth;
        OnHealthChange?.Invoke(currentHealth);
    }

    private void Climbing()
    {
        if (rb.IsTouchingLayers(climbLayer))
        {
            rb.velocity = new Vector2(rb.velocity.x, vertical * climbingVelocity);
            rb.gravityScale = 0;
            isClimbing = vertical != 0;
        }
        else
        {
            rb.gravityScale = defaultGravity;
            isClimbing = false;
        }
    }

    public void Heal(int healAmount)  
    {
        currentHealth += healAmount;
        OnHealthChange?.Invoke(currentHealth); 
    }

    public void TeleportTo(Vector3 position) 
    {
        transform.position = position; 
    }
}
