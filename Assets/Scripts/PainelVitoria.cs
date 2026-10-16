using UnityEngine;

public class PainelVitoria : MonoBehaviour
{
    public GameObject painelVitoria;
    public GameObject[] estatuas;
    public GameObject jogador;

    public void FecharPainel()
    {
        foreach (GameObject estatua in estatuas)
        {
            if (estatua != null)
            {
                estatua.SetActive(false);
            }
        }

        painelVitoria.SetActive(false);

        jogador.SetActive(true);

        Time.timeScale = 1f;
    }
}