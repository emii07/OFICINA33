using UnityEngine;

public class SeguirPersonagem : MonoBehaviour
{
    [Header("Referências")]
    [SerializeField] private Transform personagem; // Arraste a sua Player aqui
    [SerializeField] private Vector3 offset;     // Distância dos botões em relação à personagem

    void Update()
    {
        if (personagem != null)
        {
            // Se o seu Canvas estiver em "Screen Space - Overlay", use a posição da câmera:
            // Caso queira que fiquem colados na tela acompanhando o movimento, 
            // basta atualizar a posição X baseada na personagem:
            Vector3 novaPosicao = transform.position;
            novaPosicao.x = personagem.position.x + offset.x;
            transform.position = novaPosicao;
        }
    }
}