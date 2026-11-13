using UnityEngine;
using UnityEngine.UI;

public class PuzzleLivros : MonoBehaviour
{
    public PainelPuzzle1Controle controlePainel;

    public GameObject personagem;
    public MonoBehaviour movimentoJogador;

    public Button botaoContinuar;

    private int livrosCorretos = 0;
    private bool puzzleAberto = false;

    void Start()
    {
        controlePainel.Fechar();

        botaoContinuar.gameObject.SetActive(false);

        botaoContinuar.onClick.RemoveListener(FecharPuzzle);
        botaoContinuar.onClick.AddListener(FecharPuzzle);
    }

    public void AbrirPuzzle()
    {
        if (puzzleAberto) return;

        puzzleAberto = true;
        livrosCorretos = 0;

        movimentoJogador.enabled = false;

        personagem.SetActive(false);

        botaoContinuar.gameObject.SetActive(false);

        controlePainel.Abrir();

        Debug.Log("Puzzle 1 aberto!");
    }

    public void LivroConcluido()
    {
        if (!puzzleAberto) return;

        livrosCorretos++;

        if (livrosCorretos >= 3)
        {
            botaoContinuar.gameObject.SetActive(true);
        }
    }

    public void FecharPuzzle()
    {
        if (!puzzleAberto) return;

        controlePainel.Fechar();

        personagem.SetActive(true);

        movimentoJogador.enabled = true;

        puzzleAberto = false;

        Debug.Log("Puzzle 1 finalizado!");
    }
}