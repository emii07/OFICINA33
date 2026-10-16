using UnityEngine;

public class MostrarExplicacao : MonoBehaviour
{
    public GameObject painelExplicacao;
    public GameObject personagem;

    private bool explicacaoConcluida = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (explicacaoConcluida)
            return;

        if (other.CompareTag("Player"))
        {
            painelExplicacao.SetActive(true);
            personagem.SetActive(false);
        }
    }

    public void ConcluirExplicacao()
    {
        explicacaoConcluida = true;
    }
}