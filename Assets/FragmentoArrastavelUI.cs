using UnityEngine;
using UnityEngine.EventSystems;

public class FragmentoArrastavelUI : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public int posicaoAtual;
    public int posicaoCorreta;

    public ControladorPuzzleFinal controlador;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private Vector2 posicaoInicial;
    private Vector2 deslocamento;
    private bool trocou;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        posicaoInicial = rectTransform.anchoredPosition;
        trocou = false;

        canvasGroup.blocksRaycasts = false;
        transform.SetAsLastSibling();

        RectTransform pai = rectTransform.parent as RectTransform;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            pai,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 pontoLocal
        );

        deslocamento = rectTransform.anchoredPosition - pontoLocal;
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransform pai = rectTransform.parent as RectTransform;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            pai,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 pontoLocal))
        {
            rectTransform.anchoredPosition = pontoLocal + deslocamento;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject objeto = eventData.pointerDrag;

        if (objeto == null) return;

        FragmentoArrastavelUI arrastado =
            objeto.GetComponent<FragmentoArrastavelUI>();

        if (arrastado == null || arrastado == this)
            return;

        if (arrastado.rectTransform.parent != rectTransform.parent)
            return;

        Vector2 minhaPosicao = rectTransform.anchoredPosition;
        Vector2 outraPosicao = arrastado.posicaoInicial;

        rectTransform.anchoredPosition = outraPosicao;
        arrastado.rectTransform.anchoredPosition = minhaPosicao;

        int temporaria = posicaoAtual;

        posicaoAtual = arrastado.posicaoAtual;
        arrastado.posicaoAtual = temporaria;

        trocou = true;
        arrastado.trocou = true;

        if (controlador != null)
            controlador.VerificarOrdem();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!trocou)
            rectTransform.anchoredPosition = posicaoInicial;

        canvasGroup.blocksRaycasts = true;
    }
}