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
            if (painelArquivo != null)
            {
                painelArquivo.SetActive(true);
            }
        }
    }
}