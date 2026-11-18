using UnityEngine;

public class EstrelaColetavel : MonoBehaviour
{
    [Header("Configuração da Estrela")]
    [SerializeField] private int valor = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 1. Atualiza a HUD/Placard
            GerenciadorHUD hud = FindFirstObjectByType<GerenciadorHUD>();
            if (hud != null)
            {
                hud.AdicionarEstrelas(valor);
            }

            // 2. Toca o som de coleta através do Gerenciador centralizado
            if (GerenciadorDeSons.Instance != null)
            {
                GerenciadorDeSons.Instance.TocarSomColeta();
            }

            // 3. Destroi o objeto coletável da cena
            Destroy(gameObject);
        }
    }
}