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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se quem colidiu foi a personagem e se ele ainda não falou
        if (collision.gameObject.CompareTag("Player") && !jaFalou)
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

        // Desativa o colisor físico do NPC para a personagem conseguir passar por ele
        if (colisorBloqueio != null)
        {
            colisorBloqueio.enabled = false;
        }

        // Despausa o jogo
        Time.timeScale = 1f;
    }
}