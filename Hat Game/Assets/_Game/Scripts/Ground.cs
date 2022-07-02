using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //FAZENDO O ground SE ADAPTAR AO TAMANHO DA TELA ======================================================================
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>(); //pegando a imagem/SpriteRenderer do filho do ground
        Vector3 scaleTemp = GetComponentInChildren<Transform>().transform.localScale; //pegando o Transform do filho do ground

        float width = sprite.bounds.size.x; //pegando a largura do sprite do ground
        float height = sprite.bounds.size.y; //pegando a altura do sprite do ground
        float heightCamera = Camera.main.orthographicSize * 2.0f; //FAZENDO CÁLCULO PARA AJUSTAR A HEIGHT DO ground PARA O TAMANHO DA TELA
        float widthWorld = heightCamera / Screen.height * Screen.width; //FAZENDO CÁLCULO PARA AJUSTAR A LARGURA DO BACKgroundGROUND PARA O TAMANHO DA TELA

        scaleTemp.x = widthWorld / width; //atribuindo largura do ground

        transform.localScale = scaleTemp; //definindo altura e largura do ground
    }

}
