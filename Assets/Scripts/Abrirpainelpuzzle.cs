using UnityEngine;

public class AbrirPainelArquivo : MonoBehaviour
{
    [Header("UI")]
    [Tooltip("Arraste o seu Painel (GameObject) do Canvas para cá.")]
    public GameObject painelArquivo;

    void Start()
    {
        // Garante que o painel comece fechado no início do jogo
        if (painelArquivo != null)
        {
            painelArquivo.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se quem colidiu foi o jogador
        if (collision.CompareTag("Player"))
        {
            AbrirPainel();
        }
    }

    public void AbrirPainel()
    {
        if (painelArquivo != null)
        {
            painelArquivo.SetActive(true);
            Time.timeScale = 0f; // Pausa a movimentação e a física do jogo
        }
    }

    // Chame este método no evento On Click () do botão de fechar o painel
    public void FecharPainel()
    {
        if (painelArquivo != null)
        {
            painelArquivo.SetActive(false);
        }
        Time.timeScale = 1f; // Reativa a movimentação da personagem
    }
}