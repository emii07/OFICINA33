using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para trocar de cena

public class Maquina : MonoBehaviour
{
    public GameObject[] itensVisuaisNaMaquina;
    public ParticleSystem efeitoBrilho; 
    public GameObject painelFragmento; 

    // Digite aqui (ou no Inspector) o NOME EXATO da sua cena de confronto final
    public string nomeCenaConfrontoFinal = "ConfrontoFinal"; 

    void Start()
    {
        foreach (GameObject item in itensVisuaisNaMaquina)
        {
            item.SetActive(false);
        }
        
        if (painelFragmento != null)
        {
            painelFragmento.SetActive(false);
        }
    }

    public void ReceberItens()
    {
        foreach (GameObject item in itensVisuaisNaMaquina)
        {
            item.SetActive(true); 
        }
        
        if (efeitoBrilho != null)
        {
            efeitoBrilho.Play();
        }

        // Mantém a contagem de tempo antes de abrir o painel
        StartCoroutine(AguardarEMostrarPainel());
    }

    private IEnumerator AguardarEMostrarPainel()
    {
        yield return new WaitForSeconds(2f);

        if (painelFragmento != null)
        {
            painelFragmento.SetActive(true);
        }
    }

    // Função atualizada para o botão "Continuar" carregar a cena do confronto final
    public void IrParaConfrontoFinal()
    {
        SceneManager.LoadScene(nomeCenaConfrontoFinal);
    }
}