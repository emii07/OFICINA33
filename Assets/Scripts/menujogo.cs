using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GerenciadorJogoSilhuetas : MonoBehaviour
{
    [Header("Painéis")]
    public GameObject painelExplicacao;   // O painel de instruções inicial
    public GameObject painelSilhuetas;    // O painel do livro/minigame das silhuetas
    public GameObject painelVitoria;      // Ex.: painelvitoriaestauta

    [Header("Próxima Cena")]
    public string nomeProximaCena;        // Nome exato da próxima cena

    [Header("Controle do Player")]
    public MonoBehaviour scriptMovimentoPlayer; // Arraste o script de movimento da sua personagem aqui

    [Header("Controle do Minigame")]
    public int totalDePecas = 4;          // Quantas peças o minigame tem no total
    private int pecasCorretasAcertadas = 0; // Contador interno de peças corretas
    private bool minigameConcluido = false;

    void Start()
    {
        if (painelVitoria != null)
        {
            painelVitoria.SetActive(false);
        }
    }

    // 1. Função chamada pelo botão "JOGAR" para iniciar o minigame
    public void Jogar()
    {
        minigameConcluido = false;
        pecasCorretasAcertadas = 0;

        if (painelVitoria != null)
        {
            painelVitoria.SetActive(false);
        }

        if (painelExplicacao != null)
        {
            painelExplicacao.SetActive(false);
        }

        if (painelSilhuetas != null)
        {
            painelSilhuetas.SetActive(true);
        }

        if (scriptMovimentoPlayer != null)
        {
            scriptMovimentoPlayer.enabled = false;
        }
    }

    // 2. Chame esta função a cada vez que o jogador acertar uma peça
    public void RegistrarAcertoPeca()
    {
        if (minigameConcluido) return;

        pecasCorretasAcertadas++;
        Debug.Log("Peça correta encaixada! Total: " + pecasCorretasAcertadas + "/" + totalDePecas);

        if (pecasCorretasAcertadas >= totalDePecas)
        {
            ConcluirMinigame();
        }
    }

    // 3. Libera a personagem e mostra o painel de vitória
    public void ConcluirMinigame()
    {
        if (minigameConcluido) return;
        minigameConcluido = true;

        Jogador.travadoNoMinigame = false;

        if (scriptMovimentoPlayer != null)
        {
            scriptMovimentoPlayer.enabled = true;
            Debug.Log(">>> SUCESSO: Minigame concluído e movimento do jogador liberado!");
        }
        else
        {
            Debug.LogError(">>> ERRO: O campo 'Script Movimento Player' está VAZIO no Inspector do Gerenciador!");
        }

        if (EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }

        if (painelVitoria != null)
        {
            painelVitoria.SetActive(true);
            painelVitoria.transform.SetAsLastSibling();
        }
    }

    // 4. Ligue esta função no OnClick() do botão dentro do painel de vitória
    public void ContinuarParaProximaCena()
    {
        Jogador.travadoNoMinigame = false;

        if (scriptMovimentoPlayer != null)
        {
            scriptMovimentoPlayer.enabled = true;
        }

        if (painelVitoria != null)
        {
            painelVitoria.SetActive(false);
        }

        if (painelSilhuetas != null)
        {
            painelSilhuetas.SetActive(false);
        }

        if (!string.IsNullOrEmpty(nomeProximaCena))
        {
            SceneManager.LoadScene(nomeProximaCena);
        }
        else
        {
            Debug.LogWarning(">>> AVISO: 'Nome Proxima Cena' está vazio no GerenciadorJogoSilhuetas.");
        }
    }
}