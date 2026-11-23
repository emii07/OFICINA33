using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizFinal : MonoBehaviour
{
    [Header("Painel e personagem")]
    public GameObject painelPerguntas;
    public GameObject personagem;
    public MonoBehaviour movimentoJogador;

    [Header("Textos")]
    public TMP_Text textoPergunta;
    public TMP_Text feedback;
    public TMP_Text textoA;
    public TMP_Text textoB;
    public TMP_Text textoC;

    [Header("Bot�es")]
    public Button botaoA;
    public Button botaoB;
    public Button botaoC;
    public Button botaoContinuar;

    private Renderer[] renderizadores;
    private bool[] estadoRenderizadores;
    private bool movimentoEstavaAtivo;

    private int perguntaAtual = 0;
    private bool respondeuCorretamente;
    private bool quizConcluido;
    private bool quizAberto;

    private string textoOriginalBotao;

    private string[] perguntas =
    {
        "O que os intelectuais produzem?",
        "Quem escreveu o livro Oiteiro?",
        "O que era produzido nos antigos engenhos?",
        "O que as festas populares ajudam a preservar?"
    };

    private string[][] alternativas =
    {
        new string[] { "A) Conhecimentos", "B) Alimentos", "C) Roupas" },
        new string[] { "A) Madalena Antunes", "B) Cecilia Meireles", "C) Clarice Lispector" },
        new string[] { "A) Acucar", "B) Cafe", "C) Chocolate" },
        new string[] { "A) A cultura", "B) A tecnologia", "C) O comercio" }
    };

    void Awake()
    {
        if (personagem != null)
        {
            renderizadores =
                personagem.GetComponentsInChildren<Renderer>(true);

            estadoRenderizadores = new bool[renderizadores.Length];

            for (int i = 0; i < renderizadores.Length; i++)
            {
                estadoRenderizadores[i] = renderizadores[i].enabled;
            }
        }
    }

    void Start()
    {
        if (painelPerguntas == null ||
            movimentoJogador == null ||
            botaoA == null ||
            botaoB == null ||
            botaoC == null ||
            botaoContinuar == null)
        {
            Debug.LogError("QuizFinal: confira os campos vazios no Inspector.");
            return;
        }

        painelPerguntas.SetActive(false);

        TMP_Text textoBotao =
            botaoContinuar.GetComponentInChildren<TMP_Text>(true);

        if (textoBotao != null)
            textoOriginalBotao = textoBotao.text;

        botaoA.onClick.AddListener(() => VerificarResposta(0));
        botaoB.onClick.AddListener(() => VerificarResposta(1));
        botaoC.onClick.AddListener(() => VerificarResposta(2));
        botaoContinuar.onClick.AddListener(ProximaPergunta);
    }

    public void AbrirQuiz()
    {
        if (quizAberto) return;

        if (painelPerguntas == null ||
            personagem == null ||
            movimentoJogador == null)
        {
            Debug.LogError("QuizFinal: faltam referências no Inspector.");
            return;
        }

        quizAberto = true;
        perguntaAtual = 0;
        quizConcluido = false;

        movimentoEstavaAtivo = movimentoJogador.enabled;
        movimentoJogador.enabled = false;

        Rigidbody2D rb =
            personagem.GetComponent<Rigidbody2D>();

        if (rb != null)
            rb.linearVelocity = Vector2.zero;

        if (renderizadores != null)
        {
            for (int i = 0; i < renderizadores.Length; i++)
            {
                renderizadores[i].enabled = false;
            }
        }

        painelPerguntas.SetActive(true);

        botaoA.gameObject.SetActive(true);
        botaoB.gameObject.SetActive(true);
        botaoC.gameObject.SetActive(true);

        TMP_Text textoBotao =
            botaoContinuar.GetComponentInChildren<TMP_Text>(true);

        if (textoBotao != null)
            textoBotao.text = textoOriginalBotao;

        MostrarPergunta();
    }

    void MostrarPergunta()
    {
        respondeuCorretamente = false;

        feedback.text = "";
        textoPergunta.text = perguntas[perguntaAtual];

        textoA.text = alternativas[perguntaAtual][0];
        textoB.text = alternativas[perguntaAtual][1];
        textoC.text = alternativas[perguntaAtual][2];

        botaoA.interactable = true;
        botaoB.interactable = true;
        botaoC.interactable = true;

        botaoContinuar.gameObject.SetActive(false);
    }

    void VerificarResposta(int resposta)
    {
        if (respondeuCorretamente) return;

        if (resposta == 0)
        {
            respondeuCorretamente = true;
            feedback.text = "Resposta correta!";

            botaoA.interactable = false;
            botaoB.interactable = false;
            botaoC.interactable = false;

            botaoContinuar.gameObject.SetActive(true);
        }
        else
        {
            feedback.text = "Resposta incorreta! Tente novamente.";
        }
    }

    void ProximaPergunta()
    {
        if (quizConcluido)
        {
            FecharQuiz();
            return;
        }

        if (!respondeuCorretamente) return;

        perguntaAtual++;

        if (perguntaAtual < perguntas.Length)
        {
            MostrarPergunta();
        }
        else
        {
            quizConcluido = true;

            textoPergunta.text =
                "Parabêns! Você concluiu o Desafio da Memória!";

            textoA.text = "";
            textoB.text = "";
            textoC.text = "";

            feedback.text =
                "Voc� acertou todas as perguntas!";

            botaoA.gameObject.SetActive(false);
            botaoB.gameObject.SetActive(false);
            botaoC.gameObject.SetActive(false);

            botaoContinuar.gameObject.SetActive(true);

            TMP_Text textoBotao =
                botaoContinuar.GetComponentInChildren<TMP_Text>(true);

            if (textoBotao != null)
                textoBotao.text = "Continuar";
        }
    }

    void FecharQuiz()
    {
        painelPerguntas.SetActive(false);

        if (renderizadores != null)
        {
            for (int i = 0; i < renderizadores.Length; i++)
            {
                renderizadores[i].enabled = estadoRenderizadores[i];
            }
        }

        if (movimentoJogador != null)
            movimentoJogador.enabled = movimentoEstavaAtivo;

        quizAberto = false;
    }
}