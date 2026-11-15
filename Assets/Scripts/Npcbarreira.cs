using UnityEngine;
using TMPro; // Necessário para usar TextMeshPro

public class NPCBarreira : MonoBehaviour
{
    [Header("UI do Diálogo")]
    [Tooltip("Arraste o Painel de Diálogo do Canvas")]
    [SerializeField] private GameObject painelDialogo;

    [Tooltip("Arraste o componente de Texto (TMP) onde a fala vai aparecer")]
    [SerializeField] private TMP_Text textoFala;

    [Header("Configuração da Fala")]
    [TextArea(2, 5)]
    [SerializeField] private string falaDoNPC = "Olá! Pode passar, o caminho está livre.";

    [Header("Componentes do NPC")]
    [Tooltip("Collider 2D do NPC que bloqueia a passagem (será desativado após o diálogo)")]
    [SerializeField] private Collider2D colisorBloqueio;

    private bool jaFalou = false;

    private void Start()
    {
        // Se o colisor não for arrastado no Inspector, pega o próprio Collider2D do objeto
        if (colisorBloqueio == null)
        {
            colisorBloqueio = GetComponent<Collider2D>();
        }

        // Garante que o painel comece escondido
        if (painelDialogo != null)
        {
            painelDialogo.SetActive(false);
        }
    }

    // Alterado para Trigger para permitir que a personagem entre na área de diálogo e pare diante do NPC
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se quem entrou foi a personagem e se ele ainda não falou
        if (collision.CompareTag("Player") && !jaFalou)
        {
            IniciarDialogo();
        }
    }

    private void IniciarDialogo()
    {
        jaFalou = true;

        if (textoFala != null)
        {
            textoFala.text = falaDoNPC;
        }

        if (painelDialogo != null)
        {
            painelDialogo.SetActive(true);
        }

        // Pausa a movimentação do jogo enquanto lê
        Time.timeScale = 0f;
    }

    // Chame este método no evento On Click () do botão "Continuar/Fechar" do diálogo
    public void FecharDialogoEProsseguir()
    {
        // Fecha a caixa de diálogo
        if (painelDialogo != null)
        {
            painelDialogo.SetActive(false);
        }

        // Desativa o colisor para liberar a passagem da personagem
        if (colisorBloqueio != null)
        {
            colisorBloqueio.enabled = false;
        }

        // Despausa o jogo
        Time.timeScale = 1f;
    }
}