using UnityEngine;

public class Maquina : MonoBehaviour
{
   
    public GameObject[] itensVisuaisNaMaquina;

    void Start()
    {
       
        foreach (GameObject item in itensVisuaisNaMaquina)
        {
            item.SetActive(false);
        }
    }

   
    public void ReceberItens()
    {
        foreach (GameObject item in itensVisuaisNaMaquina)
        {
            item.SetActive(true); 
        }
        Debug.Log("Itens colocados na máquina!");
    }
}