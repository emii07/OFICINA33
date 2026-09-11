using UnityEngine;
using UnityEngine.EventSystems;

public class SlotArea : MonoBehaviour, IDropHandler
{
    public string periodoDoSlot;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject objetoArrastado = eventData.pointerDrag;

        if (objetoArrastado != null)
        {
            DocumentoArrastavel doc =
                objetoArrastado.GetComponent<DocumentoArrastavel>();

            if (doc != null && doc.periodoHistorico == periodoDoSlot)
            {
                doc.transform.SetParent(transform);

                doc.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

                doc.enabled = false;

                PuzzleArchiveManager.Instance.VerificarAcerto();
            }
        }
    }
}