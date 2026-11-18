using UnityEngine;

public class ControleAnimacao : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float movimento = Input.GetAxisRaw("Horizontal");

        if (movimento != 0)
        {
            animator.SetBool("Andando", true);
        }
        else
        {
            animator.SetBool("Andando", false);
        }
    }
}