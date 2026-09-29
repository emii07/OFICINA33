using UnityEngine;
using UnityEngine.SceneManagement;

public class ProximaFase : MonoBehaviour
{
    public void IrParaProximaFase()
    {
        SceneManager.LoadScene("NomeDaProximaCena");
    }
}
