using UnityEngine;

public class Estatua : MonoBehaviour
{
    public int idEstatua;

    private Vector3 posicaoInicial;
    private bool arrastando = false;

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void OnMouseDown()
    {
        arrastando = true;
    }

    void OnMouseDrag()
    {
        Vector3 posicaoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        posicaoMouse.z = transform.position.z;

        transform.position = posicaoMouse;
    }

    void OnMouseUp()
    {
        arrastando = false;

        Collider2D[] objetosPerto = Physics2D.OverlapCircleAll(
            transform.position,
            0.5f
        );

        foreach (Collider2D objeto in objetosPerto)
        {
            Silhueta silhueta = objeto.GetComponent<Silhueta>();

            if (silhueta != null)
            {
                if (silhueta.VerificarEstatua(this))
                {
                    transform.position = silhueta.transform.position;

                    Debug.Log("CORRETO! 🎉");
                    return;
                }
            }
        }

        // Se não encontrou a silhueta correta
        transform.position = posicaoInicial;

        Debug.Log("ERRADO! A estátua voltou para o lugar. ❌");
    }
}