using UnityEngine;

public class PuzzlePergaminho : MonoBehaviour
{
    public static PuzzlePergaminho Instancia;

    [Header("Peças do Pergaminho")]
    [SerializeField] private PecaArrastavel[] pecas;

    [Header("Mensagem de Sucesso no Painel")]
    [Tooltip("Arraste aqui o TextMeshPro/GameObject de 'Pergaminho Restaurado'")]
    [SerializeField] private GameObject mensagemPergaminhoConcluido;

    [Header("Painéis de UI")]
    [SerializeField] private GameObject painelPergaminho;
    [SerializeField] private GameObject painelFragmento1;

    [Header("Configurações")]
    [SerializeField] private float tempoExibicaoFragmento = 4f;

    private bool puzzleConcluido = false;

    private void Awake()
    {
        Instancia = this;
    }

    private void Start()
    {
        if (mensagemPergaminhoConcluido != null)
        {
            mensagemPergaminhoConcluido.SetActive(false);
        }

        if (painelFragmento1 != null)
        {
            painelFragmento1.SetActive(false);
        }
    }

    public void VerificarVitoriaGeral()
    {
        if (puzzleConcluido) return;

        // Verifica se todas as peças estão encaixadas
        foreach (var peca in pecas)
        {
            if (peca != null && !peca.EstaEncaixada)
            {
                return;
            }
        }

        puzzleConcluido = true;

        if (mensagemPergaminhoConcluido != null)
        {
            mensagemPergaminhoConcluido.SetActive(true);
        }

        // Toca o som de resposta correta/sucesso do fragmento recuperado
        if (GerenciadorDeSons.Instance != null)
        {
            GerenciadorDeSons.Instance.TocarSomRespostaCorreta();
        }

        // FECHAMENTO DO PUZZLE E ABERTURA DIRETA DO PAINEL AZUL
        if (painelPergaminho != null)
        {
            painelPergaminho.SetActive(false); // Fecha o painel do minigame
        }

        if (painelFragmento1 != null)
        {
            painelFragmento1.SetActive(true); // Abre direto o painel azul do fragmento
        }

        Debug.Log("Pergaminho concluído com sucesso e fragmento exibido!");
    }

    // Mantido caso o jogador feche manualmente antes de terminar
    public void ClicarBotaoSair()
    {
        if (mensagemPergaminhoConcluido != null)
        {
            mensagemPergaminhoConcluido.SetActive(false);
        }

        if (painelPergaminho != null)
        {
            painelPergaminho.SetActive(false);
        }

        // Garante que se o puzzle acabou, o painel azul abre ao clicar no botão
        if (puzzleConcluido && painelFragmento1 != null)
        {
            painelFragmento1.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    private void EsconderFragmento1()
    {
        if (painelFragmento1 != null)
        {
            painelFragmento1.SetActive(false);
        }

        // Devolve o tempo e permite a movimentação do personagem na cena
        Time.timeScale = 1f;
    }
}