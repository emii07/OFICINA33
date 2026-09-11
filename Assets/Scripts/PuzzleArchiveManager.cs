using UnityEngine;

public class PuzzleArchiveManager : MonoBehaviour
{
    public static PuzzleArchiveManager Instance;

    [Header("Configurações")]
    public int totalDocumentos = 3;
    private int acertosAtuais = 0;

    [Header("Referências da UI")]
    public GameObject painelPuzzle;
    public GameObject fragmentoLivroReward;

    private void Awake()
    {
        Instance = this;
    }

    public void AbrirPuzzle()
    {
        painelPuzzle.SetActive(true);
    }

    public void VerificarAcerto()
    {
        acertosAtuais++;

        if (acertosAtuais >= totalDocumentos)
        {
            ConcluirPuzzle();
        }
    }

    private void ConcluirPuzzle()
    {
        painelPuzzle.SetActive(false);

        if (fragmentoLivroReward != null)
        {
            fragmentoLivroReward.SetActive(true);
        }

        Debug.Log("Desafio concluído! Fragmento do Livro obtido.");
    }
}