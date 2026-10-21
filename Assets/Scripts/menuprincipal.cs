using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Nome da Cena do Jogo")]
    [SerializeField] private string nomeDaCenaDoJogo = "Jogo"; // Nome exato da sua cena

    [Header("Painéis da Interface")]
    [SerializeField] private GameObject painelConfiguracoes;
    [SerializeField] private GameObject painelCreditos;

    // --- MÉTODOS DO BOTÃO JOGAR ---
    public void Jogar()
    {
        // Carrega a cena do jogo
        SceneManager.LoadScene(nomeDaCenaDoJogo);
    }

    // --- MÉTODOS DO PAINEL DE CONFIGURAÇÕES ---
    public void AbrirConfiguracoes()
    {
        painelConfiguracoes.SetActive(true);
        if (painelCreditos != null) painelCreditos.SetActive(false);
    }

    public void FecharConfiguracoes()
    {
        painelConfiguracoes.SetActive(false);
    }

    // --- MÉTODOS DO PAINEL DE CRÉDITOS ---
    public void AbrirCreditos()
    {
        painelCreditos.SetActive(true);
        if (painelConfiguracoes != null) painelConfiguracoes.SetActive(false);
    }

    public void FecharCreditos()
    {
        painelCreditos.SetActive(false);
    }
}