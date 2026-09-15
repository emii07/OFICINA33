using UnityEngine;

public class FlutuarSeta : MonoBehaviour
{
    public float velocidade = 3f;
    public float amplitude = 0.2f;

    private Vector3 posicaoInicial;

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void Update()
    {
        // Faz a seta mover levemente para cima e para baixo
        float novoY = Mathf.Sin(Time.time * velocidade) * amplitude;
        transform.position = posicaoInicial + new Vector3(0, novoY, 0);
    }
}