using UnityEngine;

public class PainelPuzzle1Controle : MonoBehaviour
{
    public GameObject painelPuzzle1;
    public Canvas canvas;

    void Awake()
    {
        if (canvas != null)
        {
            Canvas raiz = canvas.rootCanvas;
            raiz.renderMode = RenderMode.ScreenSpaceOverlay;
            raiz.worldCamera = null;
            raiz.targetDisplay = 0;
        }

        painelPuzzle1.SetActive(false);
    }

    public void Abrir()
    {
        painelPuzzle1.SetActive(true);
    }

    public void Fechar()
    {
        painelPuzzle1.SetActive(false);
    }
}