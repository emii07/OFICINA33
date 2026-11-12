using UnityEngine;

public class AbrirQuizTrigger : MonoBehaviour
{
    public QuizFinal quiz;
    private bool jaAtivou = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (jaAtivou) return;

        if (other.CompareTag("Player"))
        {
            jaAtivou = true;
            quiz.AbrirQuiz();
        }
    }
}