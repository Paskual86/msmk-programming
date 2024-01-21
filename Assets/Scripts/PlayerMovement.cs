using Assets.Enums;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rbPlayer;
    private BoxCollider2D colliderPlayer;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float moveHorizontal = 0f;

    [SerializeField] private LayerMask jumpableGround;
    // It is possible add a property into the Unity using the word "SerializeField". The same happen with the public reserved word, but the difference is the 
    // property could be access from other scripts.
    // For nomenclature, the property inside of Unity is not necessary include the Value word in the name of the variable.
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] private float jump = 14f;

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        colliderPlayer = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        rbPlayer.velocity = new Vector2(moveHorizontal * moveSpeed, rbPlayer.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && (IsGrounded()))
        {
            jumpSoundEffect.Play();
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, jump);
        }
        UpdateAnimation();
    }

    private void UpdateAnimation() 
    {
        MovementState state;

        state = (moveHorizontal != 0f) ? MovementState.running : MovementState.idle;
        
        if (rbPlayer.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }else if (rbPlayer.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        spriteRenderer.flipX = (moveHorizontal < 0f);

        animator.SetInteger("state", (int)state);
    }

    private bool IsGrounded() 
    {
        return Physics2D.BoxCast(colliderPlayer.bounds.center, colliderPlayer.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    } 
}
