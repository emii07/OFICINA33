using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Necessário se for mudar de cena no "Viajar"

public class DialogoPainel : MonoBehaviour
{
    [Header("Componentes de UI")]
    [SerializeField] private TMP_Text campoTextoDialogo;
    [SerializeField] private TMP_Text textoDoBotao; // O componente Text (TMP) de dentro do botão

    [Header("Configuração da Viagem")]
    [SerializeField] private string nomeDaCenaDestino = "NomeDaSuaCena"; // Digite o nome da cena para onde o jogador vai

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
        // Reseta para a primeira fala e ajusta o botão sempre que o painel abrir
        indiceAtual = 0;
        AtualizarInterface();
    }

    // Função ÚNICA para conectar ao On Click () do botão
    public void CliqueDoBotao()
    {
        // Se ainda NÃO for a última fala, avança para o próximo texto
        if (indiceAtual < falas.Length - 1)
        {
            indiceAtual++;
            AtualizarInterface();
        }
        else
        {
            // Se JÁ estiver na última fala, executa a ação de viajar
            ExecutarViagem();
        }
    }

    private void AtualizarInterface()
    {
        // Atualiza o texto do balão
        campoTextoDialogo.text = falas[indiceAtual];

        // Mudar a palavra no botão dependendo da etapa
        if (indiceAtual < falas.Length - 1)
        {
            textoDoBotao.text = "Continuar";
        }
        else
        {
            textoDoBotao.text = "Viajar";
        }
    }

    private void ExecutarViagem()
    {
        // Carrega a nova cena do jogo ao clicar em "Viajar"
        SceneManager.LoadScene(nomeDaCenaDestino);
    }
}