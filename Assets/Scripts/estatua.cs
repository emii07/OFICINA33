using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Estatua : MonoBehaviour
{
    public int idEstatua;

    private Vector3 posicaoInicial;
    private bool arrastando = false;
    private bool acertou = false;

    [Header("Configurações de Vitória e Cena")]
    public GameObject painelSilhuetas;
    public GameObject painelVitoria;
    public string nomeProximaCena;
    public float delayMudarCena = 2f;

    [Header("Meta de Acertos")]
    public int totalEstátuasParaConcluir = 6;

    private static int quantidadeAcertos = 0;
    private static bool puzzleConcluido = false;

    void Start()
    {
        posicaoInicial = transform.position;
        quantidadeAcertos = 0;
        puzzleConcluido = false;

        if (painelVitoria != null)
            painelVitoria.SetActive(false);
    }

    void OnMouseDown()
    {
        arrastando = true;
    }

    void OnMouseDrag()
    {
        if (Camera.main == null) return;

        Vector3 posicaoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        posicaoMouse.z = transform.position.z;
        transform.position = posicaoMouse;
    }

    void OnMouseUp()
    {
        arrastando = false;

        Collider2D[] objetosPerto = Physics2D.OverlapCircleAll(transform.position, 0.5f);

        foreach (Collider2D objeto in objetosPerto)
        {
            Silhueta silhueta = objeto.GetComponent<Silhueta>();

            if (silhueta != null && silhueta.VerificarEstatua(this))
            {
                transform.position = silhueta.transform.position;

                if (!acertou)
                {
                    acertou = true;
                    quantidadeAcertos++;

                    if (!puzzleConcluido && quantidadeAcertos >= totalEstátuasParaConcluir)
                    {
                        puzzleConcluido = true;

                        if (painelSilhuetas != null)
                            painelSilhuetas.SetActive(false);

                        if (painelVitoria != null)
                            painelVitoria.SetActive(true);

                        Jogador.travadoNoMinigame = false;

                        if (EventSystem.current != null)
                            EventSystem.current.SetSelectedGameObject(null);

                        if (!string.IsNullOrEmpty(nomeProximaCena))
                            StartCoroutine(MudarCenaComDelay());
                    }
                }

                return;
            }
        }

        transform.position = posicaoInicial;
    }

    private IEnumerator MudarCenaComDelay()
    {
        yield return new WaitForSeconds(delayMudarCena);
        SceneManager.LoadScene(nomeProximaCena);
    }

    public void MudarParaProximaCenaAgora()
    {
        Jogador.travadoNoMinigame = false;

        if (!string.IsNullOrEmpty(nomeProximaCena))
            SceneManager.LoadScene(nomeProximaCena);
    }
}