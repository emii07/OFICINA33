using UnityEngine;
using UnityEngine.SceneManagement; // Mantido para quando for utilizar funções de cena
using TMPro;
using System.Collections;

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

    [Header("Painel do Fragmento Recuperado")]
    [Tooltip("Arraste aqui o Painel (GameObject) completo com a foto e a mensagem")]
    [SerializeField] private GameObject painelFragmento;
    [Tooltip("Tempo em segundos que o painel do fragmento fica visível")]
    [SerializeField] private float tempoExibicaoFragmento = 4f;

    [Header("Navegação de Cena")]
    [Tooltip("Índice da cena no Build Settings (ex: Nível 2 = 7)")]
    [SerializeField] private int indiceProximaCena = 7;

    [Header("Conteúdos das Perguntas")]
    [SerializeField] private GameObject conteudoPergunta1;
    [SerializeField] private GameObject conteudoPergunta2;
    [SerializeField] private GameObject conteudoPergunta3;
    [SerializeField] private GameObject conteudoPergunta4;

    private bool aguardandoFim = false;

    private void Start()
    {
        painelQuestionario.SetActive(false);
        EsconderTodasPerguntas();
        EsconderResultado();

        if (textoPontuacao != null) textoPontuacao.gameObject.SetActive(false);
        if (botaoContinuar != null) botaoContinuar.SetActive(false);
        if (painelFragmento != null) painelFragmento.SetActive(false);

        RespostaQuestionario.textoResultado = textoResultado;
    }

    private void Update()
    {
        if (painelQuestionario.activeSelf && RespostaQuestionario.perguntasRespondidas >= 4 && !aguardandoFim)
        {
            if (textoPontuacao != null && !textoPontuacao.gameObject.activeSelf)
            {
                aguardandoFim = true;
                StartCoroutine(EsperarEFinalizar());
            }
        }
    }

    private IEnumerator EsperarEFinalizar()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        FinalizarQuestionario();
    }

    public void AbrirQuestionario()
    {
        painelQuestionario.SetActive(true);
        Time.timeScale = 0f; 
        
        aguardandoFim = false;
        RespostaQuestionario.acertos = 0;
        RespostaQuestionario.perguntasRespondidas = 0;

        if (textoPontuacao != null) textoPontuacao.gameObject.SetActive(false);
        if (botaoContinuar != null) botaoContinuar.SetActive(false);
        if (painelFragmento != null) painelFragmento.SetActive(false);

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

        StartCoroutine(EsperarEFecharAutomatico());
    }

    private IEnumerator EsperarEFecharAutomatico()
    {
        yield return new WaitForSecondsRealtime(4f);
        ContinuarJogo();
    }

    public void ContinuarJogo()
    {
        // Reativa a velocidade normal do jogo para que a personagem volte a andar
        Time.timeScale = 1f;

        if (textoPontuacao != null) textoPontuacao.gameObject.SetActive(false);
        if (botaoContinuar != null) botaoContinuar.SetActive(false);
        if (painelQuestionario != null) painelQuestionario.SetActive(false);
        if (botaoQuestionario != null) botaoQuestionario.SetActive(false);

        // Se houver painel do fragmento, exibe e depois mantém a personagem na cena
        if (painelFragmento != null)
        {
            StartCoroutine(ExibirPainelEContinuarNaCena());
        }
    }

    private IEnumerator ExibirPainelEContinuarNaCena()
    {
        painelFragmento.SetActive(true);

        // Aguarda os segundos configurados
        yield return new WaitForSecondsRealtime(tempoExibicaoFragmento);

        // Apenas oculta o painel do fragmento sem carregar outra cena
        painelFragmento.SetActive(false);
    }

    public void CarregarProximaCena()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(indiceProximaCena);
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

    public void CarregarNivel2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(7);
    }
}