using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PainelLivrao : MonoBehaviour
{
    [Header("Painel do Livrão")]
    public GameObject painelLivro;
    public bool travarMovimentoPlayerAoAbrir = true;
    public MonoBehaviour scriptMovimentoPlayer;

    [Header("Jogar Novamente")]
    public Button botaoJogarNovamente;
    [Tooltip("Deixe vazio para recarregar a cena atual ou digite o nome da cena inicial.")]
    public string nomeCenaReiniciar = "";

    void Start()
    {
        if (painelLivro != null)
            painelLivro.SetActive(false);

        if (botaoJogarNovamente != null)
        {
            botaoJogarNovamente.onClick.RemoveAllListeners();
            botaoJogarNovamente.onClick.AddListener(JogarNovamente);
        }
    }

    void OnMouseDown()
    {
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            return;

        AbrirLivro();
    }

    public void AbrirLivro()
    {
        if (painelLivro != null)
        {
            painelLivro.SetActive(true);
            painelLivro.transform.SetAsLastSibling();
        }

        if (travarMovimentoPlayerAoAbrir)
        {
            Jogador.travadoNoMinigame = true;

            if (scriptMovimentoPlayer != null)
                scriptMovimentoPlayer.enabled = false;
        }
    }

    public void FecharLivro()
    {
        if (painelLivro != null)
            painelLivro.SetActive(false);

        Jogador.travadoNoMinigame = false;

        if (scriptMovimentoPlayer != null)
            scriptMovimentoPlayer.enabled = true;

        if (EventSystem.current != null)
            EventSystem.current.SetSelectedGameObject(null);
    }

    // Ligue esta função no OnClick() do botão "Jogar Novamente"
    public void JogarNovamente()
    {
        Debug.Log(">>> CLIQUE NO BOTAO JOGAR NOVAMENTE DETECTADO!");
        Time.timeScale = 1f;
        Jogador.travadoNoMinigame = false;

        if (!string.IsNullOrEmpty(nomeCenaReiniciar))
            SceneManager.LoadScene(nomeCenaReiniciar);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}