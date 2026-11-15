using UnityEngine;
using UnityEngine.EventSystems;

public class GerenciadorJogoSilhuetas : MonoBehaviour
{
    [Header("Painéis")]
    public GameObject painelExplicacao;   // O painel de instruções inicial
    public GameObject painelSilhuetas;    // O painel do livro/minigame das silhuetas

    [Header("Controle do Player")]
    public MonoBehaviour scriptMovimentoPlayer; // Arraste o script de movimento da sua personagem aqui

    [Header("Controle do Minigame")]
    public int totalDePecas = 4;          // Quantas peças o minigame tem no total (ex: 4 estatuetas)
    private int pecasCorretasAcertadas = 0; // Contador interno de peças corretas

    // 1. Função chamada pelo botão "JOGAR" para iniciar o minigame
    public void Jogar()
    {
        // Fecha o painel de explicação
        if (painelExplicacao != null)
        {
            painelExplicacao.SetActive(false);
        }

        // Abre o painel do minigame das silhuetas
        if (painelSilhuetas != null)
        {
            painelSilhuetas.SetActive(true);
        }

        // Desativa o movimento da personagem enquanto ela joga
        if (scriptMovimentoPlayer != null)
        {
            scriptMovimentoPlayer.enabled = false;
        }

        // Reseta o contador ao iniciar
        pecasCorretasAcertadas = 0;
    }

    // 2. Chame esta função a cada vez que o jogador acertar uma peça (coloque nos scripts de arrastar/soltar das peças)
    public void RegistrarAcertoPeca()
    {
        pecasCorretasAcertadas++;
        Debug.Log("Peça correta encaixada! Total: " + pecasCorretasAcertadas + "/" + totalDePecas);

        // Se atingiu o total de peças, conclui o minigame automaticamente sozinho!
        if (pecasCorretasAcertadas >= totalDePecas)
        {
            ConcluirMinigame();
        }
    }

    // 3. Função que fecha tudo e libera a personagem
    public void ConcluirMinigame()
    {
        // Fecha o painel do minigame
        if (painelSilhuetas != null)
        {
            painelSilhuetas.SetActive(false);
        }

        // Tenta ativar o script de movimento da personagem
        if (scriptMovimentoPlayer != null)
        {
            scriptMovimentoPlayer.enabled = true;
            Debug.Log(">>> SUCESSO: Minigame concluído automaticamente e o script Jogador foi ATIVADO!");
        }
        else
        {
            Debug.LogError(">>> ERRO: O campo 'Script Movimento Player' está VAZIO no Inspector do Gerenciador!");
        }

        // Remove qualquer foco de UI para o teclado voltar a controlar a personagem
        if (EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}