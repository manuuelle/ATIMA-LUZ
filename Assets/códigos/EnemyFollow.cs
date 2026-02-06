using UnityEngine;

public class EnemyFollow2D : MonoBehaviour
{
    [Header("Referências")]
    public Transform player;       // Arraste o Player no Inspector
    private Rigidbody2D rb;

    [Header("Configurações")]
    public float velocidade = 3f;      // Velocidade do inimigo
    public float distanciaParar = 1f;  // Distância mínima para parar

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("O inimigo precisa de um Rigidbody2D!");
        }
    }

    void Update()
    {
        if (player == null) return;

        // Calcula direção horizontal (ignora Y para seguir só no chão)
        float direcaoX = player.position.x - transform.position.x;

        // Se estiver longe, move
        if (Mathf.Abs(direcaoX) > distanciaParar)
        {
            float movimento = Mathf.Sign(direcaoX) * velocidade;
            rb.linearVelocity = new Vector2(movimento, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }

        // Flip horizontal
        if (rb.linearVelocity.x > 0.1f)
            transform.localScale = new Vector3(1, 1, 1);
        else if (rb.linearVelocity.x < -0.1f)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}
