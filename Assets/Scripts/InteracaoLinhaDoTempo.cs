using UnityEngine;

public class InteracaoLinhaDoTempo : MonoBehaviour
{
    public GameObject painelLinhaDoTempo;

    private bool jogadorPerto = false;

    private void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            painelLinhaDoTempo.SetActive(true);
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