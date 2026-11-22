using UnityEngine;

public class andardireitaesquerda : MonoBehaviour
{
    [Header("Movimento (Direita / Esquerda)")]
    public float velocidade = 5f;
    public bool spriteJaOlhaParaDireita = false;
    public bool virarSpriteComFlipX = false;

    [Header("Animação Direta")]
    public Animator animator;
    public string estadoParado = "respirando";
    public string estadoAndar = "andando";

    private float escalaBaseX;
    private SpriteRenderer spriteRenderer;
    private string estadoAtual = "";

    void Start()
    {
        escalaBaseX = Mathf.Abs(transform.localScale.x);
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (animator == null)
            animator = GetComponent<Animator>();

        TocarAnimacao(estadoParado);
    }

    void Update()
    {
        float movimentoX = Input.GetAxisRaw("Horizontal");

        // Move o personagem
        transform.position += new Vector3(movimentoX * velocidade * Time.deltaTime, 0f, 0f);

        // Vira o personagem sem estragar o tamanho (Scale)
        if (movimentoX != 0)
        {
            bool indoParaDireita = movimentoX > 0;

            if (virarSpriteComFlipX && spriteRenderer != null)
            {
                spriteRenderer.flipX = spriteJaOlhaParaDireita ? !indoParaDireita : indoParaDireita;
            }
            else
            {
                float sinal = (indoParaDireita == spriteJaOlhaParaDireita) ? 1f : -1f;
                transform.localScale = new Vector3(escalaBaseX * sinal, transform.localScale.y, transform.localScale.z);
            }

            TocarAnimacao(estadoAndar);
        }
        else
        {
            TocarAnimacao(estadoParado);
        }
    }

    void TocarAnimacao(string novoEstado)
    {
        if (animator == null || string.IsNullOrEmpty(novoEstado)) return;
        if (estadoAtual == novoEstado) return;

        estadoAtual = novoEstado;
        animator.Play(novoEstado);
    }
}