using System.Collections.Generic;
using UnityEngine;

public class InventarioManager : MonoBehaviour
{
    public static InventarioManager Instancia;

    [Header("Configurações do Inventário")]
    public List<ItemData> itens = new List<ItemData>();
    public int limiteEspacos = 10;

    // Evento disparado quando o inventário sofre alteração
    public delegate void OnInventarioMudou();
    public OnInventarioMudou onInventarioMudouCallback;

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject); // Mantém os itens entre as cenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool AdicionarItem(ItemData novoItem)
    {
        if (itens.Count >= limiteEspacos)
        {
            Debug.LogWarning("[Inventario] Inventário cheio!");
            return false;
        }

        itens.Add(novoItem);

        if (onInventarioMudouCallback != null)
        {
            onInventarioMudouCallback.Invoke();
        }

        return true;
    }

    public void RemoverItem(ItemData item)
    {
        if (itens.Contains(item))
        {
            itens.Remove(item);

            if (onInventarioMudouCallback != null)
            {
                onInventarioMudouCallback.Invoke();
            }
        }
    }
}