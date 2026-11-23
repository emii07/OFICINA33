using UnityEngine;

public class ControladorPuzzle2 : MonoBehaviour
{
    [Header("Painel")]
    public GameObject painelPuzzle2;

    [Header("Personagem")]
    public Rigidbody2D corpoJogador;

    private RigidbodyConstraints2D restricoesOriginais;
    private bool puzzleAberto = false;

    private void Awake()
    {
        if (painelPuzzle2 != null)
        {
            painelPuzzle2.SetActive(false);
        }

        if (corpoJogador != null)
        {
            restricoesOriginais = corpoJogador.constraints;
        }
    }

    public void AbrirPuzzle()
    {
        if (puzzleAberto) return;

        if (painelPuzzle2 == null || corpoJogador == null)
        {
            Debug.LogError("Puzzle 2: referências não configuradas!");
            return;
        }

        puzzleAberto = true;

        // Guarda as restrições originais
        restricoesOriginais = corpoJogador.constraints;

        // Para completamente a personagem
        corpoJogador.linearVelocity = Vector2.zero;
        corpoJogador.angularVelocity = 0f;

        // Impede qualquer movimento
        corpoJogador.constraints = RigidbodyConstraints2D.FreezeAll;

        // NÃO desativa a personagem.
        // Assim, a câmera não será desligada junto com ela.

        painelPuzzle2.SetActive(true);

        Debug.Log("Puzzle 2 aberto com sucesso!");
    }

    public void FecharPuzzle()
    {
        if (!puzzleAberto) return;

        // Fecha o painel
        painelPuzzle2.SetActive(false);

        // Restaura as configurações do Rigidbody
        corpoJogador.constraints = restricoesOriginais;

        corpoJogador.linearVelocity = Vector2.zero;
        corpoJogador.angularVelocity = 0f;

        puzzleAberto = false;

        Debug.Log("Puzzle 2 fechado! Personagem liberada.");
    }
}