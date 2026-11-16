using UnityEngine;

public class VerificarInventario : MonoBehaviour
{
    [Header("Slots dos Fragmentos no Inventário")]
    [SerializeField] private GameObject imagemFragmento1;
    [SerializeField] private GameObject imagemFragmento2;
    [SerializeField] private GameObject imagemFragmento3;
    [SerializeField] private GameObject imagemFragmento4;

    void Awake()
    {
        VerificarStatusFragmentos();
    }

    void OnEnable()
    {
        VerificarStatusFragmentos();
    }

    void VerificarStatusFragmentos()
    {
        // Fragmento 1
        int coletado1 = PlayerPrefs.GetInt("Fragmento1Coletado", 0);
        if (imagemFragmento1 != null)
        {
            imagemFragmento1.SetActive(coletado1 == 1);
        }

        // Fragmento 2
        int coletado2 = PlayerPrefs.GetInt("Fragmento2Coletado", 0);
        if (imagemFragmento2 != null)
        {
            imagemFragmento2.SetActive(coletado2 == 1);
        }

        // Fragmento 3
        int coletado3 = PlayerPrefs.GetInt("Fragmento3Coletado", 0);
        if (imagemFragmento3 != null)
        {
            imagemFragmento3.SetActive(coletado3 == 1);
        }

        // Fragmento 4
        int coletado4 = PlayerPrefs.GetInt("Fragmento4Coletado", 0);
        if (imagemFragmento4 != null)
        {
            imagemFragmento4.SetActive(coletado4 == 1);
        }
    }
}