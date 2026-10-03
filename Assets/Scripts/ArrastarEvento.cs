using UnityEngine;
using UnityEngine.EventSystems;

public class ArrastarEvento : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int ordemEvento;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform posicaoOriginal;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        posicaoOriginal = transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
    }
}