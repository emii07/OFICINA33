using UnityEngine;
using UnityEngine.EventSystems;

public class SlotEvento : MonoBehaviour, IDropHandler
{
    public int ordemCorreta;

    public void OnDrop(PointerEventData eventData)
    {
        ArrastarEvento evento = eventData.pointerDrag.GetComponent<ArrastarEvento>();

        if (evento != null)
        {
            evento.transform.SetParent(transform);
            evento.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
    }
}