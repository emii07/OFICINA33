using UnityEngine;
using UnityEngine.InputSystem;

public class Jogador : MonoBehaviour
{
    public float velocidade = 8f;
    public float forcaPulo = 18f;

    private Rigidbody2D rb;
    private bool noChao;

    public static bool travadoNoMinigame = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.gravityScale = 4f;
        }

        travadoNoMinigame = false;
    }

    void FixedUpdate()
    {
        if (travadoNoMinigame)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            return;
        }

        float movimento = 0;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed) movimento = -1;
            if (Keyboard.current.dKey.isPressed) movimento = 1;
        }

        rb.linearVelocity = new Vector2(
            movimento * velocidade,
            rb.linearVelocity.y
        );
    }

    void Update()
    {
        if (travadoNoMinigame) return;

        if (Keyboard.current != null &&
            Keyboard.current.spaceKey.wasPressedThisFrame &&
            noChao)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(
                Vector2.up * forcaPulo,
                ForceMode2D.Impulse
            );

            noChao = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            noChao = true;
        }
    }
}