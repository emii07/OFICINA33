using UnityEngine;

public class Engenho : MonoBehaviour
{
    [Header("Pontos onde as peças vão reaparecer no Engenho")]
    public Transform[] pontosDeEncaixe; // Lembre de colocar Size = 3 no Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GerenciadorColeta inventario = other.GetComponent<GerenciadorColeta>();

            if (inventario != null)
            {
                // Verifica se tem todas as peças
                if (inventario.TemTodasAsPecas())
                {
                    Debug.Log("Todas as peças entregues! Reconstruindo engenho...");
                    
                    // Faz as peças reaparecerem nos pontos de encaixe definidos
                    inventario.ReaparecerPecas(pontosDeEncaixe);
                }
                else
                {
                    Debug.Log("Você precisa de todas as peças para reativar o engenho!");
                }
            }
        }
    }
}