using UnityEngine;

public class PainelMensagem : MonoBehaviour
{
    public GameObject painel;

    void Start()
    {
        // Garante que o painel está visível assim que a cena inicia
        painel.SetActive(true); 
    }

    public void FecharPainel()
    {
        // Desativa o painel para o jogo continuar
        painel.SetActive(false); 
    }
}