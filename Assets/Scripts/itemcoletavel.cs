using UnityEngine;

public class ItemColetavel : MonoBehaviour
{
    [SerializeField] private ItemData itemData;

    private void OnMouseDown()
    {
        TentarColetar();
    }

    public void TentarColetar()
    {
        if (itemData != null && InventarioManager.Instancia != null)
        {
            bool coletado = InventarioManager.Instancia.AdicionarItem(itemData);
            if (coletado)
            {
                Debug.Log($"Item {itemData.nomeItem} adicionado ao inventário!");
                Destroy(gameObject); // Remove o objeto da cena
            }
        }
    }
}