using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class LivroArrastavel : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int numeroLivro;
    public PuzzleLivros puzzle;

    private RectTransform rect;
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    private Transform paiInicial;
    private Vector2 posicaoInicial;
    private Vector2 tamanhoInicial;
    private Vector3 escalaInicial;
    private Vector2 ancoraMinInicial;
    private Vector2 ancoraMaxInicial;
    private Vector2 pivôInicial;

    private bool encaixado = false;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (encaixado) return;

        paiInicial = transform.parent;
        posicaoInicial = rect.anchoredPosition;
        tamanhoInicial = rect.sizeDelta;
        escalaInicial = rect.localScale;
        ancoraMinInicial = rect.anchorMin;
        ancoraMaxInicial = rect.anchorMax;
        pivôInicial = rect.pivot;

        transform.SetParent(canvas.rootCanvas.transform, true);
        transform.SetAsLastSibling();

        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (encaixado) return;

        rect.position += (Vector3)eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (encaixado) return;

        List<RaycastResult> resultados =
            new List<RaycastResult>();

        EventSystem.current.RaycastAll(eventData, resultados);

        EspacoLivro espaco = null;

        foreach (RaycastResult resultado in resultados)
        {
            espaco = resultado.gameObject
                .GetComponentInParent<EspacoLivro>();

            if (espaco != null) break;
        }

        canvasGroup.blocksRaycasts = true;

        if (espaco != null &&
            espaco.ReceberLivro(numeroLivro))
        {
            RectTransform rectEspaco =
                espaco.GetComponent<RectTransform>();

            rect.SetParent(espaco.transform, false);

            rect.anchorMin = new Vector2(0.5f, 0.5f);
            rect.anchorMax = new Vector2(0.5f, 0.5f);
            rect.pivot = new Vector2(0.5f, 0.5f);

            rect.anchoredPosition = Vector2.zero;
            rect.sizeDelta = rectEspaco.rect.size;
            rect.localScale = Vector3.one;

            encaixado = true;
            puzzle.LivroConcluido();
        }
        else
        {
            transform.SetParent(paiInicial, false);

            rect.anchorMin = ancoraMinInicial;
            rect.anchorMax = ancoraMaxInicial;
            rect.pivot = pivôInicial;
            rect.sizeDelta = tamanhoInicial;
            rect.localScale = escalaInicial;
            rect.anchoredPosition = posicaoInicial;
        }
    }
}