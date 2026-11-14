
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemaneger : MonoBehaviour
{
    [Header("Painéis da Interface")]
    public GameObject painelPause;
    public GameObject painelInventario;
    public GameObject painelMapa;

    public void PausarJogo()
    {
        painelPause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ContinuarJogo()
    {
        painelPause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void AbrirInventarioPeloPause()
    {
        painelPause.SetActive(false);
        painelInventario.SetActive(true);
        Time.timeScale = 1f;
    }

    public void AbrirMapaPeloPause()
    {
        painelPause.SetActive(false);
        painelMapa.SetActive(true);
        Time.timeScale = 1f;
    }

    public void ReiniciarCena()
    {
        Time.timeScale = 1f;
        Scene cenaAtual = SceneManager.GetActiveScene();
        SceneManager.LoadScene(cenaAtual.name);
    }

    public void FecharPaineis()
    {
        if (painelPause != null) painelPause.SetActive(false);
        if (painelInventario != null) painelInventario.SetActive(false);
        if (painelMapa != null) painelMapa.SetActive(false);
        Time.timeScale = 1f;
    }
}
