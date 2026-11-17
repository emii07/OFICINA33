using UnityEngine;
using UnityEngine.InputSystem;

public class InteracaoLinhaDoTempo : MonoBehaviour
{
    public GameObject painelLinhaDoTempo;

    private bool jogadorPerto = false;

    private void Update()
    {
        if (jogadorPerto &&
            Keyboard.current != null &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            painelLinhaDoTempo.SetActive(true);

            // Trava a movimentação da boneca
            Jogador.travadoNoMinigame = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
        }
    }
}