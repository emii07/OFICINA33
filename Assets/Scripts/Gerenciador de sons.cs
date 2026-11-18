using UnityEngine;

public class GerenciadorDeSons : MonoBehaviour
{
    public static GerenciadorDeSons Instance;

    [Header("Componente de Áudio")]
    [SerializeField] private AudioSource audioSource;

    [Header("Efeitos Sonoros (SFX)")]
    [SerializeField] private AudioClip somColetaFragmento;
    [SerializeField] private AudioClip somBotao;
    [SerializeField] private AudioClip somRespostaCorreta; // Novo som de acerto

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void TocarSomColeta()
    {
        if (somColetaFragmento != null && audioSource != null)
        {
            audioSource.PlayOneShot(somColetaFragmento);
        }
    }

    public void TocarSomBotao()
    {
        if (somBotao != null && audioSource != null)
        {
            audioSource.PlayOneShot(somBotao);
        }
    }

    // Nova função para tocar o som de resposta correta
    public void TocarSomRespostaCorreta()
    {
        if (somRespostaCorreta != null && audioSource != null)
        {
            audioSource.PlayOneShot(somRespostaCorreta);
        }
    }
}