using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PuzzlePergaminho : MonoBehaviour
{
    [Header("Tiras do Puzzle")]
    [Tooltip("Arraste os 3 componentes Image das tiras (Esquerda, Meio, Direita).")]
    public Image[] imagemTiras = new Image[3];

    [Tooltip("Arraste os 3 Sprites das tiras na ORDEM CORRETA do pergaminho.")]
    public Sprite[] spritesCorretos = new Sprite[3];

    [Header("Resultado")]
    [Tooltip("Objeto da imagem do pergaminho montado/brilhando.")]
    public GameObject pergaminhoCompleto;

    // Guarda a ordem atual dos Sprites (ex: 1, 0, 2)
    private List<int> ordemAtual = new List<int> { 1, 0, 2 }; 
    private int primeiroClique = -1; // -1 significa que nenhuma tira foi selecionada ainda

    void Start()
    {
        EmbaralharEAtualizar();
    }

    public void EmbaralharEAtualizar()
    {
        if (pergaminhoCompleto != null) pergaminhoCompleto.SetActive(false);

        // Garante uma ordem embaralhada no início
        ordemAtual = new List<int> { 2, 0, 1 }; 

        AtualizarVisual();
    }

    // Função chamada ao clicar em uma das tiras (passando 0, 1 ou 2)
    public void ClicarTira(int indice)
    {
        if (primeiroClique == -1)
        {
            // Primeiro clique: seleciona a tira
            primeiroClique = indice;
        }
        else
        {
            // Segundo clique: troca a posição das duas tiras
            int temp = ordemAtual[primeiroClique];
            ordemAtual[primeiroClique] = ordemAtual[indice];
            ordemAtual[indice] = temp;

            primeiroClique = -1; // Reseta a seleção
            AtualizarVisual();
            VerificarVitoria();
        }
    }

    // Função alternativa para botões de seta: troca a posição 'posicao' para a esquerda (-1) ou direita (+1)
    public void MoverTira(int posicao, int direcao)
    {
        int novaPosicao = posicao + direcao;

        // Impede de mover para fora dos limites (0 a 2)
        if (novaPosicao < 0 || novaPosicao >= ordemAtual.Count) return;

        int temp = ordemAtual[posicao];
        ordemAtual[posicao] = ordemAtual[novaPosicao];
        ordemAtual[novaPosicao] = temp;

        AtualizarVisual();
        VerificarVitoria();
    }

    void AtualizarVisual()
    {
        for (int i = 0; i < imagemTiras.Length; i++)
        {
            if (imagemTiras[i] != null && i < spritesCorretos.Length)
            {
                int idSprite = ordemAtual[i];
                if (spritesCorretos[idSprite] != null)
                {
                    imagemTiras[i].sprite = spritesCorretos[idSprite];
                }
            }
        }
    }

    void VerificarVitoria()
    {
        // Verifica se a ordem é exatamente 0, 1, 2
        if (ordemAtual[0] == 0 && ordemAtual[1] == 1 && ordemAtual[2] == 2)
        {
            Debug.Log("Puzzle Resolvido! O Pergaminho foi restaurado.");

            // Esconde as 3 tiras
            foreach (Image img in imagemTiras)
            {
                if (img != null)
                {
                    img.gameObject.SetActive(false);
                }
            }

            // Mostra o pergaminho completo/revelado
            if (pergaminhoCompleto != null)
            {
                pergaminhoCompleto.SetActive(true);
            }
        }
    }
}