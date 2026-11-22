using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovimentoPersonagem2D : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidadeMovimento = 5f;
    public bool permitirDiagonal = true;

    [Header("Virar Personagem (Flip)")]
    public bool virarPelaEscala = true;
    public Transform alvoVisual;

    [Header("Animação (Opcional)")]
    public Animator animator;
    public string parametroVelocidade = "Velocidade";
    public string parametroAndando = "Andando";

    private Rigidbody2D rb;
    private Vector2 entrada;
    private bool olhandoDireita = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (alvoVisual == null)
            alvoVisual = transform;
    }

    void Update()
    {
        if (Jogador.travadoNoMinigame)
        {
            entrada = Vector2.zero;
            AtualizarAnimacao(0f);
            return;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = permitirDiagonal ? Input.GetAxisRaw("Vertical") : 0f;

        entrada = new Vector2(x, y);
        if (entrada.sqrMagnitude > 1f)
            entrada.Normalize();

        if (x > 0.01f && !olhandoDireita)
            Virar();
        else if (x < -0.01f && olhandoDireita)
            Virar();

        AtualizarAnimacao(entrada.magnitude);
    }

    void FixedUpdate()
    {
        if (Jogador.travadoNoMinigame)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        rb.linearVelocity = entrada * velocidadeMovimento;
    }

    void Virar()
    {
        olhandoDireita = !olhandoDireita;

        if (virarPelaEscala)
        {
            Vector3 escala = alvoVisual.localScale;
            escala.x *= -1f;
            alvoVisual.localScale = escala;
        }
        else
        {
            SpriteRenderer sr = alvoVisual.GetComponentInChildren<SpriteRenderer>();
            if (sr != null)
                sr.flipX = !sr.flipX;
        }
    }

    void AtualizarAnimacao(float velocidadeAtual)
    {
        if (animator == null)
            return;

        if (!string.IsNullOrEmpty(parametroVelocidade))
            animator.SetFloat(parametroVelocidade, velocidadeAtual);

        if (!string.IsNullOrEmpty(parametroAndando))
            animator.SetBool(parametroAndando, velocidadeAtual > 0.01f);
    }
}