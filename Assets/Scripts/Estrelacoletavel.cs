using UnityEngine;

public class EstrelaColetavel : MonoBehaviour
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

            Destroy(gameObject);
        }
    }
}