using UnityEngine;
using TMPro;

public class BiografiaUI : MonoBehaviour
{
    public static BiografiaUI Instance;

    [Header("Painel da Biografia")]
    [SerializeField] private GameObject painelBiografia;

    [Header("Textos")]
    [SerializeField] private TMP_Text nomeIntelectual;
    [SerializeField] private TMP_Text textoBiografia;

    [Header("Controle das Luminárias")]
    [SerializeField] private ControleLuminarias controleLuminarias;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        painelBiografia.SetActive(false);
    }

    public void MostrarBiografia(string nome, string biografia)
    {
        nomeIntelectual.text = nome;
        textoBiografia.text = biografia;

        painelBiografia.SetActive(true);
    }

    public void FecharBiografia()
    {
        painelBiografia.SetActive(false);

        if (controleLuminarias != null)
        {
            controleLuminarias.LiberarQuestionario();
        }
    }
}