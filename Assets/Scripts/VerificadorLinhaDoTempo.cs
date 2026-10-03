using UnityEngine;

public class VerificadorLinhaDoTempo : MonoBehaviour
{
    public SlotEvento[] slots;

    public void Verificar()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            ArrastarEvento evento = slots[i].GetComponentInChildren<ArrastarEvento>();

            if (evento == null || evento.ordemEvento != slots[i].ordemCorreta)
            {
                Debug.Log("Ordem incorreta!");
                return;
            }
        }

        Debug.Log("ORDEM CORRETA!");
    }
}