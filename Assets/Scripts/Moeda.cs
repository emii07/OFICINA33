using UnityEngine;

public class Moeda : MonoBehaviour
{
    public int valor = 1;

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (CoinManager.Instance != null)
            {
                CoinManager.Instance.AdicionarMoeda(valor);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("CoinManager não encontrado na cena!");
            }
        }
    }

}