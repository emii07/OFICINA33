using UnityEngine;
using UnityEngine.UI;

public class SlotInventario : MonoBehaviour
{
    [SerializeField] private Image iconeImage;
    [SerializeField] private Button botaoSlot;

    private ItemData itemAtual;

    public void PreencherSlot(ItemData novoItem)
    {
        itemAtual = novoItem;
        iconeImage.sprite = novoItem.icone;
        iconeImage.enabled = true;
        if (botaoSlot != null) botaoSlot.interactable = true;
    }

    public void LimparSlot()
    {
        itemAtual = null;
        iconeImage.sprite = null;
        iconeImage.enabled = false;
        if (botaoSlot != null) botaoSlot.interactable = false;
    }

    // Método opcional acionado ao clicar no slot no Canvas
    public void OnSlotClicado()
    {
        if (itemAtual != null)
        {
            Debug.Log($"Item selecionado: {itemAtual.nomeItem}");
            // Adicione aqui a lógica de examinar ou usar o item no jogo
        }
    }
}