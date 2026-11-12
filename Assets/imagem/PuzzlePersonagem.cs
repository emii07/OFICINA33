using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PuzzlePersonagem : MonoBehaviour
{
    public GameObject painelPuzzle2;
    public GameObject personagem;
    public MonoBehaviour movimentoJogador;

    public TMP_Text textoTitulo;
    public TMP_Text feedback;

    public Button botaoA;
    public Button botaoB;
    public Button botaoC;
    public Button botaoContinuar;

    public TMP_Text textoA;
    public TMP_Text textoB;
    public TMP_Text textoC;

    private Renderer[] renderizadores;
    private bool respondeuCorretamente = false;
    private bool puzzleAberto = false;

    void Awake()
    {
        renderizadores = personagem.GetComponentsInChildren<Renderer>(true);
    }

    void Start()
    {
        painelPuzzle2.SetActive(false);
        botaoContinuar.gameObject.SetActive(false);

        botaoA.onClick.AddListener(() => VerificarResposta(0));
        botaoB.onClick.AddListener(() => VerificarResposta(1));
        botaoC.onClick.AddListener(() => VerificarResposta(2));
        botaoContinuar.onClick.AddListener(FecharPuzzle);
    }

    public void AbrirPuzzle()
    {
        if (puzzleAberto) return;

        puzzleAberto = true;
        respondeuCorretamente = false;

        movimentoJogador.enabled = false;

        foreach (Renderer r in renderizadores)
            r.enabled = false;

        painelPuzzle2.SetActive(true);

        textoTitulo.text = "Quem escreveu o livro Oiteiro?";

        textoA.text = "A) Madalena Antunes";
        textoB.text = "B) Cecília Meireles";
        textoC.text = "C) Clarice Lispector";

        feedback.text = "";

        botaoA.interactable = true;
        botaoB.interactable = true;
        botaoC.interactable = true;

        botaoContinuar.gameObject.SetActive(false);
    }

    void VerificarResposta(int resposta)
    {
        if (respondeuCorretamente) return;

        if (resposta == 0)
        {
            respondeuCorretamente = true;

            feedback.text = "Resposta correta!";

            botaoA.interactable = false;
            botaoB.interactable = false;
            botaoC.interactable = false;

            botaoContinuar.gameObject.SetActive(true);
        }
        else
        {
            feedback.text = "Resposta incorreta! Tente novamente.";
        }
    }

    void FecharPuzzle()
    {
        painelPuzzle2.SetActive(false);

        foreach (Renderer r in renderizadores)
            r.enabled = true;

        movimentoJogador.enabled = true;

        puzzleAberto = false;
    }
}