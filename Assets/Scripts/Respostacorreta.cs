using UnityEngine;

public class RespostaCorreta : MonoBehaviour
{
    // Função para chamar quando o jogador acertar
    public void AcertouResposta()
    {
        // Toca o som de resposta correta automaticamente através do Gerenciador central
        if (GerenciadorDeSons.Instance != null)
        {
            GerenciadorDeSons.Instance.TocarSomRespostaCorreta();
        }
    }
}