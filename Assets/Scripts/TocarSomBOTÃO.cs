using UnityEngine;

public class TocarSomBotao : MonoBehaviour
{
    // Arraste o objeto "GerenciadorAudio" aqui pelo Inspector
    [SerializeField] private AudioSource audioSourceSFX;

    public void TocarSom()
    {
        if (audioSourceSFX != null)
        {
            audioSourceSFX.Play(); // Toca o som que está no Audio Source
        }
    }
}