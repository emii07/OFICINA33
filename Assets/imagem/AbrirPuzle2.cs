using UnityEngine;

public class AbrirPuzzle2Trigger : MonoBehaviour
{
    public PuzzlePersonagem controlador;
    private bool jaAbriu = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (jaAbriu) return;

        if (other.CompareTag("Player"))
        {
            jaAbriu = true;
            controlador.AbrirPuzzle();
        }
    }
}