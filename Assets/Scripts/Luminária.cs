using UnityEngine;

public class Luminaria : MonoBehaviour
{
    [Header("Informações do intelectual")]
    [SerializeField] private string nomeIntelectual;

    [TextArea(3, 8)]
    [SerializeField] private string biografia;

    [SerializeField] private ControleLuminarias controleLuminarias;

    private bool jaFoiAtivada = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !jaFoiAtivada)
        {
            jaFoiAtivada = true;

            BiografiaUI.Instance.MostrarBiografia(
                nomeIntelectual,
                biografia
            );

            controleLuminarias.RegistrarLuminaria();
        }
    }
}