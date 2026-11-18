using UnityEngine;

public class ColetaMoeda : MonoBehaviour
{
    [Header("Configuração da Estrela")]
    [SerializeField] private int valor = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GerenciadorHUD hud = FindFirstObjectByType<GerenciadorHUD>();
            if (hud != null)
            {
                hud.AdicionarEstrelas(valor);
            }

            if (GerenciadorDeSons.Instance != null)
            {
                GerenciadorDeSons.Instance.TocarSomColeta();
            }

            Destroy(gameObject);
        }
    }
}