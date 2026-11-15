using UnityEngine;
using UnityEngine.EventSystems; // Necessário para limpar o foco e liberar os inputs

public class Estatua : MonoBehaviour
{
    public int idEstatua;

    private Vector3 posicaoInicial;
    private bool arrastando = false;
    private bool acertou = false;

    [Header("Configurações de Conclusão")]
    public GameObject painelSilhuetas;        // O painel do minigame/livro que vai sumir sozinho
    public MonoBehaviour scriptMovimentoPlayer; // Arraste o script 'Jogador' da sua personagem aqui
    public GameObject painelVitoria;          // Painel de vitória opcional (se houver)

    private static int quantidadeAcertos = 0;

    void Start()
    {
        posicaoInicial = transform.position;
        // Reseta o contador ao iniciar a cena caso necessário
        quantidadeAcertos = 0; 
    }

    void OnMouseDown()
    {
        arrastando = true;
    }

    void OnMouseDrag()
    {
        Vector3 posicaoMouse = Camera.main.ScreenToWorldPoint(
            Input.mousePosition
        );

        posicaoMouse.z = transform.position.z;

        transform.position = posicaoMouse;
    }

    void OnMouseUp()
    {
        arrastando = false;

        Collider2D[] objetosPerto =
            Physics2D.OverlapCircleAll(transform.position, 0.5f);

        foreach (Collider2D objeto in objetosPerto)
        {
            Silhueta silhueta =
                objeto.GetComponent<Silhueta>();

            if (silhueta != null)
            {
                if (silhueta.VerificarEstatua(this))
                {
                    transform.position =
                        silhueta.transform.position;

                    Debug.Log("CORRETO! 🎉");

                    // Conta o acerto apenas uma vez
                    if (!acertou)
                    {
                        acertou = true;
                        quantidadeAcertos++;

                        // Quando completar as 3 estatuetas:
                        if (quantidadeAcertos >= 3)
                        {
                            if (painelVitoria != null)
                                painelVitoria.SetActive(true);

                            if (painelSilhuetas != null)
                                painelSilhuetas.SetActive(false);

                            // Libera a movimentação instantaneamente pela variável global!
                            Jogador.travadoNoMinigame = false;

                            if (EventSystem.current != null)
                            {
                                EventSystem.current.SetSelectedGameObject(null);
                            }
                        }
                    }

                    return;
                }
            }
        }

        // Se não encontrou a silhueta correta
        transform.position = posicaoInicial;

        Debug.Log("ERRADO! A estátua voltou para o lugar. ❌");
    }
}