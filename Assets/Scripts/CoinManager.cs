using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

        
    public int totalMoedas = 0;

    private TextMeshProUGUI textoMoedas;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Inicia uma nova partida com zero moedas
            totalMoedas = 0;
            PlayerPrefs.SetInt("TotalMoedas", 0);
            PlayerPrefs.Save();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += AoCarregarCena;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= AoCarregarCena;
    }

    private void Start()
    {
        EncontrarTexto();
        AtualizarTexto();
    }

    private void AoCarregarCena(Scene cena, LoadSceneMode modo)
    {
        EncontrarTexto();
        AtualizarTexto();
    }

    private void EncontrarTexto()
    {
        GameObject objetoTexto = GameObject.Find("TextoMoedas");

        if (objetoTexto != null)
        {
            textoMoedas = objetoTexto.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            textoMoedas = null;
            Debug.LogWarning("TextoMoedas não encontrado nesta cena!");
        }
    }

    public void AdicionarMoeda(int quantidade)
    {
        totalMoedas += quantidade;

        PlayerPrefs.SetInt("TotalMoedas", totalMoedas);

        AtualizarTexto();

        Debug.Log("Total de moedas: " + totalMoedas);
    }

    private void AtualizarTexto()
    {
        if (textoMoedas != null)
        {
            textoMoedas.text = "Moedas: " + totalMoedas;
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("TotalMoedas", 0);
        PlayerPrefs.Save();
    }
    

}