using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PainelInteracao : MonoBehaviour
{
    [Header("Componentes de UI")]
    [SerializeField] private TMP_Text campoTextoDialogo;
    [SerializeField] private TMP_Text textoDoBotao;

    [Header("Configuração da Viagem")]
    [SerializeField] private string nomeDaCenaDestino = "NomeDaSuaCena";

    [Header("Conteúdo da Fala")]
    [TextArea(2, 4)]
    [SerializeField] private string[] falas = new string[]
    {
        "O Grande Livro da Memória de Ceará-Mirim foi dividido em cinco fragmentos. Com o passar do tempo, parte da nossa história começou a desaparecer...",
        "...Apenas alguém disposto a compreender o verdadeiro valor da cidade poderá reunir seus fragmentos."
    };

    private int indiceAtual = 0;

    private void OnEnable()
    {
        indiceAtual = 0;
        AtualizarInterface();
    }

    public void CliqueDoBotao()
    {
        if (falas != null && indiceAtual < falas.Length - 1)
        {
            indiceAtual++;
            AtualizarInterface();
        }
        else
        {
            ExecutarViagem();
        }
    }

    public void AtualizarInterface()
    {
        if (falas != null && falas.Length > 0 && indiceAtual < falas.Length)
        {
            if (campoTextoDialogo != null)
            {
                campoTextoDialogo.text = falas[indiceAtual];
            }

            if (textoDoBotao != null)
            {
                if (indiceAtual < falas.Length - 1)
                {
                    textoDoBotao.text = "Continuar";
                }
                else
                {
                    textoDoBotao.text = "Viajar";
                }
            }
        }
    }

    private void ExecutarViagem()
    {
        Time.timeScale = 1f;

        if (!string.IsNullOrEmpty(nomeDaCenaDestino))
        {
            SceneManager.LoadScene(nomeDaCenaDestino);
        }
    }
}