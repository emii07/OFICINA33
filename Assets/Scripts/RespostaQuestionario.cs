using UnityEngine;
using TMPro;

public class RespostaQuestionario : MonoBehaviour
{
    [SerializeField] private bool respostaCorreta;

    public static int acertos = 0;
    public static int perguntasRespondidas = 0;

    public static TMP_Text textoResultado;

    private bool jaRespondeu = false;

    public void Responder()
    {
        if (jaRespondeu)
            return;

        jaRespondeu = true;

        perguntasRespondidas++;

        if (respostaCorreta)
        {
            acertos++;

            if (textoResultado != null)
            {
                textoResultado.text = "✅ Resposta correta!";
                textoResultado.gameObject.SetActive(true);
            }

            Debug.Log("Resposta correta!");
        }
        else
        {
            if (textoResultado != null)
            {
                textoResultado.text = "❌ Resposta incorreta!";
                textoResultado.gameObject.SetActive(true);
            }

            Debug.Log("Resposta errada!");
        }
    }
}