using UnityEngine;
using TMPro;

public class GatilhoFalaNPC : MonoBehaviour
{
    [Header("UI do Diálogo")]
    [Tooltip("Arraste o Painel de Diálogo do Canvas")]
    [SerializeField] private GameObject painelDialogo;

    [Tooltip("Arraste o componente de Texto (TMP) onde a fala vai aparecer")]
    [SerializeField] private TMP_Text textoFala;

    [Header("Configuração da Fala")]
    [TextArea(2, 5)]
    [SerializeField] private string falaDoNPC = "Olá! Pode passar, o caminho está livre.";

    [Header("Referência do NPC")]
    [Tooltip("Arraste o GameObject do NPC que está mais à frente")]
    [SerializeField] private Collider2D colisorBloqueioNPC;

    private bool jaAtivou = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Dispara assim que o jogador pisa no objeto invisível
        if (collision.CompareTag("Player") && !jaAtivou)
        {
            IniciarDialogo();
        }
    }

    private void IniciarDialogo()
    {
        jaAtivou = true;

        if (textoFala != null)
        {
            textoFala.text = falaDoNPC;
        }

        if (painelDialogo != null)
        {
            painelDialogo.SetActive(true);
        }

        // Pausa a movimentação do jogador enquanto o diálogo está na tela
        Time.timeScale = 0f;
    }

    // Associe este método ao botão "Continuar/Fechar" da caixa de diálogo
    public void FecharDialogoEAbreCaminho()
    {
        // Esconde o painel
        if (painelDialogo != null)
        {
            painelDialogo.SetActive(false);
        }

        // Desativa o colisor do NPC que estava mais à frente
        if (colisorBloqueioNPC != null)
        {
            colisorBloqueioNPC.enabled = false;
        }

        // Libera a movimentação
        Time.timeScale = 1f;

        // Desativa este gatilho para não disparar novamente se o jogador voltar
        gameObject.SetActive(false);
    }
}