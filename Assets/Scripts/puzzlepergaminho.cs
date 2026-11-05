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

        Debug.Log("Pergaminho concluído com sucesso!");
    }

    // LIGUE ESTE MÉTODOS AO EVENTO 'ON CLICK ()' DA SETA DE SAIR (BOTAO VOLTAR)
    public void ClicarBotaoSair()
    {
        // 1. Oculta o painel do pergaminho/arquivo e a mensagem interna
        if (mensagemPergaminhoConcluido != null)
        {
            mensagemPergaminhoConcluido.SetActive(false);
        }

        if (painelPergaminho != null)
        {
            painelPergaminho.SetActive(false);
        }

        // 2. Se o puzzle foi finalizado com sucesso, exibe o Fragmento 1
        if (puzzleConcluido && painelFragmento1 != null)
        {
            painelFragmento1.SetActive(true);

            // Executa o fechamento automático após os 4 segundos via Invoke no objeto deste script
            CancelInvoke(nameof(EsconderFragmento1));
            Invoke(nameof(EsconderFragmento1), tempoExibicaoFragmento);
        }
        else
        {
            // Se fechou sem completar
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