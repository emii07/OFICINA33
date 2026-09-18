using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro; // Necessário para usar TextMeshPro

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

    [Tooltip("Arraste aqui o objeto de Texto ou Painel que contém a mensagem de vitória.")]
    public GameObject mensagemVitoria;

    private List<int> ordemAtual = new List<int> { 2, 0, 1 }; 

    void Start()
    {
        EmbaralharEAtualizar();
    }

    public void EmbaralharEAtualizar()
    {
        if (pergaminhoCompleto != null) pergaminhoCompleto.SetActive(false);
        if (mensagemVitoria != null) mensagemVitoria.SetActive(false); // Esconde a mensagem no início

        ordemAtual = new List<int> { 2, 0, 1 }; 
        AtualizarVisual();
    }

    // --- FUNÇÕES PARA OS BOTÕES DE SETA ---
    public void MoverTira0ParaDireita() { MoverTira(0, 1); }
    public void MoverTira1ParaEsquerda() { MoverTira(1, -1); }
    public void MoverTira1ParaDireita() { MoverTira(1, 1); }
    public void MoverTira2ParaEsquerda() { MoverTira(2, -1); }

    public void MoverTira(int posicao, int direcao)
    {
        int novaPosicao = posicao + direcao;

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
        if (ordemAtual[0] == 0 && ordemAtual[1] == 1 && ordemAtual[2] == 2)
        {
            Debug.Log("Puzzle Resolvido! O Pergaminho foi restaurado.");

            // Esconde as tiras
            foreach (Image img in imagemTiras)
            {
                if (img != null) img.gameObject.SetActive(false);
            }

            // Exibe o pergaminho completo
            if (pergaminhoCompleto != null)
            {
                pergaminhoCompleto.SetActive(true);
            }

            // Exibe a mensagem de vitória na tela
            if (mensagemVitoria != null)
            {
                mensagemVitoria.SetActive(true);
            }
        }
    }
    
    public void FecharPainel()
    {
        // Desativa o painel onde todo o puzzle está contido
        gameObject.SetActive(false);
    }
}