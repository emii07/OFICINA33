using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Caso queira atualizar um texto TMP do Fragmento 3 pelo código

public class Maquina : MonoBehaviour
{
    [Header("Itens e Efeitos da Máquina")]
    public GameObject[] itensVisuaisNaMaquina;
    public ParticleSystem efeitoBrilho;

    [Header("Painel do Fragmento 3")]
    public GameObject painelFragmento3; // Pode arrastar seu painelFragmento aqui
    public TMP_Text textoFragmento3; // Opcional: se quiser setar o texto via código
    public string mensagemFragmento3 = "Fragmento 3 recuperado!";
    public float atrasoParaMostrarPainel = 2f;

    [Header("Próxima Fase")]
    // Digite aqui (ou no Inspector) o NOME EXATO da próxima cena / confronto final
    public string nomeProximaFase = "ConfrontoFinal";

    private bool maquinaConsertada = false;

    void Start()
    {
        foreach (GameObject item in itensVisuaisNaMaquina)
        {
            if (item != null)
                item.SetActive(false);
        }

        if (painelFragmento3 != null)
            painelFragmento3.SetActive(false);
    }

    public void ReceberItens()
    {
        if (maquinaConsertada) return;
        maquinaConsertada = true;

        foreach (GameObject item in itensVisuaisNaMaquina)
        {
            if (item != null)
                item.SetActive(true);
        }

        if (efeitoBrilho != null)
            efeitoBrilho.Play();

        StartCoroutine(AguardarEMostrarPainelFragmento3());
    }

    private IEnumerator AguardarEMostrarPainelFragmento3()
    {
        yield return new WaitForSeconds(atrasoParaMostrarPainel);

        if (textoFragmento3 != null)
            textoFragmento3.text = mensagemFragmento3;

        if (painelFragmento3 != null)
            painelFragmento3.SetActive(true);
    }

    // Use esta função no evento On Click () do botão "Próxima Fase"
    public void IrParaProximaFase()
    {
        Time.timeScale = 1f;

        if (!string.IsNullOrWhiteSpace(nomeProximaFase))
        {
            SceneManager.LoadScene(nomeProximaFase);
        }
        else
        {
            Debug.LogWarning("Nome da próxima fase não foi preenchido no script Maquina.");
        }
    }

    // Mantida por compatibilidade caso algum botão já aponte para ela
    public void IrParaConfrontoFinal()
    {
        IrParaProximaFase();
    }
}