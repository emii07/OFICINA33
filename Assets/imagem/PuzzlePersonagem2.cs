using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Puzzle2Personagens : MonoBehaviour
{
    [Header("Pergunta")]
    public TMP_Text textoPergunta;

    [Header("Botões")]
    public Button botaoA;
    public Button botaoB;
    public Button botaoC;
    public Button botaoProxima;
    public Button botaoContinuar;

    [Header("Textos")]
    public TMP_Text textoA;
    public TMP_Text textoB;
    public TMP_Text textoC;
    public TMP_Text textoFeedback;

    private int perguntaAtual = 0;
    private bool respondeu = false;

    private string[] perguntas =
    {
        "Quem escreveu o livro Oiteiro?",
        "Quem acompanha Madalena na descoberta da história?",
        "Quem é a personagem principal do jogo?"
    };

    private string[,] alternativas =
    {
        {
            "A) Madalena Antunes",
            "B) Dona Alzira",
            "C) Thiago Lispector"
        },
        {
            "A) Seu Joaquim",
            "B) Dona Alzira",
            "C) Thiago Lispector"
        },
        {
            "A) Madalena",
            "B) Dona Alzira",
            "C) Bibliotecária"
        }
    };

    private int[] respostasCorretas = { 0, 1, 0 };

    private void OnEnable()
    {
        perguntaAtual = 0;

        botaoA.onClick.RemoveAllListeners();
        botaoB.onClick.RemoveAllListeners();
        botaoC.onClick.RemoveAllListeners();
        botaoProxima.onClick.RemoveAllListeners();

        botaoA.onClick.AddListener(() => Responder(0));
        botaoB.onClick.AddListener(() => Responder(1));
        botaoC.onClick.AddListener(() => Responder(2));
        botaoProxima.onClick.AddListener(ProximaPergunta);

        botaoContinuar.gameObject.SetActive(false);

        MostrarPergunta();
    }

    private void MostrarPergunta()
    {
        respondeu = false;

        textoPergunta.text = perguntas[perguntaAtual];

        textoA.text = alternativas[perguntaAtual, 0];
        textoB.text = alternativas[perguntaAtual, 1];
        textoC.text = alternativas[perguntaAtual, 2];

        textoFeedback.text = "";

        botaoA.interactable = true;
        botaoB.interactable = true;
        botaoC.interactable = true;

        botaoProxima.gameObject.SetActive(false);
        botaoContinuar.gameObject.SetActive(false);
    }

    private void Responder(int resposta)
    {
        if (respondeu) return;

        respondeu = true;

        botaoA.interactable = false;
        botaoB.interactable = false;
        botaoC.interactable = false;

        if (resposta == respostasCorretas[perguntaAtual])
        {
            textoFeedback.text = "Resposta correta!";

            if (perguntaAtual == perguntas.Length - 1)
            {
                botaoContinuar.gameObject.SetActive(true);
            }
            else
            {
                botaoProxima.gameObject.SetActive(true);
            }
        }
        else
        {
            textoFeedback.text = "Resposta incorreta! Tente novamente.";

            respondeu = false;

            botaoA.interactable = true;
            botaoB.interactable = true;
            botaoC.interactable = true;
        }
    }

    private void ProximaPergunta()
    {
        perguntaAtual++;

        if (perguntaAtual < perguntas.Length)
        {
            MostrarPergunta();
        }
    }
}