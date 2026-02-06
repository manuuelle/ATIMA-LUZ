using UnityEngine;

public class EnemyAudioTrigger : MonoBehaviour
{
    [Header("Referências")]
    public Transform player;         // Arraste o Player aqui no Inspector
    public AudioSource audioSource;  // O AudioSource do inimigo

    [Header("Configurações")]
    public float distanciaTrigger = 5f;  // Distância mínima para tocar o áudio

    private bool audioTocando = false;   // Flag para não reiniciar audio toda hora

    void Update()
    {
        if (player == null || audioSource == null)
            return;

        // Calcula distância do Player
        float distancia = Vector2.Distance(transform.position, player.position);

        // Se o player estiver perto e o áudio não estiver tocando
        if (distancia <= distanciaTrigger && !audioTocando)
        {
            audioSource.Play();
            audioTocando = true;
        }

        // Se o player sair da área, para o áudio (opcional)
        if (distancia > distanciaTrigger && audioTocando)
        {
            audioSource.Stop();
            audioTocando = false;
        }
    }

    // Opcional: desenhar a área de detecção no Scene
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanciaTrigger);
    }
}
