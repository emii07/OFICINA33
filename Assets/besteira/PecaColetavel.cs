using UnityEngine;

public class PecaColetavel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GerenciadorColeta gerenciador = other.GetComponent<GerenciadorColeta>();
            
            if (gerenciador != null)
            {
                // Passa este próprio objeto para o inventário
                gerenciador.ColetarPeca(this.gameObject);
            }
        }
    }
}