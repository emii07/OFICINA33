using UnityEngine;
using UnityEngine.UI;

public class PuzzleLivros : MonoBehaviour
{
    [Header("Referências")]
    [SerializeField] private PainelPuzzle1Controle controlePainel;
    [SerializeField] private GameObject personagem;
    [SerializeField] private Button botaoContinuar;

    [Header("Configurações")]
    [SerializeField] private int quantidadeLivrosNecessarios = 3;

    private int livrosCorretos;
    private bool puzzleAberto;

    private Rigidbody2D rb;
    private RigidbodyConstraints2D restricoesOriginais;

    private Renderer[] renderizadores;
    private bool[] visibilidadeOriginal;

    private bool referenciasValidas;

    private void Awake()
    {
        referenciasValidas = ValidarReferencias();

        if (!referenciasValidas)
            return;

        rb = personagem.GetComponent<Rigidbody2D>();

        if (rb == null)
            rb = personagem.GetComponentInChildren<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("PuzzleLivros: Rigidbody2D não encontrado!");
            referenciasValidas = false;
            return;
        }

        restricoesOriginais = rb.constraints;

        renderizadores =
            personagem.GetComponentsInChildren<Renderer>(true);

        visibilidadeOriginal = new bool[renderizadores.Length];

        for (int i = 0; i < renderizadores.Length; i++)
        {
            visibilidadeOriginal[i] = renderizadores[i].enabled;
        }

        controlePainel.Fechar();

        botaoContinuar.gameObject.SetActive(false);

        botaoContinuar.onClick.RemoveListener(FecharPuzzle);
        botaoContinuar.onClick.AddListener(FecharPuzzle);
    }

    private bool ValidarReferencias()
    {
        if (controlePainel == null ||
            personagem == null ||
            botaoContinuar == null)
        {
            Debug.LogError(
                "PuzzleLivros: Confira as referências no Inspector!",
                this
            );

            return false;
        }

        return true;
    }

    public bool AbrirPuzzle()
    {
        if (puzzleAberto)
            return true;

        if (!referenciasValidas)
            return false;

        // Tenta abrir o painel primeiro.
        if (!controlePainel.Abrir())
        {
            Debug.LogError("Puzzle 1: O painel não conseguiu abrir!");
            return false;
        }

        // Bloqueia a movimentação.
        Jogador.travadoNoMinigame = true;

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        // Esconde a personagem.
        for (int i = 0; i < renderizadores.Length; i++)
        {
            if (renderizadores[i] != null)
                renderizadores[i].enabled = false;
        }

        puzzleAberto = true;
        livrosCorretos = 0;

        botaoContinuar.gameObject.SetActive(false);

        Debug.Log("Puzzle 1 aberto! Personagem parada e escondida.");

        return true;
    }

    public void LivroConcluido()
    {
        if (!puzzleAberto)
            return;

        livrosCorretos++;

        Debug.Log("Livros corretos: " + livrosCorretos);

        if (livrosCorretos >= quantidadeLivrosNecessarios)
        {
            botaoContinuar.gameObject.SetActive(true);

            Debug.Log("Puzzle concluído! Pode continuar.");
        }
    }

    public void FecharPuzzle()
    {
        if (!puzzleAberto)
            return;

        controlePainel.Fechar();

        RestaurarPersonagem();

        puzzleAberto = false;

        Debug.Log("Puzzle 1 finalizado! Personagem liberada.");
    }

    private void RestaurarPersonagem()
    {
        for (int i = 0; i < renderizadores.Length; i++)
        {
            if (renderizadores[i] != null)
                renderizadores[i].enabled = visibilidadeOriginal[i];
        }

        rb.constraints = restricoesOriginais;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        Jogador.travadoNoMinigame = false;
    }

    private void OnDestroy()
    {
        if (botaoContinuar != null)
            botaoContinuar.onClick.RemoveListener(FecharPuzzle);
    }
}