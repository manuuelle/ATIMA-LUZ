using UnityEngine;

public class PlayerAnimacao : MonoBehaviour
{
    private Animator anim;

    [Header("Chão")]
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    private bool isGrounded;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // MOVIMENTO
        float h = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(h));

        // CHÃO
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            groundLayer
        );
        anim.SetBool("isGrounded", isGrounded);

        // PULO (ANIMAÇÃO)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            anim.SetTrigger("jump");
        }

        // ATAQUE
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("attack");
        }
    }
}
