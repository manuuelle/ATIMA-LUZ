using UnityEngine;

public class PlayerFlip : MonoBehaviour
{

    Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        Vector3 scale = transform.localScale;

        if (move > 0)
            scale.x = Mathf.Abs(scale.x);   // direita
        else if (move < 0)
            scale.x = -Mathf.Abs(scale.x);  // esquerda

        transform.localScale = scale;
    }
}
