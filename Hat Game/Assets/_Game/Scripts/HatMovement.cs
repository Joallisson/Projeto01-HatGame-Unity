using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatMovement : MonoBehaviour
{

    [SerializeField] private float speed; //esse atributo [SerializeField] torna uma variável privada aparecer no inspector
    private GameController gameController;
    // Update is called once per frame
    
    private void Start() {
        gameController = FindObjectOfType<GameController>();
    }
    
    void Update()
    {
        DragTouch();
    }

    //Função para movimentar o chapéu //Função para fazer o chapéu acompanhar o dedo na tela
    private void DragTouch()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && gameController.gameStarted) //Se a quantidade de toques na tela for maior que 0 && se o tipo de toque a tela é do tipo movimento
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition; //pegando as coordenadados do meu dedo na tela
            transform.Translate(touchDeltaPosition.x * speed * Time.deltaTime, 0f, 0f); //movendo o chapéu
        }
    }
}
