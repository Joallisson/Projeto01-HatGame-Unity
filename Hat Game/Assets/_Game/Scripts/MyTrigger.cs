using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTrigger : MonoBehaviour
{
    private GameController gameController;
    private UIController uIController;

     void Start() {
        gameController = FindObjectOfType<GameController>();
        uIController = FindObjectOfType<UIController>();
    }

    private void OnTriggerEnter2D(Collider2D target) //SE a bola de boliche sair da camera ela é destruida
    { 
        if (target.gameObject.CompareTag("Destroyer"))
        {
            Destroy(this.gameObject);

        }else if(target.gameObject.CompareTag("Point")) //Se a bola de boliche cair dentro do chapéu ela soma um ponto no objeto gameController e depois destroi a bola
        {
            gameController.score++;
            uIController.txtScore.text = gameController.score.ToString();
            Destroy(this.gameObject);
        }
    }
}
