using UnityEngine;

public class MenuJogo : MonoBehaviour
{
    public GameObject painelExplicacao;
    public GameObject jogoSilhuetas;

    public void Jogar()
    {
        painelExplicacao.SetActive(false);
        jogoSilhuetas.SetActive(true);
    }
}