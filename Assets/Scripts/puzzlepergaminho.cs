using UnityEngine;
using System.Collections;

public class PuzzlePergaminho : MonoBehaviour
{
    [System.Serializable]
    public class PecaPergaminho
    {
        public RectTransform pecaTransform; // O RectTransform da peça da UI
        public Vector2 posicaoCorreta;      // Posição AnchoredPosition correta no Canvas
        public float tolerancia = 10f;       // Margem de erro em pixels para validar
    }

    [Header("Peças do Puzzle")]
    [SerializeField] private PecaPergaminho[] pecas;

    [Header("Painéis de UI")]
    [Tooltip("Arraste aqui o GameObject do Painel do Pergaminho/Arquivo")]
    [SerializeField] private GameObject painelPergaminho;

    [Tooltip("Arraste aqui o GameObject do Painel 'Fragmento 1 Recuperado'")]
    [SerializeField] private GameObject painelFragmento1;

    [Header("Configurações do Puzzle")]
    [SerializeField] private float passoMovimento = 50f; // Distância que a peça anda por clique
    [SerializeField] private float tempoExibicaoFragmento = 4f;

    private int pecaSelecionadaIndex = 0;
    private bool puzzleConcluido = false;

    private void OnEnable()
    {
        puzzleConcluido = false;
    }

    // --- MÉTODOS DAS SETAS DE MOVIMENTAÇÃO ---

    // Conecte este método no botão da Seta para a Esquerda
    public void MoverEsquerda()
    {
        MoverPecaAtual(new Vector2(-passoMovimento, 0));
    }

    // Conecte este método no botão da Seta para a Direita
    public void MoverDireita()
    {
        MoverPecaAtual(new Vector2(passoMovimento, 0));
    }

    // Conecte este método no botão da Seta para Cima
    public void MoverCima()
    {
        MoverPecaAtual(new Vector2(0, passoMovimento));
    }

    // Conecte este método no botão da Seta para Baixo
    public void MoverBaixo()
    {
        MoverPecaAtual(new Vector2(0, -passoMovimento));
    }

    // Define qual peça as setas vão mover (chame ao clicar na peça correspondente)
    public void SelecionarPeca(int index)
    {
        if (index >= 0 && index < pecas.Length)
        {
            pecaSelecionadaIndex = index;
        }
    }

    private void MoverPecaAtual(Vector2 deslocamento)
    {
        if (puzzleConcluido || pecas == null || pecas.Length == 0) return;

        PecaPergaminho peca = pecas[pecaSelecionadaIndex];
        if (peca != null && peca.pecaTransform != null)
        {
            // Move a peça ignorando a pausa de tempo (Time.timeScale = 0)
            peca.pecaTransform.anchoredPosition += deslocamento;
            VerificarVitoria();
        }
    }

    // --- VERIFICAÇÃO DE MONTAGEM DO PERGAMINHO ---

    public void VerificarVitoria()
    {
        if (puzzleConcluido) return;

        foreach (var peca in pecas)
        {
            if (peca.pecaTransform == null) return;

            float distancia = Vector2.Distance(peca.pecaTransform.anchoredPosition, peca.posicaoCorreta);
            if (distancia > peca.tolerancia)
            {
                return; // Se pelo menos uma peça estiver fora do lugar, ainda não venceu
            }
        }

        // Se todas as peças estiverem nos lugares corretos:
        puzzleConcluido = true;
        ConcluirDesafioEExibirFragmento();
    }

    // --- FLUXO DE CONCLUSÃO E EXIBIÇÃO DO FRAGMENTO 1 ---

    public void ConcluirDesafioEExibirFragmento()
    {
        // 1. Esconde o painel do pergaminho
        if (painelPergaminho != null)
        {
            painelPergaminho.SetActive(false);
        }

        // 2. Exibe o painel do Fragmento 1
        if (painelFragmento1 != null)
        {
            painelFragmento1.SetActive(true);
            StartCoroutine(OcultarFragmentoAposTempo());
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    // Conecte também ao botão "Fechar" manual do Painel Pergaminho (caso queira fechar antes)
    public void FecharPainelPergaminhoEExibirFragmento()
    {
        ConcluirDesafioEExibirFragmento();
    }

    private IEnumerator OcultarFragmentoAposTempo()
    {
        // Aguarda os segundos configurados ignorando Time.timeScale = 0
        yield return new WaitForSecondsRealtime(tempoExibicaoFragmento);

        if (painelFragmento1 != null)
        {
            painelFragmento1.SetActive(false);
        }

        // Devolve o controle e a movimentação da personagem na cena
        Time.timeScale = 1f;
    }
}