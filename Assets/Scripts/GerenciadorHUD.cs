using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorHUD : MonoBehaviour
{
    [Header("Painéis")]
    [Tooltip("Arraste o painel de pause aqui")]
    [SerializeField] private GameObject painelPause;
    
    [Tooltip("Arraste o painel de inventário aqui")]
    [SerializeField] private GameObject painelInventario;

    private bool jogoPausado = false;
    private bool inventarioAberto = false;

    void Update()
    {
        // Atalho opcional com a tecla Esc para o Pause (se nenhum inventário estiver aberto)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inventarioAberto)
            {
                FecharInventario();
            }
            else
            {
                TogglePause();
            }
        }
    }

    // --- FUNÇÃO DE REINICIAR CENA ---
    public void ReiniciarCena()
    {
        Time.timeScale = 1f; // Garante que o tempo volta ao normal antes de recarregar
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // --- FUNÇÃO DE PAUSE ---
    public void TogglePause()
    {
        jogoPausado = !jogoPausado;

        if (painelPause != null)
        {
            painelPause.SetActive(jogoPausado);
        }

        // Se o inventário estiver aberto e pausarmos, fechamos o inventário para priorizar o pause
        if (jogoPausado && inventarioAberto)
        {
            inventarioAberto = false;
            if (painelInventario != null) painelInventario.SetActive(false);
        }

        // Congela o tempo se pausado, retoma se despausado (a menos que o inventário ainda esteja aberto)
        Time.timeScale = (jogoPausado || inventarioAberto) ? 0f : 1f;
    }

    // --- FUNÇÃO DE INVENTÁRIO ---
    public void ToggleInventario()
    {
        inventarioAberto = !inventarioAberto;

        if (painelInventario != null)
        {
            painelInventario.SetActive(inventarioAberto);
        }

        // Se o jogo estiver pausado e abrirmos o inventário, podemos optar por manter o jogo congelado
        Time.timeScale = (jogoPausado || inventarioAberto) ? 0f : 1f;
    }

    public void FecharInventario()
    {
        inventarioAberto = false;
        if (painelInventario != null)
        {
            painelInventario.SetActive(false);
        }

        // Retorna o tempo ao normal apenas se o pause também não estiver ativo
        Time.timeScale = jogoPausado ? 0f : 1f;
    }
    // --- FUNÇÃO DE CONTINUAR / FECHAR PAUSE ---
    public void Continuar()
    {
        jogoPausado = false;

        if (painelPause != null)
        {
            painelPause.SetActive(false);
        }

        // Retorna o tempo ao normal apenas se o inventário também não estiver aberto
        Time.timeScale = inventarioAberto ? 0f : 1f;
    }
    // --- FUNÇÃO PARA FECHAR QUALQUER PAINEL ESPECÍFICO ---
    public void FecharPainel(GameObject painelParaFechar)
    {
        if (painelParaFechar != null)
        {
            painelParaFechar.SetActive(false);
        }

        // Se quiser garantir que o tempo volta ao normal ao fechar um menu (opcional):
        Time.timeScale = 1f;
    }
} 
