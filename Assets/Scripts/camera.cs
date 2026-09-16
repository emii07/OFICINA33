using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform alvo; // O Player
    public float velocidadeSuave = 0.125f;
    public Vector3 offset = new Vector3(0, 0, -10);

    void LateUpdate()
    {
        if (alvo != null)
        {
            Vector3 posicaoDesejada = alvo.position + offset;
            transform.position = Vector3.Lerp(transform.position, posicaoDesejada, velocidadeSuave);
        }
    }
}