using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para gerenciar e trocar de cenas

public class CarregarCena : MonoBehaviour
{
    [Tooltip("nivel 2 ")]
    [SerializeField] private string nomeDaProximaCena;

    // Método público para ser chamado pelo evento OnClick() do botão
    public void IrParaProximaCena()
    {
        // 1. Salva que o fragmento 1 foi coletado (1 = sim)
        PlayerPrefs.SetInt("Fragmento1Coletado", 1);
        PlayerPrefs.Save();

        // Restaura a velocidade normal do tempo antes de mudar de cena
        Time.timeScale = 1f;

        if (!string.IsNullOrEmpty(nomeDaProximaCena))
        {
            SceneManager.LoadScene(nomeDaProximaCena);
        }
        else
        {
            Debug.LogError("[CarregarCena] O nome da próxima cena não foi configurado no Inspector!");
        }
    }

    // Método alternativo para passar o nome da cena direto pelo botão
    public void MudarParaCena(string nomeCena)
    {
        // Salva que o fragmento 1 foi coletado caso use este método também
        PlayerPrefs.SetInt("Fragmento1Coletado", 1);
        PlayerPrefs.Save();

        Time.timeScale = 1f;
        SceneManager.LoadScene(nomeCena);
    }
}