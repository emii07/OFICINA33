using UnityEngine;

[CreateAssetMenu(fileName = "NovoItem", menuName = "Inventario/ItemData")]
public class ItemData : ScriptableObject
{
    public string id;
    public string nomeItem;
    public Sprite icone;
    [TextArea] public string descricao;
}