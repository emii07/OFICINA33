using UnityEngine;

public class ControleLuminarias : MonoBehaviour
{
    [SerializeField] private GameObject botaoQuestionario;

    private int luminariasVisitadas = 0;

    private void Start()
    {
        botaoQuestionario.SetActive(false);
    }

    public void RegistrarLuminaria()
    {
        luminariasVisitadas++;

        Debug.Log("Luminárias visitadas: " + luminariasVisitadas);
    }

    public void LiberarQuestionario()
    {
        if (luminariasVisitadas >= 4)
        {
            botaoQuestionario.SetActive(true);

            Debug.Log("As 4 luminárias foram visitadas! Questionário liberado.");
        }
    }
}