using UnityEngine;
using UnityEngine.UI;

public class PuzzleLivros : MonoBehaviour
{
    public GameObject painelPuzzle1;
    public GameObject personagem;
    public MonoBehaviour movimentoJogador;
    public Button botaoContinuar;

    private Renderer[] renderizadores;
    private int livrosCorretos = 0;
    private bool puzzleAberto = false;

    void Awake()
    {
        if (personagem != null)
        {
            renderizadores =
                personagem.GetComponentsInChildren<Renderer>(true);
        }
    }

    void Start()
    {
        painelPuzzle1.SetActive(false);
        botaoContinuar.gameObject.SetActive(false);
    }

    public void AbrirPuzzle()
    {
        Debug.Log("1 - AbrirPuzzle foi chamado!");

        if (puzzleAberto) return;

        puzzleAberto = true;
        livrosCorretos = 0;

        movimentoJogador.enabled = false;

        foreach (Renderer r in renderizadores)
        {
            r.enabled = false;
        }

        Debug.Log("2 - Tentando ativar o painel!");

        painelPuzzle1.SetActive(true);

        Debug.Log("3 - Painel ativo? " +
                  painelPuzzle1.activeSelf);

        botaoContinuar.gameObject.SetActive(false);
    }

    public void LivroConcluido()
    {
        livrosCorretos++;

        if (livrosCorretos >= 3)
        {
            botaoContinuar.gameObject.SetActive(true);
        }
    }

    public void FecharPuzzle()
    {
        painelPuzzle1.SetActive(false);

        foreach (Renderer r in renderizadores)
        {
            r.enabled = true;
        }

        movimentoJogador.enabled = true;

        puzzleAberto = false;
    }
}