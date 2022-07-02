using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //FAZENDO O BACKGROUND SE ADAPTAR AO TAMANHO DA TELA ======================================================================
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>(); //pegando a imagem/SpriteRenderer do filho do background
        Vector3 scaleTemp = GetComponentInChildren<Transform>().transform.localScale; //pegando o Transform do filho do background

        float width = sprite.bounds.size.x; //pegando a largura do sprite do bacjground
        float height = sprite.bounds.size.y; //pegando a altura do sprite do bacjground
        float heightCamera = Camera.main.orthographicSize * 2.0f; //FAZENDO CÁLCULO PARA AJUSTAR A HEIGHT DO BACKGROUND PARA O TAMANHO DA TELA
        float widthWorld = heightCamera / Screen.height * Screen.width; //FAZENDO CÁLCULO PARA AJUSTAR A LARGURA DO BACKGROUND PARA O TAMANHO DA TELA

        scaleTemp.x = widthWorld / width; //atribuindo largura do background
        scaleTemp.y = heightCamera / height; //atribuindo altura do background

        transform.localScale = scaleTemp; //definindo altura e largura do background
    }

}
// tela
// width: 200
// height: 100
// 
// sprite
// width: 100
// height: 50