using UnityEngine;

public class AbrirPuzzle1Trigger : MonoBehaviour
{
    public PuzzleLivros controlador;

    private bool ativado = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ativado)
            return;

        if (!other.CompareTag("Player") &&
            !other.transform.root.CompareTag("Player"))
            return;

        if (controlador == null)
        {
            Debug.LogError("Trigger Puzzle 1: Controlador não atribuído!");
            return;
        }

        Debug.Log("Ponto Puzzle 1 detectado!");

        bool abriu = controlador.AbrirPuzzle();

        if (abriu)
        {
            ativado = true;

            Collider2D colisor = GetComponent<Collider2D>();

            if (colisor != null)
                colisor.enabled = false;

            Debug.Log("Trigger Puzzle 1 ativado com sucesso!");
        }
        else
        {
            Debug.LogError(
                "Puzzle 1 não abriu. O Trigger continuará disponível!"
            );
        }
    }
}