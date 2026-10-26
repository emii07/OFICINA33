using UnityEngine;
using System.Collections.Generic;

public class GerenciadorColeta : MonoBehaviour
{
    public int totalPecasNecessarias = 3;
    
    // Lista privada que serve como nosso "Inventário" das peças coletadas
    private List<GameObject> inventarioPecas = new List<GameObject>();

    // Método chamado quando encosta em uma peça
    public void ColetarPeca(GameObject peca)
    {
        // Desativa a peça no mundo em vez de destruí-la totalmente
        peca.SetActive(false);
        
        // Adiciona a peça no inventário
        inventarioPecas.Add(peca);
        
        Debug.Log($"Peça coletada! Inventário: {inventarioPecas.Count} / {totalPecasNecessarias}");
    }

    // Verifica se temos todas as peças
    public bool TemTodasAsPecas()
    {
        return inventarioPecas.Count >= totalPecasNecessarias;
    }

    // Método para fazer as peças reaparecerem no local do engenho
    public void ReaparecerPecas(Transform[] pontosDeEncaixe)
    {
        for (int i = 0; i < inventarioPecas.Count; i++)
        {
            if (i < pontosDeEncaixe.Length)
            {
                // Move a peça para a posição de encaixe no engenho
                inventarioPecas[i].transform.position = pontosDeEncaixe[i].position;
                inventarioPecas[i].transform.rotation = pontosDeEncaixe[i].rotation;
                
                // Reativa a peça na tela
                inventarioPecas[i].SetActive(true);
            }
        }
        
        // Limpa o inventário após reaparecerem
        inventarioPecas.Clear();
    }
}