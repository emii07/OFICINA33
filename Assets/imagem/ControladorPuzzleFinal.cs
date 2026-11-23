using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ControladorPuzzleFinal : MonoBehaviour
{
    [Header("Painel")]
    public GameObject painelPuzzleFinal;
    public TMP_Text textoConclusao;
    public GameObject botaoContinuar;
    [Tooltip("Tempo em segundos antes de abrir o painel de vitória (0 = imediato).")]
    public float atrasoMostrarVitoria = 0f;

    [Header("Painel de Vitória")]
    public GameObject painelVitoria;
    public Image imagemUltimoFragmento;
    public Sprite spriteUltimoFragmento;
    public GameObject botaoProximaCena;
    public string nomeProximaCena;

    [Header("Personagem")]
    public GameObject personagem;

    private SpriteRenderer[] sprites;
    private bool[] estadosOriginais;

    [Header("Fragmentos")]
    public FragmentoArrastavelUI[] fragmentos;

    private bool concluido = false;

    private void Awake()
    {
        if (personagem != null)
        {
            sprites = personagem.GetComponentsInChildren<SpriteRenderer>(true);
            estadosOriginais = new bool[sprites.Length];

            for (int i = 0; i < sprites.Length; i++)
            {
                estadosOriginais[i] = sprites[i].enabled;
            }
        }
    }

    private void Start()
    {
        if (painelPuzzleFinal != null)
            painelPuzzleFinal.SetActive(false);

        if (textoConclusao != null)
            textoConclusao.gameObject.SetActive(false);

        if (botaoContinuar != null)
            botaoContinuar.SetActive(false);

        if (painelVitoria != null)
            painelVitoria.SetActive(false);

        if (botaoProximaCena != null)
            botaoProximaCena.SetActive(false);
    }

    public void AbrirPuzzle()
    {
        CancelInvoke(nameof(MostrarPainelVitoria));
        Jogador.travadoNoMinigame = true;

        if (sprites != null)
        {
            foreach (SpriteRenderer sprite in sprites)
                sprite.enabled = false;
        }

        concluido = false;

        if (textoConclusao != null)
            textoConclusao.gameObject.SetActive(false);

        if (botaoContinuar != null)
            botaoContinuar.SetActive(false);

        if (painelVitoria != null)
            painelVitoria.SetActive(false);

        if (painelPuzzleFinal != null)
            painelPuzzleFinal.SetActive(true);

        Debug.Log("Puzzle Final aberto. Personagem parada e invisível!");
    }

    public void VerificarOrdem()
    {
        if (concluido) return;

        if (fragmentos == null || fragmentos.Length != 4)
            return;

        foreach (FragmentoArrastavelUI fragmento in fragmentos)
        {
            if (fragmento == null)
                return;

            if (fragmento.posicaoAtual != fragmento.posicaoCorreta)
                return;
        }

        concluido = true;

        if (textoConclusao != null)
        {
            textoConclusao.text = "Parabéns! O Grande Livro foi reconstruído!";
            textoConclusao.gameObject.SetActive(true);
        }

        if (botaoContinuar != null)
            botaoContinuar.SetActive(false);

        Debug.Log("Livro da memória reconstruído! Abrindo painel de vitória...");

        if (atrasoMostrarVitoria > 0f)
            Invoke(nameof(MostrarPainelVitoria), atrasoMostrarVitoria);
        else
            MostrarPainelVitoria();
    }

    public void Continuar()
    {
        MostrarPainelVitoria();
    }

    public void MostrarPainelVitoria()
    {
        if (painelPuzzleFinal != null)
            painelPuzzleFinal.SetActive(false);

        if (sprites != null)
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                if (sprites[i] != null)
                    sprites[i].enabled = estadosOriginais[i];
            }
        }

        if (painelVitoria != null)
            painelVitoria.SetActive(true);

        if (imagemUltimoFragmento != null)
        {
            if (spriteUltimoFragmento != null)
                imagemUltimoFragmento.sprite = spriteUltimoFragmento;

            imagemUltimoFragmento.gameObject.SetActive(true);
        }

        if (botaoProximaCena != null)
            botaoProximaCena.SetActive(true);

        Jogador.travadoNoMinigame = true;
        Debug.Log("Painel de vitória exibido com o último fragmento!");
    }

    public void IrParaProximaCena()
    {
        Jogador.travadoNoMinigame = false;

        if (!string.IsNullOrEmpty(nomeProximaCena))
        {
            SceneManager.LoadScene(nomeProximaCena);
            return;
        }

        int proximaCenaIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (proximaCenaIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(proximaCenaIndex);
        }
        else
        {
            Debug.LogWarning("Nenhuma próxima cena configurada no Build Settings!");
        }
    }
}