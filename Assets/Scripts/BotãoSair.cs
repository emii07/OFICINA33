using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoSair : MonoBehaviour
{
    public void SairParaMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}