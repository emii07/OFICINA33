using UnityEngine;

public class InteracaoLinhaDoTempo : MonoBehaviour
{
    public GameObject painelLinhaDoTempo;

    private bool atividadeIniciada = false;

    private void Start()
    {
        painelLinhaDoTempo.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !atividadeIniciada)
        {
            atividadeIniciada = true;

            painelLinhaDoTempo.SetActive(true);

            Jogador.travadoNoMinigame = true;
        }
    }
}