using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 boxSize;
    public LayerMask groundLayer;
    public float jumpVelocity = 1f;
    public float castDistance;
    public float rayCastAngle;
    public float playerGravityWhileFloating = 50;
    bool jumpInput;
    bool floatInput;
    bool isOnWallBool;
    public static float defaultGravityScale;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultGravityScale = rb.gravityScale;
    }

    void Update()
    {
        jumpInput = Input.GetButtonDown("Jump");
        floatInput = Input.GetButton("Jump");
        isOnWallBool = WallJump.IsOnWallBool;
    }
    private void FixedUpdate()
    {

        if (jumpInput && IsGrounded())
        {
            Jump();
        }

        if (floatInput && !IsGrounded() && !isOnWallBool && rb.linearVelocityY < 0)
        {
            PlayerFloat();
        }
        else rb.gravityScale = defaultGravityScale;

    }
    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
    }

    public void PlayerFloat()
    {
        rb.gravityScale = playerGravityWhileFloating / 100;
    }
    public bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, rayCastAngle, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position - transform.up * castDistance, boxSize);
    }
}


