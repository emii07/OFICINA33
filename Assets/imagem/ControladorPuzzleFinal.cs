using UnityEngine;
using TMPro;

public class ControladorPuzzleFinal : MonoBehaviour
{
    public GameObject painelPuzzleFinal;
    public TMP_Text textoConclusao;
    public GameObject botaoContinuar;

    public FragmentoArrastavelUI[] fragmentos;

    private bool concluido = false;

    private void Start()
    {
        if (textoConclusao != null)
            textoConclusao.gameObject.SetActive(false);

        if (botaoContinuar != null)
            botaoContinuar.SetActive(false);
    }

    public void AbrirPuzzle()
    {
        if (painelPuzzleFinal != null)
            painelPuzzleFinal.SetActive(true);

        concluido = false;

        if (textoConclusao != null)
            textoConclusao.gameObject.SetActive(false);

        if (botaoContinuar != null)
            botaoContinuar.SetActive(false);
    }

    public void VerificarOrdem()
    {
        if (concluido) return;

        if (fragmentos == null || fragmentos.Length != 4)
            return;

        foreach (FragmentoArrastavelUI fragmento in fragmentos)
        {
            if (fragmento == null)
                return;

            if (fragmento.posicaoAtual != fragmento.posicaoCorreta)
                return;
        }

        concluido = true;

        if (textoConclusao != null)
        {
            textoConclusao.text =
                "Parabéns! O Grande Livro foi reconstruído!";

            textoConclusao.gameObject.SetActive(true);
        }

        if (botaoContinuar != null)
            botaoContinuar.SetActive(true);

        Debug.Log("Livro da memória reconstruído!");
    }
    public void Continuar()
{
    Debug.Log("BOTÃO CONTINUAR FOI CLICADO!");

    if (painelPuzzleFinal != null)
        painelPuzzleFinal.SetActive(false);
    else
        Debug.LogError("O campo Painel Puzzle Final está vazio!");
}
}