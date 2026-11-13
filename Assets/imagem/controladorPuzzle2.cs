using UnityEngine;

public class ControladorPuzzle2 : MonoBehaviour
{
    [Header("Painel")]
    public GameObject painelPuzzle2;

    [Header("Personagem")]
    public Rigidbody2D corpoJogador;
    public GameObject personagem;

    private RigidbodyConstraints2D restricoesOriginais;

    private void Start()
    {
        painelPuzzle2.SetActive(false);
    }

    public void AbrirPuzzle()
    {
        Debug.Log("Puzzle 2 aberto!");

        restricoesOriginais = corpoJogador.constraints;

        corpoJogador.linearVelocity = Vector2.zero;
        corpoJogador.angularVelocity = 0f;

        corpoJogador.constraints = RigidbodyConstraints2D.FreezeAll;

        personagem.SetActive(false);

        painelPuzzle2.SetActive(true);
    }

    public void FecharPuzzle()
    {
        personagem.SetActive(true);

        corpoJogador.constraints = restricoesOriginais;

        corpoJogador.linearVelocity = Vector2.zero;
        corpoJogador.angularVelocity = 0f;

        painelPuzzle2.SetActive(false);
    }
}