using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AndarDireitaEsquerda2D : MonoBehaviour
{
    [Header("Movimento (Direita / Esquerda)")]
    public float velocidade = 5f;
    [Tooltip("Marque se o sprite original já está olhando para a esquerda.")]
    public bool spriteJaOlhaParaEsquerda = false;
    public bool virarSpriteComFlipX = false;

    [Header("Animação (Opcional)")]
    public Animator animator;
    public string parametroAndando = "Andando";

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float moverX;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Jogador.travadoNoMinigame)
        {
            moverX = 0f;
            AtualizarAnimacao(false);
            return;
        }

        // Esquerda = -1 (vai da direita para a esquerda), Direita = +1
        moverX = Input.GetAxisRaw("Horizontal");

        if (virarSpriteComFlipX && spriteRenderer != null && Mathf.Abs(moverX) > 0.01f)
        {
            bool indoParaEsquerda = moverX < 0f;
            spriteRenderer.flipX = spriteJaOlhaParaEsquerda ? !indoParaEsquerda : indoParaEsquerda;
        }

        AtualizarAnimacao(Mathf.Abs(moverX) > 0.01f);
    }

    void FixedUpdate()
    {
        if (Jogador.travadoNoMinigame)
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
            return;
        }

        rb.linearVelocity = new Vector2(moverX * velocidade, rb.linearVelocity.y);
    }

    void AtualizarAnimacao(bool andando)
    {
        if (animator == null || string.IsNullOrEmpty(parametroAndando))
            return;

        animator.SetBool(parametroAndando, andando);
    }
}