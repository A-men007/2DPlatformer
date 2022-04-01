using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Initalize variables
    private Rigidbody2D rigidbody;
    private BoxCollider2D collider;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float movement = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum movementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = new Vector2(dirX * movement, rigidbody.velocity.y);
        
        if (Input.GetButtonDown("Jump") && IsGrounded())  
        {
            jumpSoundEffect.Play();
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    // UpdateAnimationState is for updating the player animation
    private void UpdateAnimationState()
    {
        movementState state;

        // Moving right
        if (dirX > 0f)
        {
            state = movementState.running;
            sprite.flipX = false;
        }
        // Moving left
        else if (dirX < 0f)
        {
            state = movementState.running;
            sprite.flipX = true;
        }
        // Idle
        else
        {
            state = movementState.idle;
        }

        if (rigidbody.velocity.y > .1f)
        {
            state = movementState.jumping;
        } 
        else if (rigidbody.velocity.y < -.1f)
        {
            state = movementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    // IsGround is for checking if the player is on the ground
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}




