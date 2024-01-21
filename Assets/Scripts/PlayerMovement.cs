using Assets.Enums;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rbPlayer;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float moveHorizontal = 0f;
    // It is possible add a property into the Unity using the word "SerializeField". The same happen with the public reserved word, but the difference is the 
    // property could be access from other scripts.
    // For nomenclature, the property inside of Unity is not necessary include the Value word in the name of the variable.
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] private float jump = 14f;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        rbPlayer.velocity = new Vector2(moveHorizontal * moveSpeed, rbPlayer.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
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
}
