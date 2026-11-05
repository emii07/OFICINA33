using UnityEngine;

public class InventarioUI : MonoBehaviour
{
    [Tooltip("Objeto pai que contém todos os slots na Hierarchy (ex: Grid)")]
    [SerializeField] private Transform conteinerSlots;

    private SlotInventario[] slots;

    private void Start()
    {
        slots = conteinerSlots.GetComponentsInChildren<SlotInventario>();

        if (InventarioManager.Instancia != null)
        {
            InventarioManager.Instancia.onInventarioMudouCallback += AtualizarInterface;
            AtualizarInterface();
        }
    }

    private void OnDestroy()
    {
        if (InventarioManager.Instancia != null)
        {
            InventarioManager.Instancia.onInventarioMudouCallback -= AtualizarInterface;
        }
    }

    public void AtualizarInterface()
    {
        var listaItens = InventarioManager.Instancia.itens;

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < listaItens.Count)
            {
                slots[i].PreencherSlot(listaItens[i]);
            }
            else
            {
                slots[i].LimparSlot();
            }
        }
    }
}