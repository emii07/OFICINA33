using UnityEngine;

public class Silhueta : MonoBehaviour
{
    public int idSilhueta;

    public bool VerificarEstatua(Estatua estatua)
    {
        if (estatua.idEstatua == idSilhueta)
        {
            return true;
        }

        return false;
    }
}