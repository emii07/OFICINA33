using UnityEngine;

public class MostrarExplicacao : MonoBehaviour
{
    public GameObject painelExplicacao;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            painelExplicacao.SetActive(true);
        }
    }
}