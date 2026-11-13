using UnityEngine;

public class AbrirPuzzle1Trigger : MonoBehaviour
{
    public PuzzleLivros controlador;
    private bool ativado = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ativado) return;

        if (!other.CompareTag("Player") &&
            !other.transform.root.CompareTag("Player"))
            return;

        if (controlador == null) return;

        ativado = true;
        controlador.AbrirPuzzle();

        GetComponent<Collider2D>().enabled = false;
    }
}