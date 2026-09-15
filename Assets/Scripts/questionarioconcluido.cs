using UnityEngine;

public class QuestionarioConcluido : MonoBehaviour
{
    [Header("Referência da Seta")]
    // Arraste o objeto da Seta para este campo no Inspector
    public GameObject setaIndicadora;

    // Função que será chamada quando o jogador clicar em "Continuar"
    public void AoClicarContinuar()
    {
        if (setaIndicadora != null)
        {
            // Ativa o objeto da seta na cena
            setaIndicadora.SetActive(true);
        }

        // Caso você precise fechar a janela do questionário ao clicar:
        // gameObject.SetActive(false); 
    }
}