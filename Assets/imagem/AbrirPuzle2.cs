using UnityEngine;

public class AbrirPuzzle2Trigger : MonoBehaviour
{
    public ControladorPuzzle2 controlador;

    private bool ativado = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ativado) return;

        if (other.CompareTag("Player"))
        {
            ativado = true;

            Debug.Log("Ponto Puzzle 2 ativado!");

            controlador.AbrirPuzzle();

            GetComponent<Collider2D>().enabled = false;
        }
    }
}