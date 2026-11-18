using UnityEngine;
using TMPro;

public class VerificadorLinhaDoTempo : MonoBehaviour
{
    public SlotEvento[] slots;
    public GameObject painelSucesso;
    public GameObject painelLinhaDoTempo;
    public TMP_Text textoFeedback;

    public void Verificar()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            ArrastarEvento evento =
                slots[i].GetComponentInChildren<ArrastarEvento>();

            if (evento == null ||
                evento.transform.parent != slots[i].transform ||
                !evento.FoiArrastado)
            {
                textoFeedback.color = Color.red;
                textoFeedback.text =
                    "Arraste um acontecimento para cada espaço antes de verificar!";
                return;
            }

            if (evento.ordemEvento != slots[i].ordemCorreta)
            {
                textoFeedback.color = Color.red;
                textoFeedback.text =
                    "A ordem está incorreta. Tente novamente!";
                return;
            }
        }

        textoFeedback.color = Color.green;
        textoFeedback.text = "Muito bem! Você acertou!";

        foreach (SlotEvento slot in slots)
        {
            ArrastarEvento evento =
                slot.GetComponentInChildren<ArrastarEvento>();

            if (evento != null)
            {
                evento.BloquearArrasto();
            }
        }

        painelSucesso.SetActive(true);
        painelSucesso.transform.SetAsLastSibling();
    }

    public void Continuar()
    {
        Jogador.travadoNoMinigame = false;

        painelSucesso.SetActive(false);
        painelLinhaDoTempo.SetActive(false);
    }
}