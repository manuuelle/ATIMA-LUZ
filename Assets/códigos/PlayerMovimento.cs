using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 5f;
    public float forcaPulo = 8f;

    [Header("Checagem do chão")]
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Ataque")]
    public float tempoAtaque = 0.4f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    private float h;
    private bool noChao;
    private bool atacando = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");

        if (h > 0) sr.flipX = false;
        else if (h < 0) sr.flipX = true;

        // Verificar se está no chão
        noChao = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
        Debug.Log("no chão? " + noChao);

        // Pular quando apertar espaço e estiver no chão
        if (Input.GetKeyDown(KeyCode.Space) && noChao && !atacando)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
            anim.SetTrigger("jump");
        }

        // Ataque ao apertar Z (se não estiver atacando)
        if (Input.GetKeyDown(KeyCode.Z) && !atacando)
        {
            atacando = true;
            anim.SetTrigger("attack");
            Invoke(nameof(FimAtaque), tempoAtaque);

            // Opcional: interromper movimento durante ataque
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }

        // Atualizar parâmetros da animação
        anim.SetFloat("speed", Mathf.Abs(h));
        anim.SetBool("isGrounded", noChao);
    }

    void FixedUpdate()
    {
        // Movimento horizontal só se não estiver atacando
        if (!atacando)
        {
            rb.linearVelocity = new Vector2(h * velocidade, rb.linearVelocity.y);
        }
    }

    void FimAtaque()
    {
        atacando = false;
    }

    // Visualizar o groundCheck no editor
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        }
    }
}
