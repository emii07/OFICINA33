using UnityEngine;

public class AbrirPuzzle1Trigger : MonoBehaviour
{
    public PuzzleLivros controlador;
    private bool ativado = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ativado) return;

        if (other.CompareTag("Player"))
        {
            ativado = true;
            controlador.AbrirPuzzle();
            gameObject.SetActive(false);
        }
    }
}