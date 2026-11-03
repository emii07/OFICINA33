using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorMapa : MonoBehaviour
{
    [Header("Nomes Exatos das Cenas (no Build Settings)")]
    [SerializeField] private string nomeSalaGrandesPersonagens = "Sala dos grandes personagens";
    [SerializeField] private string nomeSalaIntelectuais = "sala dos intelectuais";
    [SerializeField] private string nomeSalaValeEngenhos = "vale dos engenhos";

    public void AbrirSalaGrandesPersonagens()
    {
        Debug.Log("Tentando abrir: " + nomeSalaGrandesPersonagens);
        CarregarCena(nomeSalaGrandesPersonagens);
    }

    public void AbrirSalaIntelectuais()
    {
        Debug.Log("Tentando abrir: " + nomeSalaIntelectuais);
        CarregarCena(nomeSalaIntelectuais);
    }

    public void AbrirSalaValeEngenhos()
    {
        Debug.Log("Tentando abrir: " + nomeSalaValeEngenhos);
        CarregarCena(nomeSalaValeEngenhos);
    }

    private void CarregarCena(string nomeDaCena)
    {
        Time.timeScale = 1f;

        if (!string.IsNullOrEmpty(nomeDaCena))
        {
            SceneManager.LoadScene(nomeDaCena);
        }
        else
        {
            Debug.LogError("O nome da cena está vazio!");
        }
    }
}