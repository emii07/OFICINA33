using UnityEngine;

using UnityEngine;

public class PlayerColeta : MonoBehaviour
{
    private int itensColetados = 0;
    private int itensNecessarios = 3;

    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Coletavel"))
        {
            itensColetados++;
            Destroy(other.gameObject); 
            Debug.Log("Item coletado! Total: " + itensColetados);
        }

        if (other.CompareTag("Maquina"))
        {
            if (itensColetados >= itensNecessarios)
            {
                Maquina scriptMaquina = other.GetComponent<Maquina>();
                
                if (scriptMaquina != null)
                {
                    scriptMaquina.ReceberItens();
                    itensColetados = 0; 
                } 
            } 
            else
            {
                Debug.Log("Você precisa de 3 itens! Você tem: " + itensColetados);
            }
        }
    }
}