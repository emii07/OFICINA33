using UnityEngine;
using TMPro;
using System.Collections; // Necessário para usar Corrotinas (tempo de espera)

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
    [SerializeField] private GameObject botaoContinuar;
    // Removi a variável do Botão Finalizar daqui, pois já não vamos usar

    [Header("Conteúdos das Perguntas")]
    [SerializeField] private GameObject conteudoPergunta1;
    [SerializeField] private GameObject conteudoPergunta2;
    [SerializeField] private GameObject conteudoPergunta3;
    [SerializeField] private GameObject conteudoPergunta4;

    private bool aguardandoFim = false; // Controla para não chamar o fim várias vezes

    private void Start()
    {
        painelQuestionario.SetActive(false);
        EsconderTodasPerguntas();
        EsconderResultado();

        if (textoPontuacao != null) textoPontuacao.gameObject.SetActive(false);
        if (botaoContinuar != null) botaoContinuar.SetActive(false);

        RespostaQuestionario.textoResultado = textoResultado;
    }

    private void Update()
    {
        // Se o painel está aberto, se as 4 perguntas foram respondidas e ainda não começou a finalizar
        if (painelQuestionario.activeSelf && RespostaQuestionario.perguntasRespondidas >= 4 && !aguardandoFim)
        {
            if (textoPontuacao != null && !textoPontuacao.gameObject.activeSelf)
            {
                aguardandoFim = true;
                StartCoroutine(EsperarEFinalizar());
            }
        }
    }

    // Espera 1.5 segundos antes de mostrar a pontuação final
    private IEnumerator EsperarEFinalizar()
    {
        // WaitForSecondsRealtime é usado porque o Time.timeScale está em 0 (jogo pausado)
        yield return new WaitForSecondsRealtime(1.5f);
        FinalizarQuestionario();
    }

    public void AbrirQuestionario()
    {
        painelQuestionario.SetActive(true);
        Time.timeScale = 0f; 
        
        aguardandoFim = false; // Reseta a verificação
        RespostaQuestionario.acertos = 0;
        RespostaQuestionario.perguntasRespondidas = 0;

        if (textoPontuacao != null) textoPontuacao.gameObject.SetActive(false);
        if (botaoContinuar != null) botaoContinuar.SetActive(false);

        MostrarPergunta(1);
    }

    public void MostrarPergunta(int numero)
    {
        EsconderResultado();
        EsconderTodasPerguntas();

        switch (numero)
        {
            case 1: conteudoPergunta1.SetActive(true); break;
            case 2: conteudoPergunta2.SetActive(true); break;
            case 3: conteudoPergunta3.SetActive(true); break;
            case 4: conteudoPergunta4.SetActive(true); break;
        }
    }

    public void FinalizarQuestionario()
    {
        EsconderTodasPerguntas();
        EsconderResultado();

        if (textoPontuacao != null)
        {
            textoPontuacao.text =
                "Questionário finalizado!\n\n" +
                "Você acertou " +
                RespostaQuestionario.acertos +
                " de 4 perguntas!";
            textoPontuacao.gameObject.SetActive(true);
        }

        if (botaoContinuar != null)
        {
            botaoContinuar.SetActive(true);
        }
    }

    public void ContinuarJogo()
    {
        Time.timeScale = 1f;

        if (textoPontuacao != null) textoPontuacao.gameObject.SetActive(false);
        if (botaoContinuar != null) botaoContinuar.SetActive(false);
        if (painelQuestionario != null) painelQuestionario.SetActive(false);
        if (botaoQuestionario != null) botaoQuestionario.SetActive(false);
    }

    public void EsconderResultado()
    {
        if (textoResultado != null)
        {
            textoResultado.text = "";
            textoResultado.gameObject.SetActive(false);
        }
    }

    private void EsconderTodasPerguntas()
    {
        conteudoPergunta1.SetActive(false);
        conteudoPergunta2.SetActive(false);
        conteudoPergunta3.SetActive(false);
        conteudoPergunta4.SetActive(false);
    }
}