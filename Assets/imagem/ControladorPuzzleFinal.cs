using UnityEngine;
using TMPro;

public class ControladorPuzzleFinal : MonoBehaviour
{
    [Header("Painel")]
    public GameObject painelPuzzleFinal;
    public TMP_Text textoConclusao;
    public GameObject botaoContinuar;

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
    }

    public void AbrirPuzzle()
    {
        Jogador.travadoNoMinigame = true;

        // Faz a personagem desaparecer
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
            textoConclusao.text =
                "Parabéns! O Grande Livro foi reconstruído!";

            textoConclusao.gameObject.SetActive(true);
        }

        if (botaoContinuar != null)
            botaoContinuar.SetActive(true);

        Debug.Log("Livro da memória reconstruído!");
    }

    public void Continuar()
    {
        Debug.Log("Botão Continuar clicado!");

        if (painelPuzzleFinal != null)
            painelPuzzleFinal.SetActive(false);

        // Faz a personagem reaparecer
        if (sprites != null)
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                if (sprites[i] != null)
                    sprites[i].enabled = estadosOriginais[i];
            }
        }

        // Libera a movimentação
        Jogador.travadoNoMinigame = false;

        Debug.Log("Personagem reapareceu e voltou a andar!");
    }
}