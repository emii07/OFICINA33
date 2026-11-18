using UnityEngine;

public class NaoDestruirAudio : MonoBehaviour
{
    private static NaoDestruirAudio instancia;

    void Awake()
    {
        // Se já existe um tocando, destrói este duplicado para não tocar duas músicas por cima
        if (instancia != null && instancia != this)
        {
            Destroy(gameObject);
            return;
        }

        instancia = this;

        // Faz com que este objeto não seja destruído ao mudar de cena
        DontDestroyOnLoad(gameObject);
    }
}