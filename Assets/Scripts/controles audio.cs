using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [Header("Configurações do Mixer")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string parameterName = "MasterVolume";

    [Header("Componentes de UI (Opcional)")]
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        // Se houver um Slider atribuído, inicializa o valor salvo ou padrão
        if (volumeSlider != null)
        {
            float volumeSalvo = PlayerPrefs.GetFloat(parameterName, 1f);
            volumeSlider.value = volumeSalvo;
            SetVolume(volumeSalvo);
        }
    }

    // Função para conectar ao Slider (On Value Changed)
    public void SetVolume(float linearValue)
    {
        // O AudioMixer usa decibéis (-80dB a 0dB). Convertemos a escala de 0.0001..1 para dB.
        float dB = Mathf.Log10(Mathf.Clamp(linearValue, 0.0001f, 1f)) * 20;
        audioMixer.SetFloat(parameterName, dB);

        // Salva a preferência do jogador
        PlayerPrefs.SetFloat(parameterName, linearValue);
    }

    // Função para usar com Botões (+ ou -)
    public void AlterarVolumePasso(float passo)
    {
        if (volumeSlider != null)
        {
            volumeSlider.value = Mathf.Clamp01(volumeSlider.value + passo);
        }
        else
        {
            float volumeSalvo = PlayerPrefs.GetFloat(parameterName, 1f);
            float novoVolume = Mathf.Clamp01(volumeSalvo + passo);
            SetVolume(novoVolume);
        }
    }
}