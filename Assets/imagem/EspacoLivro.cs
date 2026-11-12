using UnityEngine;

public class EspacoLivro : MonoBehaviour
{
    public int numeroDoEspaco;
    public bool ocupado = false;

    public bool ReceberLivro(int numeroLivro)
    {
        if (ocupado || numeroLivro != numeroDoEspaco)
            return false;

        ocupado = true;
        return true;
    }
}