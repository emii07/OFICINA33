using UnityEngine;

public class PainelPuzzle1Controle : MonoBehaviour
{
    [Header("Referências")]
    public GameObject painelPuzzle1;
    public Canvas canvas;

    private void Awake()
    {
        if (painelPuzzle1 == null)
        {
            Debug.LogError("Painel Puzzle 1 não foi atribuído!", this);
            return;
        }

        if (canvas != null)
        {
            Canvas raiz = canvas.rootCanvas;

            raiz.renderMode = RenderMode.ScreenSpaceOverlay;
            raiz.worldCamera = null;
            raiz.targetDisplay = 0;
        }

        painelPuzzle1.SetActive(false);
    }

    public bool Abrir()
    {
        if (painelPuzzle1 == null)
        {
            Debug.LogError("Painel Puzzle 1 está vazio!", this);
            return false;
        }

        if (!painelPuzzle1.activeInHierarchy)
        {
            painelPuzzle1.SetActive(true);
        }

        Canvas.ForceUpdateCanvases();

        bool abriu = painelPuzzle1.activeInHierarchy;

        Debug.Log("Painel Puzzle 1 ativo na Hierarchy: " + abriu);

        if (!abriu)
        {
            Debug.LogError(
                "O painel recebeu SetActive(true), mas algum objeto pai está desativado!",
                painelPuzzle1
            );
        }

        return abriu;
    }

    public void Fechar()
    {
        if (painelPuzzle1 != null)
        {
            painelPuzzle1.SetActive(false);

            Debug.Log("Painel do Puzzle 1 fechado!");
        }
    }
}