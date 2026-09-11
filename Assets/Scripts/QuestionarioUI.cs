using UnityEngine;
using TMPro;

public class QuestionarioUI : MonoBehaviour
{
    [Header("Painel do Questionário")]
    [SerializeField] private GameObject painelQuestionario;

    [Header("Botão para abrir o questionário")]
    [SerializeField] private GameObject botaoQuestionario;

    [Header("Resultado da Resposta")]
    [SerializeField] private TMP_Text textoResultado;

    [Header("Resultado Final")]
    [SerializeField] private TMP_Text textoPontuacao;
    [SerializeField] private GameObject botaoFinalizar;
    [SerializeField] private GameObject botaoContinuar;

    [Header("Conteúdos das Perguntas")]
    [SerializeField] private GameObject conteudoPergunta1;
    [SerializeField] private GameObject conteudoPergunta2;
    [SerializeField] private GameObject conteudoPergunta3;
    [SerializeField] private GameObject conteudoPergunta4;


    private void Start()
    {
        // O painel do questionário começa fechado
        painelQuestionario.SetActive(false);

        // Esconde todas as perguntas
        EsconderTodasPerguntas();

        // Esconde a mensagem de resposta
        EsconderResultado();

        // Esconde a pontuação final
        if (textoPontuacao != null)
        {
            textoPontuacao.gameObject.SetActive(false);
        }

        // Deixa o botão de finalizar disponível
        if (botaoFinalizar != null)
        {
            botaoFinalizar.SetActive(true);
        }

        // O botão continuar começa escondido
        if (botaoContinuar != null)
        {
            botaoContinuar.SetActive(false);
        }

        // Passa o texto de resultado para o script das respostas
        RespostaQuestionario.textoResultado = textoResultado;
    }


    // Chamado pelo botão "Responder Questionário"
    public void AbrirQuestionario()
    {
        painelQuestionario.SetActive(true);

        // Zera a pontuação ao começar o questionário
        RespostaQuestionario.acertos = 0;
        RespostaQuestionario.perguntasRespondidas = 0;

        // Esconde a pontuação anterior
        if (textoPontuacao != null)
        {
            textoPontuacao.gameObject.SetActive(false);
        }

        // Mostra o botão finalizar
        if (botaoFinalizar != null)
        {
            botaoFinalizar.SetActive(true);
        }

        // Esconde o botão continuar
        if (botaoContinuar != null)
        {
            botaoContinuar.SetActive(false);
        }

        // Começa pela pergunta 1
        MostrarPergunta(1);
    }


    // Troca entre as perguntas
    public void MostrarPergunta(int numero)
    {
        // Esconde o resultado da pergunta anterior
        EsconderResultado();

        // Esconde todas as perguntas
        EsconderTodasPerguntas();

        switch (numero)
        {
            case 1:
                conteudoPergunta1.SetActive(true);
                break;

            case 2:
                conteudoPergunta2.SetActive(true);
                break;

            case 3:
                conteudoPergunta3.SetActive(true);
                break;

            case 4:
                conteudoPergunta4.SetActive(true);
                break;
        }
    }


    // Finaliza o questionário e mostra a pontuação
    public void FinalizarQuestionario()
    {
        // Esconde as perguntas
        EsconderTodasPerguntas();

        // Esconde a mensagem da resposta
        EsconderResultado();

        // Esconde o botão finalizar
        if (botaoFinalizar != null)
        {
            botaoFinalizar.SetActive(false);
        }

        // Mostra a pontuação
        if (textoPontuacao != null)
        {
            textoPontuacao.text =
                "Questionário finalizado!\n\n" +
                "Você acertou " +
                RespostaQuestionario.acertos +
                " de 4 perguntas!";

            textoPontuacao.gameObject.SetActive(true);
        }

        // Mostra o botão continuar
        if (botaoContinuar != null)
        {
            botaoContinuar.SetActive(true);
        }

        Debug.Log(
            "Questionário finalizado! Acertos: " +
            RespostaQuestionario.acertos +
            "/4"
        );
    }


    // Fecha o questionário e permite continuar o jogo
    public void ContinuarJogo()
    {
        // Esconde a pontuação
        if (textoPontuacao != null)
        {
            textoPontuacao.gameObject.SetActive(false);
        }

        // Esconde o botão continuar
        if (botaoContinuar != null)
        {
            botaoContinuar.SetActive(false);
        }

        // Fecha o painel do questionário
        if (painelQuestionario != null)
        {
            painelQuestionario.SetActive(false);
        }

        // Esconde o botão "Responder Questionário"
        if (botaoQuestionario != null)
        {
            botaoQuestionario.SetActive(false);
        }

        Debug.Log("Questionário fechado. Continuando o jogo.");
    }


    // Esconde a mensagem "Resposta correta/incorreta"
    public void EsconderResultado()
    {
        if (textoResultado != null)
        {
            textoResultado.text = "";
            textoResultado.gameObject.SetActive(false);
        }
    }


    // Esconde todas as perguntas
    private void EsconderTodasPerguntas()
    {
        conteudoPergunta1.SetActive(false);
        conteudoPergunta2.SetActive(false);
        conteudoPergunta3.SetActive(false);
        conteudoPergunta4.SetActive(false);
    }
}