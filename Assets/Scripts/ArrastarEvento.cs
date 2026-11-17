
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrastarEvento : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int ordemEvento;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private bool bloqueado = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void BloquearArrasto()
    {
        bloqueado = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (bloqueado) return;

        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (bloqueado) return;

        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (bloqueado) return;

        canvasGroup.blocksRaycasts = true;
    }
}
