using UnityEngine;

public class PlayerAnimacao : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        bool andando = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)
                    || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow);

        anim.SetFloat("speed", andando ? 1f : 0f);
    }
}
