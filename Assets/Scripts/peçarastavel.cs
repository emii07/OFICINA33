using UnityEngine;
using UnityEngine.EventSystems;

public class PecaArrastavel : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [Header("Configuração de Encaixe")]
    [Tooltip("Posição Anchored (X, Y) exata onde a peça deve encaixar")]
    [SerializeField] private Vector2 posicaoCorreta;
    
    [Tooltip("Margem de erro em pixels para aceitar o encaixe (ex: 40 a 60)")]
    [SerializeField] private float tolerancia = 50f;

    private RectTransform rectTransform;
    private Canvas canvasParent;
    private bool estaEncaixada = false;

    public bool EstaEncaixada => estaEncaixada;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasParent = GetComponentInParent<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (estaEncaixada) return;

        if (canvasParent != null)
        {
            rectTransform.anchoredPosition += eventData.delta / canvasParent.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (estaEncaixada) return;

        float distancia = Vector2.Distance(rectTransform.anchoredPosition, posicaoCorreta);

        if (distancia <= tolerancia)
        {
            rectTransform.anchoredPosition = posicaoCorreta;
            estaEncaixada = true;
            Debug.Log($"[Puzzle] Peça {gameObject.name} ENCAIXADA com sucesso!");

            // Notifica o script principal do Puzzle
            if (PuzzlePergaminho.Instancia != null)
            {
                PuzzlePergaminho.Instancia.VerificarVitoriaGeral();
            }
        }
    }
}