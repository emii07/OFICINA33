using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorFragmento : MonoBehaviour
{
    // Função para chamar no botão Continuar
    public void AvancarParaNivel2()
    {
        Debug.Log("Carregando o Nível 2...");
        Time.timeScale = 1f; // Garante que o jogo não fica congelado
        SceneManager.LoadScene(7); // Índice 7 = 'nivel 2' no Build Settings
    }
}