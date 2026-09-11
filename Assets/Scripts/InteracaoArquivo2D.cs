using UnityEngine;
using UnityEngine.InputSystem;

public class InteracaoArquivo2D : MonoBehaviour
{
    private bool jogadorPerto = false;

    private void Update()
    {
        if (jogadorPerto && Keyboard.current.eKey.wasPressedThisFrame)
        {
            PuzzleArchiveManager.Instance.AbrirPuzzle();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jogadorPerto = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jogadorPerto = false;
        }
    }
}