using UnityEngine;
using TMPro; // Necessário para usar TextMeshPro
using UnityEngine.SceneManagement; // Opcional: para carregar o jogo ao terminar

public class IntroStoryManager : MonoBehaviour
{
    [Header("Componentes de UI")]
    [SerializeField] private GameObject painelHistoria;
    [SerializeField] private GameObject botaoConhecerHistoria; // Arraste o botão para cá no Inspector
    [SerializeField] private TMP_Text campoTextoHistoria;

    [Header("Páginas da História")]
    [TextArea(3, 6)]
    [SerializeField] private string[] paginasTexto;

    [Header("Opcional: Avançar de Cena")]
    [SerializeField] private bool carregarCenaAoTerminar = false;
    [SerializeField] private string nomeDaCenaJogo = "Jogo";

    private int indiceAtual = 0;

    // Conectar ao botão "Conhecer História"
    public void AbrirHistoria()
    {
        painelHistoria.SetActive(true);

        // Esconde o botão "Conhecer História"
        if (botaoConhecerHistoria != null)
        {
            botaoConhecerHistoria.SetActive(false);
        }

        indiceAtual = 0;
        ExibirPaginaAtual();
    }

    // Conectar ao botão "Continuar"
    public void AvancarTexto()
    {
        indiceAtual++;

        // Verifica se ainda existem páginas para mostrar
        if (indiceAtual < paginasTexto.Length)
        {
            ExibirPaginaAtual();
        }
        else
        {
            // Chegou ao fim da história
            FinalizarHistoria();
        }
    }

    private void ExibirPaginaAtual()
    {
        if (paginasTexto.Length > 0 && campoTextoHistoria != null)
        {
            campoTextoHistoria.text = paginasTexto[indiceAtual];
        }
    }

    private void FinalizarHistoria()
    {
        painelHistoria.SetActive(false);

        if (carregarCenaAoTerminar)
        {
            SceneManager.LoadScene(nomeDaCenaJogo);
        }
    }
}