using UnityEngine;

public class FlutuarEGirar2D : MonoBehaviour
{
    [Header("Flutuação")]
    public float amplitude = 0.25f;      // Altura máxima da flutuação
    public float velocidadeFlutuar = 2f; // Velocidade de subir e descer

    [Header("Rotação")]
    public float velocidadeGiro = 90f;   // Graus por segundo (use valor negativo para girar ao contrário)

    private Vector3 posicaoInicial;

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void Update()
    {
        // Flutua para cima e para baixo a partir da posição inicial
        float deslocamentoY = Mathf.Sin(Time.time * velocidadeFlutuar) * amplitude;
        transform.position = new Vector3(posicaoInicial.x, posicaoInicial.y + deslocamentoY, posicaoInicial.z);

        // Gira no eixo 2D (Z)
        transform.Rotate(0f, 0f, velocidadeGiro * Time.deltaTime);
    }
}