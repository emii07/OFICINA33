using UnityEngine;

public class MostrarExplicacao : MonoBehaviour
{
    [Header("Referências")]
    public GameObject painelExplicacao;
    public GameObject personagem;

    private bool explicacaoConcluida = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (explicacaoConcluida)
            return;

        if (other.CompareTag("Player"))
        {
            // 1. Ativa o painel de explicação
            if (painelExplicacao != null)
            {
                painelExplicacao.SetActive(true);
            }

            // 2. Desativa apenas o script de movimento da personagem (ex: "PlayerMovement" ou o nome do seu script)
            // Substitua "PlayerMovement" pelo nome exato do script que movimenta a sua personagem
            MonoBehaviour scriptMovimento = personagem.GetComponent<MonoBehaviour>(); // Ou use o nome da sua classe de movimento
            if (scriptMovimento != null)
            {
                scriptMovimento.enabled = false;
            }

            // Opcional: Se quiser congelar a física para ela não escorregar
            Rigidbody2D rb = personagem.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.simulated = false;
            }
        }
    }

    public void ConcluirExplicacao()
    {
        explicacaoConcluida = true;

        // Reativa o movimento quando fechar o painel
        MonoBehaviour scriptMovimento = personagem.GetComponent<MonoBehaviour>();
        if (scriptMovimento != null)
        {
            scriptMovimento.enabled = true;
        }

        Rigidbody2D rb = personagem.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.simulated = true;
        }
    }
}