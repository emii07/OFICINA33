using UnityEngine;

public class Luminaria : MonoBehaviour
{
    [Header("Informações do intelectual")]
    [SerializeField] private string nomeIntelectual;

    [TextArea(3, 8)]
    [SerializeField] private string biografia;

    [SerializeField] private ControleLuminarias controleLuminarias;

    [Header("Configuração Especial (Luminária 4)")]
    [SerializeField] private bool ativaBotaoQuestionario = false;
    [SerializeField] private GameObject botaoQuestionario;

    private bool jaFoiAtivada = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!jaFoiAtivada)
            {
                jaFoiAtivada = true;

                if (controleLuminarias != null)
                {
                    controleLuminarias.RegistrarLuminaria();
                }
            }

            if (BiografiaUI.Instance != null)
            {
                BiografiaUI.Instance.MostrarBiografia(nomeIntelectual, biografia);
            }
            
            // A ativação do botão foi removida daqui
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (BiografiaUI.Instance != null)
            {
                BiografiaUI.Instance.EsconderBiografia();
            }

            // O botão agora só é ativado quando o jogador sai da área e o painel fecha
            if (ativaBotaoQuestionario && botaoQuestionario != null)
            {
                botaoQuestionario.SetActive(true);
            }
        }
    }
}