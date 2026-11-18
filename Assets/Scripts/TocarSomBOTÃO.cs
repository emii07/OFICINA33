using UnityEngine;

public class TocarSomBotao : MonoBehaviour
{
    public void TocarSom()
    {
        // Puxa direto do Gerenciador de Sons centralizado
        if (GerenciadorDeSons.Instance != null)
        {
            GerenciadorDeSons.Instance.TocarSomBotao();
        }
    }
}